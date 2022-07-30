namespace TouhouStageFramework
{
    /// <summary>
    /// Represents the state of an <see cref="Enemy"/>.
    /// </summary>
    public enum EnemyState
    {
        /// <summary>
        /// This <see cref="Enemy"/> hasn't been spawned yet.
        /// </summary>
        BeforeSpawning,

        /// <summary>
        /// This <see cref="Enemy"/> has been spawned and is currently in the stage.
        /// </summary>
        Spawned,

        /// <summary>
        /// This <see cref="Enemy"/> has been spawned and killed.
        /// </summary>
        Killed
    }
}