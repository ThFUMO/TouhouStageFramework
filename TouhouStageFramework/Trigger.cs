using System;
using UnityEngine;

namespace TouhouStageFramework
{
    /// <summary>
    /// Base class for all triggers.
    /// </summary>
    public abstract class Trigger
    {
        /// <summary>
        /// Check if this <see cref="Trigger"/> has been triggered.
        /// </summary>
        public abstract bool IsTriggered { get; }

        /// <inheritdoc cref="TouhouStageFramework.TriggerType"/>
        public abstract TriggerType TriggerType { get; set; }

        /// <summary>
        /// The update method of this <see cref="Trigger"/>. This is typically called by the backend in the Update method in <see cref="MonoBehaviour"/>.
        /// </summary>
        /// <param name="gameInfo"></param>
        public abstract void Update(GameInfo gameInfo);

        /// <summary>
        /// An event that fires when <see cref="IsTriggered"/> is <see langword="true"/>. The backend typically need to subscribe to this event.
        /// </summary>
        public abstract event EventHandler<TriggeredEventArgs> Triggered;
    }
}