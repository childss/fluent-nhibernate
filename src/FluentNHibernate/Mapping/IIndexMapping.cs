using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FluentNHibernate.Mapping
{
    public interface IIndexMapping
    {
        IIndexMapping WithColumn(string columnName);
        IIndexMapping WithType<TIndex>();
        IIndexMapping WithType(Type type);
        void WriteIndexElement(XmlElement element);
    }
}
