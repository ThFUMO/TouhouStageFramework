using System.Numerics;
using System.Collections.Generic;

namespace TouhouStageFramework
{
    /// <summary>
    /// Represents the state of the game at an instant. Instances of this class is usually provided by the backend.
    /// </summary>
    public class GameInfo
    {
        /// <summary>
        /// The current position of the player.
        /// </summary>
        public Vector2 PlayerPosition { get; set; }

        /// <summary>
        /// All <see cref="Enemy"/> currently on the screen.
        /// </summary>
        public IList<Enemy> Enemies { get; set; }
        
        /// <summary>
        /// Current life count.
        /// </summary>
        public int LifeCount { get; set; }

        /// <summary>
        /// Current life piece count.
        /// </summary>
        public int LifePieceCount { get; set; }

        /// <summary>
        /// Current spellcard count.
        /// </summary>
        public int SpellcardCount { get; set; }

        /// <summary>
        /// Current spellcard piece count.
        /// </summary>
        public int SpellcardPieceCount { get; set; }

        /// <summary>
        /// Current score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Current high score.
        /// </summary>
        public int HighScore { get; set; }

        /// <summary>
        /// Current power value.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Current max value of point items.
        /// </summary>
        public int MaxPointValue { get; set; }

        /// <summary>
        /// Current graze count.
        /// </summary>
        public int GrazeCount { get; set; }

        /// <summary>
        /// Is game paused?
        /// </summary>
        public bool IsPaused { get; set; }

        /// <summary>
        /// The time in seconds since the start of a stage.
        /// </summary>
        public double Time { get; set; }

        /// <summary>
        /// The time difference between this frame and the last in seconds.
        /// </summary>
        public double DeltaTime { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameInfo()
        {

        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="other">The <see cref="GameInfo"/> to copy from.</param>
        public GameInfo(GameInfo other)
        {
            PlayerPosition = other.PlayerPosition;
            Enemies = other.Enemies;
            LifeCount = other.LifeCount;
            LifePieceCount = other.LifePieceCount;
            SpellcardCount = other.SpellcardCount;
            SpellcardPieceCount = other.SpellcardPieceCount;
            Score = other.Score;
            HighScore = other.HighScore;
            Power = other.Power;
            MaxPointValue = other.MaxPointValue;
            GrazeCount = other.GrazeCount;
            IsPaused = other.IsPaused;
            Time = other.Time;
            DeltaTime = other.DeltaTime;
        }
    }
}