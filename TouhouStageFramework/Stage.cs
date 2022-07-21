namespace TouhouStageFramework
{
    /// <summary>
    /// Base class for all stages.
    /// </summary>
    public abstract class Stage
    {
        /// <summary>
        /// The name of this stage.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The path to the thumbnail PNG/JPG relative to the dll.
        /// </summary>
        public abstract string ThumbnailPath { get; }
    }
}