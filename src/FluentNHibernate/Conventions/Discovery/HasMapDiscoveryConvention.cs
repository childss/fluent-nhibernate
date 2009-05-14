using FluentNHibernate.Mapping;

namespace FluentNHibernate.Conventions.Discovery
{
    /// <summary>
    /// Discovers any <see cref="IJoinedSubclassConvention"/> implementations and applies them to
    /// an <see cref="IJoinedSubclass"/> instance.
    /// </summary>
    public class HasMapDiscoveryConvention : IMappingPartConvention
    {
        private readonly IConventionFinder conventionFinder;

        public HasMapDiscoveryConvention(IConventionFinder conventionFinder)
        {
            this.conventionFinder = conventionFinder;
        }

        public bool Accept(IMappingPart target)
        {
            return (target is IMapCollectionPart);
        }

        public void Apply(IMappingPart target)
        {
            var conventions = conventionFinder.Find<IMapConvention>();
            var join = (IMapCollectionPart)target;

            foreach (var convention in conventions)
            {
                if (convention.Accept(join))
                    convention.Apply(join);
            }
        }
    }
}