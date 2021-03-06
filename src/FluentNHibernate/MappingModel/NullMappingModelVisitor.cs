using System;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.MappingModel.Collections;
using FluentNHibernate.MappingModel.Identity;

namespace FluentNHibernate.MappingModel
{
    public abstract class NullMappingModelVisitor : IMappingModelVisitor
    {
        public virtual void ProcessId(IdMapping idMapping)
        {

        }

        public virtual void ProcessCompositeId(CompositeIdMapping idMapping)
        {

        }

        public virtual void ProcessClass(ClassMapping classMapping)
        {

        }

        public virtual void ProcessImport(ImportMapping importMapping)
        {
            
        }

        public virtual void ProcessHibernateMapping(HibernateMapping hibernateMapping)
        {

        }

        public virtual void ProcessProperty(PropertyMapping propertyMapping)
        {

        }

        public virtual void ProcessManyToOne(ManyToOneMapping manyToOneMapping)
        {

        }

        public virtual void ProcessKey(KeyMapping keyMapping)
        {

        }

        public virtual void ProcessIdGenerator(IdGeneratorMapping generatorMapping)
        {

        }

        public virtual void ProcessColumn(ColumnMapping columnMapping)
        {

        }

        public virtual void ProcessBag(BagMapping bagMapping)
        {

        }

        public virtual void ProcessOneToMany(OneToManyMapping oneToManyMapping)
        {

        }

        public virtual void ProcessManyToMany(ManyToManyMapping manyToManyMapping)
        {
            
        }

        public virtual void ProcessSet(SetMapping setMapping)
        {

        }

        public virtual void ProcessJoinedSubclass(JoinedSubclassMapping subclassMapping)
        {

        }

        public virtual void ProcessSubclass(SubclassMapping subclassMapping)
        {

        }

        public virtual void ProcessDiscriminator(DiscriminatorMapping discriminatorMapping)
        {
            
        }

        public virtual void ProcessComponent(ComponentMappingBase componentMapping)
        {
            
        }

        public virtual void ProcessList(ListMapping listMapping)
        {
            
        }

        public virtual void ProcessJoin(JoinMapping joinMapping)
        {

        }

        public virtual void ProcessIndex(IndexMapping indexMapping)
        {
            
        }

        public virtual void ProcessParent(ParentMapping parentMapping)
        {
            
        }

        public virtual void Visit(ClassMapping classMapping)
        {

        }

        public virtual void Visit(ImportMapping importMapping)
        {

        }

        public virtual void Visit(IIdentityMapping identityMapping)
        {

        }

        public virtual void Visit(ICollectionMapping collectionMapping)
        {

        }

        public virtual void Visit(PropertyMapping propertyMapping)
        {

        }

        public virtual void Visit(ManyToOneMapping manyToOneMapping)
        {

        }

        public virtual void Visit(KeyMapping keyMapping)
        {

        }

        public virtual void Visit(ICollectionContentsMapping contentsMapping)
        {

        }

        public virtual void Visit(IdGeneratorMapping generatorMapping)
        {

        }

        public virtual void Visit(ColumnMapping columnMapping)
        {

        }

        public virtual void Visit(ISubclassMapping subclassMapping)
        {

        }

        public virtual void Visit(JoinedSubclassMapping subclassMapping)
        {

        }

        public virtual void Visit(SubclassMapping subclassMapping)
        {
            
        }

        public virtual void Visit(DiscriminatorMapping discriminatorMapping)
        {
            
        }

        public virtual void Visit(ComponentMappingBase componentMapping)
        {
            
        }

        public virtual void Visit(IndexMapping indexMapping)
        {
            
        }
        public virtual void Visit(ParentMapping parentMapping)
        {
            
        }

        public virtual void Visit(JoinMapping joinMapping)
        {
            
        }
    }
}
