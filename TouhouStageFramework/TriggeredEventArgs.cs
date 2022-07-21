using System;

namespace TouhouStageFramework
{
    /// <summary>
    /// <see cref="EventArgs"/> for <see cref="Trigger.Triggered"/>.
    /// </summary>
    public class TriggeredEventArgs : EventArgs
    {
        /// <summary>
        /// Current <see cref="GameInfo"/>.
        /// </summary>
        public GameInfo GameInfo { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="TriggeredEventArgs"/>.
        /// </summary>
        /// <param name="gameInfo">Current <see cref="GameInfo"/>.</param>
        public TriggeredEventArgs(GameInfo gameInfo)
        {
            GameInfo = gameInfo;
        }
    }
}