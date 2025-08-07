using GameEntityStorageExample.DataStructs.Enumerables;
using System;
using System.Collections.Generic;

namespace GameEntityStorageExample.Observation.Events.Managed;

public sealed partial class ReactionCollection<T>
	(
		ICollection<T> reactions
	) 
	: IManagedEvent<T>
	{
		public void Add(T reaction)
			=> reactions.Add(reaction);

		public void Remove(T reaction)
			=> reactions.Remove(reaction);

		public void Raise(Action<T> arouse)
			=> reactions.ForEachDo(arouse);
	}