using GameEntityStorageExample.Entities.Identity.Instances;

namespace GameEntityStorageExample.Entities.Storage;

/// <summary>
/// Represents a callback that is triggered when entity data is edited.
/// </summary>
public delegate void DataEdited(IInstanceId id);