using System;

namespace GameEntityStorageExample.Entities.Storage.Access;

/// <summary>
/// Encapsulates a managed reference to entity data and invokes
/// a callback after mutation.
/// </summary>
public sealed class DataAccess<T>
	(
		Ref<T> data,
		Action onEdited
	)
	: IDataAccess<T> where T: struct
	{
		public ref readonly T Look
			=> ref data();

		public void Edit(EditData<T> action)
			{
				action(ref data());
				onEdited();
			}
	}