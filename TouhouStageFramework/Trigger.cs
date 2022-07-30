using System;

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

        private bool hasTriggered = false;

        private bool lastTriggered = false;

        /// <summary>
        /// The update method of this <see cref="Trigger"/>. This is typically called by the backend every frame. It is used to update the state of this <see cref="Trigger"/> and fire <see cref="Triggered"/> if necessary.
        /// </summary>
        /// <param name="gameInfo">The current <see cref="GameInfo"/>.</param>
        public abstract void Update(GameInfo gameInfo);

        /// <summary>
        /// An event that fires when <see cref="IsTriggered"/> is <see langword="true"/> and the current condition satisfies <see cref="TriggerType"/>. The backend typically need to subscribe to this event.
        /// </summary>
        public abstract event EventHandler<TriggeredEventArgs> Triggered;

        /// <summary>
        /// A simple helper that helps determine if <see cref="Triggered"/> should be fired by checking <see cref="IsTriggered"/> and <see cref="TriggerType"/>.
        /// </summary>
        protected bool ShouldFireTriggered
        {
            get
            {
                if (IsTriggered)
                {
                    switch (TriggerType)
                    {
                        case TriggerType.Once:
                            if (!hasTriggered)
                            {
                                hasTriggered = true;
                                return true;
                            }
                            break;
                        case TriggerType.Impulse:
                            if (!lastTriggered)
                            {
                                return true;
                            }
                            break;
                        case TriggerType.Repeat:
                            return true;
                    }
                }
                lastTriggered = IsTriggered;
                return false;
            }
        }
    }
}