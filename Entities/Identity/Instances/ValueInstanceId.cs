namespace GameEntityStorageExample.Entities.Identity.Instances;

public readonly record struct ValueInstanceId
	(
		int AsInteger
	)
	: IInstanceId;