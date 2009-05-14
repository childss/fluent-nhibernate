using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentNHibernate.Conventions.Ordering
{
    public class ConventionOrder
    {
        private readonly IConventionFinder finder;
        private Type currentType;
        private IDictionary<Type, OrderNode> conventionsIndex;

        public ConventionOrder(IConventionFinder finder)
        {
            this.finder = finder;
        }

        public void ProcessConventions()
        {
            var conventions = finder.Find<IOrderableConvention>();
            ProcessConventions(conventions);
        }

        public void ProcessConventions(IEnumerable<IOrderableConvention> conventions)
        {
            conventionsIndex = new Dictionary<Type, OrderNode>();
            foreach (var convention in conventions)
            {
                ApplyOrderFor(convention);
            }

            IEnumerable<OrderNode> nodes;
            while ((nodes = FindIndependentNodes()).Count() > 0)
            {
                foreach (var node in nodes)
                {
                    // TODO: Apply convention
                    //node.Convention.Apply(); ?

                    foreach (var dependent in node.Dependents)
                    {
                        dependent.RemoveDependency(node);
                    }
                    conventionsIndex.Remove(node.Convention.GetType());
                }
            }
        }

        private IEnumerable<OrderNode> FindIndependentNodes()
        {
            var ret = new List<OrderNode>();
            foreach (var node in conventionsIndex.Values)
            {
                if (!node.HasDependencies)
                    ret.Add(node);
            }
            return ret;
        }

        private void ApplyOrderFor(IOrderableConvention convention)
        {
            currentType = convention.GetType();
            IndexConvention(convention);
            convention.Order(this);
        }

        public ConventionOrder Before<T>() where T : IOrderableConvention
        {
            var dependent = IndexConvention(finder.Find<T>().First());
            var currentNode = conventionsIndex[currentType];
            dependent.AddDependency(currentNode);
            return this;
        }

        public ConventionOrder After<T>() where T : IOrderableConvention
        {
            var dependency = IndexConvention(finder.Find<T>().First());
            var currentNode = conventionsIndex[currentType];
            currentNode.AddDependency(dependency);
            return this;
        }

        public ConventionOrder Between<TFirst, TSecond>() where TFirst : IOrderableConvention
                                                          where TSecond : IOrderableConvention
        {
            After<TFirst>();
            Before<TSecond>();
            return this;
        }

        private OrderNode IndexConvention(IOrderableConvention convention)
        {
            if (!conventionsIndex.ContainsKey(convention.GetType()))
                conventionsIndex.Add(convention.GetType(), new OrderNode(convention));

            return conventionsIndex[convention.GetType()];
        }
    }
}
