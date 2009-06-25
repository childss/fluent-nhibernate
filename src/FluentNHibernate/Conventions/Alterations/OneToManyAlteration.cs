using FluentNHibernate.MappingModel.Collections;

namespace FluentNHibernate.Conventions.Alterations
{
    public class OneToManyAlteration : IOneToManyAlteration
    {
        private readonly OneToManyMapping mapping;

        public OneToManyAlteration(OneToManyMapping mapping)
        {
            this.mapping = mapping;
        }

        public INotFoundAlteration NotFound
        {
            get { return new NotFoundAlteration<OneToManyMapping>(mapping); }
        }
    }
}