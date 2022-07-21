namespace TouhouStageFramework
{
    /// <summary>
    /// Base class for all enemy types.
    /// </summary>
    public abstract class Enemy
    {
        /// <summary>
        /// The name of this enemy.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Implicitly converts a single <see cref="Enemy"/> to an <see cref="EnemyBatch"/> that contains only this <see cref="Enemy"/>.
        /// </summary>
        /// <param name="enemy">The <see cref="Enemy"/> to convert to an <see cref="EnemyBatch"/>.</param>
        public static implicit operator EnemyBatch(Enemy enemy)
        {
            return new EnemyBatch(enemy);
        }
    }
}