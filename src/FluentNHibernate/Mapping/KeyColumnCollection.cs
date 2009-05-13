using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernate.Mapping
{
	public class KeyColumnCollection : IColumnNameCollection
	{
		private readonly IList<string> columnNames = new List<string>();

        public KeyColumnCollection Add(string name)
        {
            columnNames.Add(name);
            return this;
        }

        void IColumnNameCollection.Add(string name)
        {
            Add(name);
        }

		public KeyColumnCollection Add(params string[] names)
        {
            foreach (var name in names)
            {
                Add(name);
            }
            return this;
        }

        void IColumnNameCollection.Add(params string[] names)
        {
            Add(names);
        }

		public KeyColumnCollection Clear()
        {
            columnNames.Clear();
            return this;
        }

        void IColumnNameCollection.Clear()
        {
            Clear();
        }

        public IList<string> List()
        {
            return new List<string>(columnNames).AsReadOnly();
        }
	}
}
