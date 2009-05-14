using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace FluentNHibernate.Conventions.Ordering
{
    public class OrderNode
    {
        private readonly Set<OrderNode> dependencies = new HashedSet<OrderNode>();
        private readonly Set<OrderNode> dependents = new HashedSet<OrderNode>();
        private readonly IOrderableConvention convention;

        public OrderNode(IOrderableConvention convention)
        {
            this.convention = convention;
        }

        public IEnumerable<OrderNode> Dependencies
        {
            get { return dependencies; }
        }

        public IEnumerable<OrderNode> Dependents
        {
            get { return dependents; }
        }

        public IOrderableConvention Convention
        {
            get { return convention; }
        }

        public bool HasDependencies
        {
            get { return !dependencies.IsEmpty; }
        }

        public bool HasDependents
        {
            get { return !dependents.IsEmpty; }
        }

        public void AddDependency(OrderNode node)
        {
            AddDependency(node, true);
        }

        public void AddDependency(OrderNode node, bool createInverse)
        {
            dependencies.Add(node);
            if (createInverse)
                node.AddDependent(this, false);
        }

        public void RemoveDependency(OrderNode node)
        {
            dependencies.Remove(node);
        }

        public void AddDependent(OrderNode node)
        {
            AddDependent(node, true);
        }

        public void AddDependent(OrderNode node, bool createInverse)
        {
            dependents.Add(node);
            if (createInverse)
                node.AddDependency(this, false);
        }

        public void RemoveDependent(OrderNode node)
        {
            dependents.Remove(node);
            node.RemoveDependency(this);
        }
    }
}
