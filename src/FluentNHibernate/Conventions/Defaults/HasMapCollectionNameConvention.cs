using FluentNHibernate.Mapping;

namespace FluentNHibernate.Conventions.Defaults
{
    public class HasMapCollectionNameConvention : IMapConvention
    {
        public bool Accept(IMapCollectionPart target)
        {
            return string.IsNullOrEmpty(target.CollectionColumnName);
        }

        public void Apply(IMapCollectionPart target)
        {
            target.WithCollectionColumn(target.ValueType.Name + "_id");
        }
    }
}
