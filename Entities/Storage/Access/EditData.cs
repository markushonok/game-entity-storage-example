namespace GameEntityStorageExample.Entities.Storage.Access;

/// <summary>
/// Represents a delegate that modifies entity data by reference.
/// Used to apply managed mutations within a safe data access context.
/// </summary>
public delegate void EditData<T>(ref T data);