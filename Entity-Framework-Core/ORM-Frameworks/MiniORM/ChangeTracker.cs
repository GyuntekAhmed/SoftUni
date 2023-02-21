namespace MiniORM
{
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.Reflection;

    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly global::System.Collections.Generic.IList<T> allEntities; // Tracks updates of the entities
        private readonly global::System.Collections.Generic.IList<T> added; // Tracks added entities (to be added)
        private readonly global::System.Collections.Generic.IList<T> removed; // Tracks removed entities (to be removed)

        private ChangeTracker()
        {
            this.added = new global::System.Collections.Generic.List<T>();
            this.removed = new global::System.Collections.Generic.List<T>();
        }

        public ChangeTracker(global::System.Collections.Generic.IEnumerable<T> allEntities)
            : this()
        {
            this.allEntities = this.CloneEntities(allEntities);
        }

        public global::System.Collections.Generic.IReadOnlyCollection<T> AllEntities
            => (global::System.Collections.Generic.IReadOnlyCollection<T>)this.allEntities;

        public global::System.Collections.Generic.IReadOnlyCollection<T> Added
            => (global::System.Collections.Generic.IReadOnlyCollection<T>)this.added;

        public global::System.Collections.Generic.IReadOnlyCollection<T> Removed
            => (global::System.Collections.Generic.IReadOnlyCollection<T>)this.removed;

        public void Add(T entity)
            => this.added.Add(entity);

        public void Remove(T entity)
        => this.removed.Add(entity);

        public global::System.Collections.Generic.IEnumerable<T> GetModifiedEntities(global::MiniORM.DbSet<T> dbSet)
        {
            global::System.Collections.Generic.IList<T> modifiedEntities = new global::System.Collections.Generic.List<T>();
            global::System.Reflection.PropertyInfo[] primaryKeys = global::System.Linq.Enumerable
                .ToArray();

            foreach (T proxyEntity in this.AllEntities)
            {
                object[] primaryKeyValues = global::System.Linq.Enumerable
                    .ToArray();
                // Original originalEntity
                T entity = global::System.Linq.Enumerable
                    .FirstOrDefault(e => global::System.Linq.Enumerable.SequenceEqual(primaryKeyValues));
                if (entity == null)
                {
                    continue;
                }

                bool isModified = this.IsModified(proxyEntity, entity);
                if (isModified)
                {
                    modifiedEntities.Add(proxyEntity);
                }
            }

            return modifiedEntities;
        }

        private global::System.Collections.Generic.IEnumerable<object> GetPrimaryKeyValues(global::System.Collections.Generic.IEnumerable<global::System.Reflection.PropertyInfo> primaryKeys, T proxyEntity)
        {
            return global::System.Linq.Enumerable
                .Select(pk => pk.GetValue(proxyEntity));
        }

        private bool IsModified(T proxyEntity, T originalEntity)
        {
            global::System.Reflection.PropertyInfo[] monitoredProperties = global::System.Linq.Enumerable
                .ToArray();
            global::System.Reflection.PropertyInfo[] modifiedProperties = global::System.Linq.Enumerable
                .ToArray();

            return global::System.Linq.Enumerable.Any();
        }

        private global::System.Collections.Generic.IList<T> CloneEntities(global::System.Collections.Generic.IEnumerable<T> originalEntities)
        {
            global::System.Collections.Generic.IList<T> clonedEntities = new global::System.Collections.Generic.List<T>();
            global::System.Reflection.PropertyInfo[] propertiesToClone = global::System.Linq.Enumerable
                .ToArray();

            foreach (T originalEntity in originalEntities)
            {
                T entityClone = global::System.Activator.CreateInstance<T>();
                foreach (global::System.Reflection.PropertyInfo property in propertiesToClone)
                {
                    object originalValue = property.GetValue(originalEntity);
                    property.SetValue(entityClone, originalValue);
                }

                clonedEntities.Add(entityClone);
            }

            return clonedEntities;
        }
    }
}