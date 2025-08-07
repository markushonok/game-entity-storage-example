using System;

namespace GameEntityStorageExample.Observation.Events.Managed;

public interface IManagedEvent<T>: Event<T>
	{
		void Raise(Action<T> arouse);
	}