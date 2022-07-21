namespace TouhouStageFramework
{
    /// <summary>
    /// Represents how a <see cref="Trigger"/> behaves when it is triggered.
    /// </summary>
    public enum TriggerType
    {
        /// <summary>
        /// Once triggered, this <see cref="Trigger"/> will never be triggered again.
        /// </summary>
        Once,

        /// <summary>
        /// Trigger once, and won't trigger again until <see cref="Trigger.IsTriggered"/> becomes <see langword="false"/> first.
        /// </summary>
        Impulse,

        /// <summary>
        /// Keep triggering as long as <see cref="Trigger.IsTriggered"/> is <see langword="true"/>.
        /// </summary>
        Repeat
    }
}