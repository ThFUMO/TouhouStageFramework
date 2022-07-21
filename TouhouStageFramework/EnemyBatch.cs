using System.Collections;
using System.Collections.Generic;

namespace TouhouStageFramework
{
    /// <summary>
    /// Represents a group of <see cref="Enemy"/>.
    /// </summary>
    public class EnemyBatch : IList<Enemy>
    {
        private readonly List<Enemy> list = new List<Enemy>();

        /// <summary>
        /// Initializes a new <see cref="EnemyBatch"/>.
        /// </summary>
        /// <param name="enemies"><see cref="Enemy"/> to include in this <see cref="EnemyBatch"/>.</param>
        public EnemyBatch(params Enemy[] enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                list.Add(enemy);
            }
        }

        /// <inheritdoc cref="List{T}.this"/>
        public Enemy this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        /// <inheritdoc cref="List{T}.Count"/>
        public int Count
        {
            get => list.Count;
        }

        /// <inheritdoc cref="ICollection{T}.IsReadOnly"/>
        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<Enemy>)list).IsReadOnly;
            }
        }

        /// <inheritdoc cref="List{T}.Add(T)"/>
        public void Add(Enemy item)
        {
            list.Add(item);
        }

        /// <inheritdoc cref="List{T}.Clear"/>
        public void Clear()
        {
            list.Clear();
        }

        /// <inheritdoc cref="List{T}.Contains(T)"/>
        public bool Contains(Enemy item)
        {
            return list.Contains(item);
        }

        /// <inheritdoc cref="List{T}.CopyTo(T[], int)"/>
        public void CopyTo(Enemy[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc cref="List{T}.GetEnumerator"/>
        public IEnumerator<Enemy> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <inheritdoc cref="List{T}.IndexOf(T)"/>
        public int IndexOf(Enemy item)
        {
            return list.IndexOf(item);
        }

        /// <inheritdoc cref="List{T}.Insert(int, T)"/>
        public void Insert(int index, Enemy item)
        {
            list.Insert(index, item);
        }

        /// <inheritdoc cref="List{T}.Remove"/>
        public bool Remove(Enemy item)
        {
            return list.Remove(item);
        }

        /// <inheritdoc cref="List{T}.RemoveAt(int)"/>
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        /// <inheritdoc cref="List{T}.GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}