using FluentNHibernate.Mapping;

namespace FluentNHibernate.Conventions.Defaults
{
    public class HasMapIndexNameConvention : IMapConvention
    {
        public bool Accept(IMapCollectionPart target)
        {
            return string.IsNullOrEmpty(target.IndexColumnName);
        }

        public void Apply(IMapCollectionPart target)
        {
            target.WithIndexColumn(target.IndexType.Name + "_id");
        }
    }
}
