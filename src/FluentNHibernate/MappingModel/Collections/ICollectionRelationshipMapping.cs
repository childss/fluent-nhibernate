namespace FluentNHibernate.MappingModel.Collections
{
    public interface ICollectionRelationshipMapping : IMappingBase
    {
        TypeReference Class { get; }
        string NotFound { get; }
    }

    public interface ICollectionRelationshipMapping<TRelationship> : ICollectionRelationshipMapping
    {
        AttributeStore<TRelationship> Attributes { get; }
    }
}