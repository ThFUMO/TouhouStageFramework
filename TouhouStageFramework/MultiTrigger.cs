using System;
using System.Collections.Generic;

namespace TouhouStageFramework
{
    /// <summary>
    /// A <see cref="Trigger"/> that combines multiple <see cref="Trigger"/>s and triggers when at least one or all of the <see cref="Trigger"/>s are satisfied.
    /// </summary>
    public class MultiTrigger : Trigger
    {
        /// <summary>
        /// The <see cref="Trigger"/>s this <see cref="MultiTrigger"/> contains.
        /// </summary>
        public IList<Trigger> Triggers { get; set; }

        /// <inheritdoc cref="TouhouStageFramework.MultiTriggerType"/>
        public MultiTriggerType MultiTriggerType { get; set; }

        /// <inheritdoc/>
        public override bool IsTriggered
        {
            get
            {
                switch (MultiTriggerType)
                {
                    case MultiTriggerType.Any:
                        foreach (Trigger trigger in Triggers)
                        {
                            if (trigger.IsTriggered)
                            {
                                return true;
                            }
                        }
                        return false;
                    case MultiTriggerType.All:
                        foreach (Trigger trigger in Triggers)
                        {
                            if (!trigger.IsTriggered)
                            {
                                return false;
                            }
                        }
                        return true;
                    default: // impossible
                        return false;
                }
            }
        }

        /// <inheritdoc/>
        public override TriggerType TriggerType { get; set; }

        /// <inheritdoc/>
        public override event EventHandler<TriggeredEventArgs> Triggered;

        /// <summary>
        /// Initializes a new instance of <see cref="MultiTrigger"/>.
        /// </summary>
        /// <param name="triggerType">The <see cref="TriggerType"/> to use.</param>
        /// <param name="multiTriggerType">The <see cref="MultiTriggerType"/> to use.</param>
        /// <param name="triggers">The <see cref="Trigger"/>s to be included in this <see cref="MultiTrigger"/>.</param>
        public MultiTrigger(TriggerType triggerType, MultiTriggerType multiTriggerType, params Trigger[] triggers)
        {
            TriggerType = triggerType;
            MultiTriggerType = multiTriggerType;
            Triggers = triggers;
        }

        /// <summary>
        /// Check if <see cref="Triggered"/> needs to be fired.
        /// </summary>
        /// <param name="gameInfo"><inheritdoc path="/param[@name='gameInfo']"/></param>
        public override void Update(GameInfo gameInfo)
        {
            if (ShouldFireTriggered)
            {
                OnTriggered(gameInfo);
            }
        }

        private void OnTriggered(GameInfo gameInfo)
        {
            Triggered?.Invoke(this, new TriggeredEventArgs(gameInfo));
        }
    }
}