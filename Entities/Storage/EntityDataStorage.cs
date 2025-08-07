using GameEntityStorageExample.Entities.Identity.Instances;
using GameEntityStorageExample.Entities.Storage.Access;
using GameEntityStorageExample.Observation.Events.Managed;

namespace GameEntityStorageExample.Entities.Storage;

/// <summary>
/// Default implementation of <see cref="IEntityDataStorage{T}"/> that stores
/// entity data in a contiguous array, supports dynamic capacity growth,
/// and enables efficient reuse of memory via a free list.
/// </summary>
public sealed partial class EntityDataStorage<T>
	(
		IManagedEvent<DataEdited> dataEdited,
		Func<T> constructor,
		T[] dataArray,
		int[] freeIndices,
		int count,
		int freeTop
	)
	: IEntityDataStorage<T>
	where T: struct
	{
		public IDataAccess<T> DataWith(IInstanceId id)
			{
				var index = id.AsInteger;

				if ((uint) index >= (uint) count)
					throw InvalidInstanceIdException(id);

				return new DataAccess<T>
					(
						data: () => ref dataArray[index],
						onEdited: () => dataEdited.Raise(x => x(id))
					);
			}

		public void Instantiate(out IInstanceId id)
			{
				int index;
				if (freeTop >= 0)
					{
						index = freeIndices[freeTop--];
					}
				else
					{
						if (count == dataArray.Length)
							GrowCapacity();

						index = count++;
					}
				dataArray[index] = constructor();
				id = new ValueInstanceId(index);
			}

		public void FreeBy(IInstanceId id)
			{
				var index = id.AsInteger;

				if ((uint) index >= (uint) count)
					throw InvalidInstanceIdException(id);

				freeIndices[++freeTop] = index;
			}

		public event DataEdited DataEdited
			{
				add => dataEdited.Add(value);
				remove => dataEdited.Remove(value);
			}

		private void GrowCapacity()
			{
				var capacity = dataArray.Length * 2;
				Array.Resize(ref dataArray, capacity);
				Array.Resize(ref freeIndices, capacity);
			}

		private static ArgumentOutOfRangeException InvalidInstanceIdException
			(
				IInstanceId id
			)
			=> new
				(
					nameof(id),
					$"Invalid instance ID ({id.AsInteger})."
				);
	}