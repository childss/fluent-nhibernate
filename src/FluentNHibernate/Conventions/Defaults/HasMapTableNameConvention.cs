using FluentNHibernate.Mapping;

namespace FluentNHibernate.Conventions.Defaults
{
    class HasMapTableNameConvention : IMapConvention
    {
        public bool Accept(IMapCollectionPart target)
        {
            return string.IsNullOrEmpty(target.TableName);
        }

        public void Apply(IMapCollectionPart target)
        {
            target.WithTableName(target.EntityType.Name + "To" + target.ValueType.Name);
        }
    }
}
