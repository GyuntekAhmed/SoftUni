namespace MiniORM
{
    using global::System.Collections;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;
    using global::System.Reflection;

    using global::Microsoft.Data.SqlClient;

    /// <summary>
    /// User should derive from DbContext and then he will add wanted DbSet from entities.
    /// We need to discover run-time added DbSets from user.
    /// </summary>
    public abstract class DbContext
    {
        private readonly global::MiniORM.DatabaseConnection connection;
        private readonly global::System.Collections.Generic.IDictionary<global::System.Type, global::System.Reflection.PropertyInfo> dbSetProperties;

        public DbContext(string connectionString)
        {
            this.connection = new global::MiniORM.DatabaseConnection(connectionString);
            this.dbSetProperties = this.DiscoverDbSets();
            using (new global::MiniORM.ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }

            this.MapAllRelations();
        }

        internal static readonly global::System.Type[] AllowedSqlTypes =
        {
        typeof(string), //VARCHAR, NVARCHAR, CHAR, NCHAR
        typeof(int), // INT
        typeof(uint), // INT
        typeof(long), //BIGINT
        typeof(ulong), //BIGINT
        typeof(decimal), //DECIMAL
        typeof(bool), //BIT
        typeof(global::System.DateTime) //DATETIME, DATETIME2
    };

        public void SaveChanges()
        {
            object[] dbSets = global::System.Linq.Enumerable
                .ToArray();
            foreach (global::System.Collections.Generic.IEnumerable<object> dbSet in dbSets)
            {
                global::System.Collections.Generic.IEnumerable<object> invalidEntities = global::System.Linq.Enumerable
                    .ToArray();
                if (global::System.Linq.Enumerable.Any())
                {
                    throw new global::System.InvalidOperationException(string.Format(global::MiniORM.ExceptionMessages.InvalidEntitiesException, global::System.Linq.Enumerable.Count(), dbSet.GetType().Name));
                }
            }

            using (new global::MiniORM.ConnectionManager(this.connection))
            {
                using SqlTransaction transaction = this.connection.StartTransaction();

                foreach (global::System.Collections.IEnumerable dbSet in dbSets)
                {
                    global::System.Type dbSetType = global::System.Linq.Enumerable.First();
                    global::System.Reflection.MethodInfo persistMethod = typeof(global::MiniORM.DbContext)
                        .GetMethod("Persist", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)
                        .MakeGenericMethod(dbSetType);

                    try
                    {
                        persistMethod.Invoke(this, new object[] { dbSet });
                    }
                    catch (global::System.Reflection.TargetInvocationException tie)
                    {
                        // No need of rollback because Persist<T> method was never invoked!
                        throw tie.InnerException;
                    }
                    catch (global::System.InvalidOperationException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

                transaction.Commit();
            }
        }

        // We do not use this Validator in real projects!
        private bool IsObjectValid(object o)
        {
            global::System.ComponentModel.DataAnnotations.ValidationContext validationContext = new global::System.ComponentModel.DataAnnotations.ValidationContext(o);
            global::System.Collections.Generic.ICollection<global::System.ComponentModel.DataAnnotations.ValidationResult> errors = new global::System.Collections.Generic.List<global::System.ComponentModel.DataAnnotations.ValidationResult>();

            bool validationResult = global::System.ComponentModel.DataAnnotations.Validator.TryValidateObject(o, validationContext, errors, true);
            return validationResult;
        }

        private void Persist<TEntity>(global::MiniORM.DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            string tableName = this.GetTableName(typeof(TEntity));
            string[] columns = global::System.Linq.Enumerable
                .ToArray();
            if (global::System.Linq.Enumerable.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }

            global::System.Collections.Generic.IEnumerable<TEntity> modifiedEntities = global::System.Linq.Enumerable
                .ToArray();
            if (global::System.Linq.Enumerable.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, columns);
            }

            if (global::System.Linq.Enumerable.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
            }
        }

        private string GetTableName(global::System.Type tableType)
        {
            string tableName = global::System.Reflection.CustomAttributeExtensions.GetCustomAttribute<global::System.ComponentModel.DataAnnotations.Schema.TableAttribute>()?.Name;
            if (tableName == null)
            {
                tableName = this.dbSetProperties[tableType].Name;
            }

            return tableName;
        }

        private global::System.Collections.Generic.IDictionary<global::System.Type, global::System.Reflection.PropertyInfo> DiscoverDbSets()
        {
            global::System.Collections.Generic.IDictionary<global::System.Type, global::System.Reflection.PropertyInfo> dbSets = global::System.Linq.Enumerable
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);
            return dbSets;
        }

        private void InitializeDbSets()
        {
            foreach (global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Reflection.PropertyInfo> dbSetInfo in this.dbSetProperties)
            {
                global::System.Type dbSetType = dbSetInfo.Key;
                global::System.Reflection.PropertyInfo dbSetProperty = dbSetInfo.Value;

                global::System.Reflection.MethodInfo populateDbSetMethod = typeof(global::MiniORM.DbContext)
                    .GetMethod("PopulateDbSet", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);
                populateDbSetMethod.Invoke(this, new object[] { dbSetProperty });
            }
        }

        private void PopulateDbSet<TEntity>(global::System.Reflection.PropertyInfo dbSet)
            where TEntity : class, new()
        {
            global::System.Collections.Generic.IEnumerable<TEntity> entities = this.LoadTableEntities<TEntity>();
            global::MiniORM.DbSet<TEntity> dbSetInstance = new global::MiniORM.DbSet<TEntity>(entities);

            global::MiniORM.ReflectionHelper.ReplaceBackingField(this, dbSet.Name, dbSetInstance);
        }

        private global::System.Collections.Generic.IEnumerable<TEntity> LoadTableEntities<TEntity>() where TEntity : class, new()
        {
            global::System.Type entityType = typeof(TEntity);
            string[] columns = this.GetEntityColumnNames(entityType);
            string tableName = this.GetTableName(entityType);

            global::System.Collections.Generic.IEnumerable<TEntity> fetchedRows = global::System.Linq.Enumerable
                .ToArray();
            return fetchedRows;
        }

        private string[] GetEntityColumnNames(global::System.Type entityType)
        {
            string tableName = this.GetTableName(entityType);
            string[] dbColumns = global::System.Linq.Enumerable
                .ToArray();

            string[] columnsTaken = global::System.Linq.Enumerable
                .ToArray();
            return columnsTaken;
        }

        private void MapAllRelations()
        {
            foreach (global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Reflection.PropertyInfo> dbSetInfo in this.dbSetProperties)
            {
                global::System.Type dbSetEntityType = dbSetInfo.Key;
                object dbSetInstance = dbSetInfo.Value.GetValue(this);
                global::System.Reflection.MethodInfo mapRelationsMethod = typeof(global::MiniORM.DbContext)
                    .GetMethod("MapRelations", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetEntityType);

                mapRelationsMethod.Invoke(this, new object[] { dbSetInstance });
            }
        }

        private void MapRelations<TEntity>(global::MiniORM.DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            global::System.Type entityType = typeof(TEntity);
            this.MapNavigationProperties(dbSet);
            global::System.Reflection.PropertyInfo[] collections = global::System.Linq.Enumerable
                .ToArray();
            foreach (global::System.Reflection.PropertyInfo collection in collections)
            {
                global::System.Type collectionEntityType = global::System.Linq.Enumerable
                    .First();
                global::System.Reflection.MethodInfo mapCollectionMethod = typeof(global::MiniORM.DbContext)
                    .GetMethod("MapCollection", global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionEntityType);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapNavigationProperties<TEntity>(global::MiniORM.DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            global::System.Type entityType = typeof(TEntity);

            global::System.Reflection.PropertyInfo[] foreignKeys = global::System.Linq.Enumerable
                .ToArray();
            foreach (global::System.Reflection.PropertyInfo fk in foreignKeys)
            {
                string navigationPropertyName = global::System.Reflection.CustomAttributeExtensions
                    .GetCustomAttribute<global::System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute>().Name;
                global::System.Reflection.PropertyInfo navigationProperty = entityType
                    .GetProperty(navigationPropertyName);

                global::System.Collections.Generic.IEnumerable<object> navigationDbSet = (global::System.Collections.Generic.IEnumerable<object>)this.dbSetProperties[navigationProperty.PropertyType]
                    .GetValue(this);
                global::System.Reflection.PropertyInfo navigationEntityPK = global::System.Linq.Enumerable
                    .First(pi => pi.HasAttribute<global::System.ComponentModel.DataAnnotations.KeyAttribute>());

                foreach (TEntity entity in dbSet)
                {
                    object foreignKeyValue = fk.GetValue(entity);
                    object navigationPropertyValue = global::System.Linq.Enumerable
                        .First(cnp => navigationEntityPK.GetValue(cnp).Equals(foreignKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private void MapCollection<TEntity, TCollection>(global::MiniORM.DbSet<TEntity> dbSet, global::System.Reflection.PropertyInfo collection)
            where TEntity : class, new()
            where TCollection : class, new()
        {
            global::System.Type entityType = typeof(TEntity);
            global::System.Type collectionType = typeof(TCollection);

            global::System.Reflection.PropertyInfo[] collectionTypePrimaryKeys = global::System.Linq.Enumerable
                .ToArray();

            global::System.Reflection.PropertyInfo foreignKey = global::System.Linq.Enumerable.First();
            global::System.Reflection.PropertyInfo primaryKey = global::System.Linq.Enumerable
                .First(pi => pi.HasAttribute<global::System.ComponentModel.DataAnnotations.KeyAttribute>());

            bool isManyToMany = collectionTypePrimaryKeys.Length >= 2;
            if (isManyToMany)
            {
                foreignKey = global::System.Linq.Enumerable
                    .First(pi => collectionType
                        .GetProperty(pi.GetCustomAttribute<global::System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute>().Name)
                    .PropertyType == entityType);
            }

            global::MiniORM.DbSet<TCollection> navigationDbSet = (global::MiniORM.DbSet<TCollection>)this.dbSetProperties[collectionType]
                .GetValue(this);
            foreach (TEntity entity in dbSet)
            {
                object primaryKeyValue = primaryKey.GetValue(entity);
                global::System.Collections.Generic.IEnumerable<TCollection> navigationEntities = global::System.Linq.Enumerable
                    .ToArray();
                global::MiniORM.ReflectionHelper.ReplaceBackingField(entity, collection.Name, navigationEntities);
            }
        }
    }
}
