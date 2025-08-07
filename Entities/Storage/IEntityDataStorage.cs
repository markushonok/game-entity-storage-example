using GameEntityStorageExample.Entities.Identity.Instances;
using GameEntityStorageExample.Entities.Storage.Access;

namespace GameEntityStorageExample.Entities.Storage;

/// <summary>
/// Represents a low-level data storage system for entity instances,
/// providing direct control over their lifecycle and access to their data.
/// </summary>
public interface IEntityDataStorage
	{
		/// <summary>
		/// Creates a new entity instance and returns its unique identifier.
		/// </summary>
		void Instantiate(out IInstanceId id);

		/// <summary>
		/// Releases the entity instance associated with the specified identifier.
		/// </summary>
		void FreeBy(IInstanceId id);

		/// <summary>
		/// Raised whenever data of any entity instance is modified.
		/// </summary>
		event DataEdited DataEdited;
	}

/// <summary>
/// Extends <see cref="IEntityDataStorage"/> to enable typed access to
/// entity data structures via <see cref="IDataAccess{T}"/>.
/// </summary>
public interface IEntityDataStorage<T>
	: IEntityDataStorage
	where T: struct
	{
		/// <summary>
		/// Provides typed access to the data of a specific entity instance.
		/// </summary>
		IDataAccess<T> DataWith(IInstanceId id);
	}