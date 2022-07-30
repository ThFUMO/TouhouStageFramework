using System;

namespace TouhouStageFramework
{
    /// <summary>
    /// A <see cref="Trigger"/> based on the time elapsed since the start of a stage.
    /// </summary>
    public class TimeTrigger : Trigger
    {
        /// <summary>
        /// The time in seconds since the start of a stage it takes to trigger this <see cref="Trigger"/>.
        /// </summary>
        public double TriggerTime { get; set; }

        /// <summary>
        /// The time when a stage has started for this <see cref="Trigger"/>. This is typically set by the backend.
        /// </summary>
        public double StartTime { get; set; }

        /// <summary>
        /// The time elapsed since the start of a stage for this <see cref="Trigger"/>. This is typically set by the backend.
        /// </summary>
        public double ElapsedTime { get; set; }

        /// <inheritdoc cref="Trigger.TriggerType"/>
        public override TriggerType TriggerType { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="TimeTrigger"/> that triggers after <paramref name="triggerTime"/> seconds after a stage has started.
        /// </summary>
        /// <param name="triggerTime">The time in seconds since the start of a stage it takes to trigger this <see cref="Trigger"/>.</param>
        /// <param name="triggerType">The <see cref="TouhouStageFramework.TriggerType"/> to use.</param>
        public TimeTrigger(double triggerTime, TriggerType triggerType)
        {
            TriggerTime = triggerTime;
            TriggerType = triggerType;
        }
        
        /// <inheritdoc/>
        public override bool IsTriggered
        {
            get
            {
                return ElapsedTime - StartTime > TriggerTime;
            }
        }

        /// <summary>
        /// Updates <see cref="ElapsedTime"/> and checks if <see cref="Triggered"/> needs to be fired.
        /// </summary>
        /// <param name="gameInfo"><inheritdoc path="/param[@name='gameInfo']"/></param>
        public override void Update(GameInfo gameInfo)
        {
            if (!gameInfo.IsPaused)
            {
                ElapsedTime += gameInfo.DeltaTime;
            }
            if (ShouldFireTriggered)
            {
                OnTriggered(gameInfo);
            }
        }

        /// <inheritdoc/>
        public override event EventHandler<TriggeredEventArgs> Triggered;

        private void OnTriggered(GameInfo gameInfo)
        {
            Triggered?.Invoke(this, new TriggeredEventArgs(gameInfo));
        }
    }
}