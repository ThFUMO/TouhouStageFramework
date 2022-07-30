namespace TouhouStageFramework
{
    /// <summary>
    /// Represents when should a <see cref="MultiTrigger"/> be triggered.
    /// </summary>
    public enum MultiTriggerType
    {
        /// <summary>
        /// The <see cref="MultiTrigger"/> triggers when at least one of the <see cref="Trigger"/>s is satisfied.
        /// </summary>
        Any,

        /// <summary>
        /// The <see cref="MultiTrigger"/> triggers when all of the <see cref="Trigger"/>s are satisfied.
        /// </summary>
        All
    }
}