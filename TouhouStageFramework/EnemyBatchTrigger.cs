using System;

namespace TouhouStageFramework
{
    /// <summary>
    /// A <see cref="Trigger"/> that triggers when all <see cref="Enemy"/>s in an <see cref="EnemyBatch"/> satisfy the <see cref="TargetState"/>.
    /// </summary>
    public class EnemyBatchTrigger : Trigger
    {
        /// <summary>
        /// The <see cref="EnemyBatch"/> this <see cref="Trigger"/> targets.
        /// </summary>
        public EnemyBatch TargetBatch { get; set; }

        /// <summary>
        /// The <see cref="EnemyState"/> that should be satisfied when this <see cref="Trigger"/> triggers.
        /// </summary>
        public EnemyState TargetState { get; set; }

        /// <inheritdoc/>
        public override TriggerType TriggerType { get; set; }

        /// <inheritdoc/>
        public override bool IsTriggered
        {
            get
            {
                foreach (Enemy enemy in TargetBatch)
                {
                    if (enemy.State != TargetState)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Initializes a new instace of <see cref="EnemyBatchTrigger"/>.
        /// </summary>
        /// <param name="batch">The <see cref="EnemyBatch"/> to target.</param>
        /// <param name="state">The <see cref="EnemyState"/> used as the condition.</param>
        /// <param name="triggerType"><inheritdoc cref="Trigger.TriggerType" path="/summary"/></param>
        public EnemyBatchTrigger(EnemyBatch batch, EnemyState state, TriggerType triggerType)
        {
            TargetBatch = batch;
            TargetState = state;
            TriggerType = triggerType;
        }

        /// <summary>
        /// Fires <see cref="Triggered"/> if both of the <see cref="TargetState"/> and <see cref="TriggerType"/> conditions are met.
        /// </summary>
        /// <param name="gameInfo"><inheritdoc path="/param[@name='gameInfo']"/></param>
        public override void Update(GameInfo gameInfo)
        {
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