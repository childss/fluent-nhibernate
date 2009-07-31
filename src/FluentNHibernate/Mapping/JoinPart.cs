using System.Collections.Generic;
using FluentNHibernate.Mapping.Providers;
using FluentNHibernate.MappingModel;

namespace FluentNHibernate.Mapping
{
    /// <summary>
    /// Maps to the Join element in NH 2.0
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JoinPart<T> : ClasslikeMapBase<T>, IJoinMappingProvider
    {
        private readonly IList<string> columns = new List<string>();
        private readonly JoinMapping mapping = new JoinMapping();
        private readonly FetchTypeExpression<JoinPart<T>> fetch;
        private bool nextBool = true;

        public JoinPart(string tableName)
        {
            fetch = new FetchTypeExpression<JoinPart<T>>(this, value => mapping.Fetch = value);
            mapping.TableName = tableName;
            mapping.Key = new KeyMapping { ContainingEntityType = typeof(T) };

            columns.Add(GetType().GetGenericArguments()[0].Name + "ID");
        }

        public JoinPart<T> KeyColumn(string column)
        {
            columns.Clear(); // only one supported currently
            columns.Add(column);
            return this;
        }

        public JoinPart<T> Schema(string schema)
        {
            mapping.Schema = schema;
            return this;
        }

        public FetchTypeExpression<JoinPart<T>> Fetch
        {
            get { return fetch; }
        }

        public JoinPart<T> Inverse()
        {
            mapping.Inverse = nextBool;
            nextBool = true;
            return this;
        }

        public JoinPart<T> Optional()
        {
            mapping.Optional = nextBool;
            nextBool = true;
            return this;
        }

        public JoinPart<T> Catalog(string catalog)
        {
            mapping.Catalog = catalog;
            return this;
        }

        public JoinPart<T> Subselect(string subselect)
        {
            mapping.Subselect = subselect;
            return this;
        }

        public JoinPart<T> Not
        {
            get
            {
                nextBool = !nextBool;
                return this;
            }
        }

        JoinMapping IJoinMappingProvider.GetJoinMapping()
        {
            mapping.ContainingEntityType = typeof(T);

            foreach (var property in properties)
                mapping.AddProperty(property.GetPropertyMapping());

            foreach (var component in components)
                mapping.AddComponent(component.GetComponentMapping());

            foreach (var reference in references)
                mapping.AddReference(reference.GetManyToOneMapping());

            foreach (var any in anys)
                mapping.AddAny(any.GetAnyMapping());

            foreach (var column in columns)
                mapping.Key.AddColumn(new ColumnMapping { Name = column });

            return mapping;
        }
    }
}
