using GameEntityStorageExample.Observation.Events.Managed;
using System;
using System.Collections.Generic;

namespace GameEntityStorageExample.Observation.Events;

partial interface Event<in T>
	{
		public static ReactionCollection<T> Empty
			=> Event.With<T>([]);
	}

public static class Event
	{
		public static BackCallingEvent<T> WithCallback<T>
			(
				this IManagedEvent<T> @event,
				Action callback
			)
			=> new(@event, callback);

		public static EventPattern<T> Pattern<T>
			(
				Action<T> add,
				Action<T> remove
			)
			=> new(add, remove);

		public static ReactionCollection<Action> Empty
			=> Event.With<Action>([]);

		public static ReactionCollection<T> With<T>
			(
				T reaction
			)
			=> Event.With([reaction]);

		public static ReactionCollection<T> With<T>
			(
				ICollection<T> reactions
			)
			=> new(reactions);
	}