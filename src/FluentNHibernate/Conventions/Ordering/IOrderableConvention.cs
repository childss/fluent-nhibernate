
namespace FluentNHibernate.Conventions.Ordering
{
    public interface IOrderableConvention : IConvention
    {
        void Order(ConventionOrder order);
    }
}
