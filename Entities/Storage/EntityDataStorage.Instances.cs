using GameEntityStorageExample.Observation.Events;
using System;

namespace GameEntityStorageExample.Entities.Storage;

partial class EntityDataStorage<T>
	{
		public static EntityDataStorage<T> Empty
			(
				int initialCapacity = 16
			)
			=> new
				(
					dataEdited: Event<DataEdited>.Empty,
					constructor: () => new T(),
					dataArray: new T[initialCapacity],
					freeIndices: new int[initialCapacity],
					count: 0,
					freeTop: 0
				);

		public static EntityDataStorage<T> Empty
			(
				Func<T> constructor,
				int initialCapacity = 16
			)
			=> new
				(
					dataEdited: Event<DataEdited>.Empty,
					constructor,
					dataArray: new T[initialCapacity],
					freeIndices: new int[initialCapacity],
					count: 0,
					freeTop: 0
				);
	}