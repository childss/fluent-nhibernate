using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHibernate.Mapping
{
    public interface IMapCollectionPart : IMappingPart
    {
        Type EntityType { get; }
        Type IndexType { get; }
        Type ValueType { get; }
        string TableName { get; }
        string IndexColumnName { get; }
        string CollectionColumnName { get; }
        IMapCollectionPart WithTableName(string name);
        IMapCollectionPart WithIndexColumn(string name);
        IMapCollectionPart WithCollectionColumn(string name);
        IColumnNameCollection KeyColumnNames { get; }
    }
}
