namespace GameEntityStorageExample.Entities.Storage.Access;

/// <summary>
/// Provides managed access to entity data.
/// </summary>
public interface IDataAccess<T>
	where T: struct
	{
		/// <summary>
		/// Read-only reference to the entity data.
		/// </summary>
		ref readonly T Look { get; }

		/// <summary>
		/// Applies managed mutation to the entity data.
		/// </summary>
		void Edit(EditData<T> action);
	}