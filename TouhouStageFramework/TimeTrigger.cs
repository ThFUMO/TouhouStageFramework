using System;

namespace TouhouStageFramework
{
    /// <summary>
    /// A trigger based on the time elapsed since the start of a stage.
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

        private bool hasTriggered = false;

        private bool lastTriggered = false;

        private GameInfo gameInfo;

        /// <summary>
        /// Initializes a new instance of <see cref="TimeTrigger"/> that triggers after <paramref name="triggerTime"/> seconds after a stage has started.
        /// </summary>
        /// <param name="triggerTime">The time in seconds since the start of a stage it takes to trigger this <see cref="Trigger"/>.</param>
        /// <param name="triggerType"><inheritdoc cref="Trigger.TriggerType" path="/summary"/></param>
        public TimeTrigger(double triggerTime, TriggerType triggerType)
        {
            TriggerTime = triggerTime;
            TriggerType = triggerType;
        }
        
        /// <inheritdoc cref="Trigger.IsTriggered"/>
        public override bool IsTriggered
        {
            get
            {
                return ElapsedTime - StartTime > TriggerTime;
            }
        }

        /// <summary>
        /// Updates <see cref="StartTime"/> and <see cref="ElapsedTime"/> and invokes <see cref="Triggered"/> if <see cref="TriggerTime"/> seconds have elapsed.
        /// </summary>
        /// <param name="gameInfo"></param>
        public override void Update(GameInfo gameInfo)
        {
            this.gameInfo = gameInfo;
            if (!gameInfo.IsPaused)
            {
                ElapsedTime += gameInfo.DeltaTime;
            }
            if (IsTriggered)
            {
                switch (TriggerType)
                {
                    case TriggerType.Once:
                        if (!hasTriggered)
                        {
                            OnTriggered();
                            hasTriggered = true;
                        }
                        break;
                    case TriggerType.Impulse:
                        if (!lastTriggered)
                        {
                            OnTriggered();
                        }
                        break;
                    case TriggerType.Repeat:
                        OnTriggered();
                        break;
                }
            }
            lastTriggered = IsTriggered;
        }

        /// <inheritdoc cref="Trigger.Triggered"/>
        public override event EventHandler<TriggeredEventArgs> Triggered;

        private void OnTriggered()
        {
            Triggered?.Invoke(this, new TriggeredEventArgs(gameInfo));
        }
    }
}