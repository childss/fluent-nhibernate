using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Alterations
{
    public class NotFoundAlteration<TRelationship> : INotFoundAlteration where TRelationship : ICollectionRelationshipMapping
    {
        private readonly ICollectionRelationshipMapping<TRelationship> mapping;

        public NotFoundAlteration(ICollectionRelationshipMapping<TRelationship> mapping)
        {
            this.mapping = mapping;
        }

        public void Ignore()
        {
            mapping.Attributes.Set(x => x.NotFound, "ignore");
        }

        public void Exception()
        {
            mapping.Attributes.Set(x => x.NotFound, "exception");
        }
    }
}
