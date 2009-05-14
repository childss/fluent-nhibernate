using System;
using System.Xml;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Mapping
{
    public class IndexMappingBase : IIndexMapping
    {
        protected Cache<string, string> properties = new Cache<string, string>();
        protected string indexElementName;
        protected string indexType;

        public IndexMappingBase()
            : this("type", "index")
        {
            
        }

        public IndexMappingBase(string indexType, string indexElementName)
        {
            this.indexType = indexType;
            this.indexElementName = indexElementName;
        }

        #region IIndexMapping Members

        public IIndexMapping WithColumn(string columnName)
        {
            properties.Store("column", columnName);
            return this;
        }

        public IIndexMapping WithType<TIndex>()
        {
            return WithType(typeof(TIndex));
        }

        public IIndexMapping WithType(Type type)
        {
            properties.Store(indexType, (indexType == "type") ? type.Name : type.AssemblyQualifiedName);
            return this;
        }

        public void WriteIndexElement(XmlElement collectionElement)
        {
            var indexElement = collectionElement.AddElement(indexElementName);
            indexElement.WithProperties(properties);
        }

        public static IIndexMapping GetIndexMappingTypeFor<TIndex>()
        {
            return (typeof(TIndex).IsPrimitive || typeof(TIndex) == typeof(string))
                ? new IndexMappingBase()
                : new IndexMappingBase("class", "index-many-to-many");
        }

        #endregion
    }
}
