namespace MiniORM
{
    using global::System.Collections;

    /// <summary>
    /// DbSet represents each table of the database. Entity class acts as a column description of the table.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DbSet<TEntity> : global::System.Collections.Generic.ICollection<TEntity>
        where TEntity : class, new()
    {
        internal DbSet(global::System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            this.Entities = global::System.Linq.Enumerable.ToList();
            this.ChangeTracker = new global::MiniORM.ChangeTracker<TEntity>(entities);
        }

        internal global::MiniORM.ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal global::System.Collections.Generic.IList<TEntity> Entities { get; set; }

        public int Count
            => this.Entities.Count;

        public bool IsReadOnly
            => this.Entities.IsReadOnly;

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new global::System.ArgumentNullException(nameof(entity), global::MiniORM.ExceptionMessages.EntityNullException);
            }

            this.Entities.Add(entity);
            this.ChangeTracker.Add(entity); // Log added entity
        }

        public bool Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new global::System.ArgumentNullException(nameof(entity), global::MiniORM.ExceptionMessages.EntityNullException);
            }

            bool isRemoved = this.Entities.Remove(entity);
            if (isRemoved)
            {
                this.ChangeTracker.Remove(entity);
            }

            return isRemoved;
        }

        public void RemoveRange(global::System.Collections.Generic.IEnumerable<TEntity> entitiesToRemove)
        {
            foreach (TEntity entity in entitiesToRemove)
            {
                this.Remove(entity);
            }
        }

        public void Clear()
        {
            while (global::System.Linq.Enumerable.Any())
            {
                TEntity entityToRemove = global::System.Linq.Enumerable.First();
                this.Remove(entityToRemove);
            }
        }

        public bool Contains(TEntity item)
            => this.Entities.Contains(item);

        // We will not use this method anywhere but it is derived from ICollection<T>
        public void CopyTo(TEntity[] array, int arrayIndex)
            => this.Entities.CopyTo(array, arrayIndex);

        // This will allow our DbSet<TEntity> to work with ForEach loop
        public global::System.Collections.Generic.IEnumerator<TEntity> GetEnumerator()
            => this.Entities.GetEnumerator();

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
