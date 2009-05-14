using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using System.Xml;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Mapping
{
    public class MapCollectionPart<TIndex, TValue> : IMapCollectionPart
    {
        private Type entityType;
        private MemberInfo member;
        private IIndexMapping indexMapping;
        private Cache<string, string> properties = new Cache<string, string>();
        private ColumnNameCollection<MapCollectionPart<TIndex, TValue>> columnNames;
        private Cache<string, string> keyProperties = new Cache<string, string>();
        private string tableName;
        private string indexColumnName;
        private string collectionColumnName;

        public MapCollectionPart(Type entityType, MemberInfo member)
        {
            this.entityType = entityType;
            this.member = member;
            properties.Store("name", member.Name);
            columnNames = new ColumnNameCollection<MapCollectionPart<TIndex, TValue>>(this);
        }

        public Type EntityType
        {
            get { return entityType; }
        }

        public Type IndexType
        {
            get { return typeof(TIndex); }
        }
        public Type ValueType
        {
            get { return typeof(TValue); }
        }

        public MemberInfo Member
        {
            get { return member; }
        }

        public string TableName
        {
            get { return tableName; }
        }

        public string IndexColumnName
        {
            get { return indexColumnName; }
        }

        public string CollectionColumnName
        {
            get { return collectionColumnName; }
        }

        public ColumnNameCollection<MapCollectionPart<TIndex, TValue>> KeyColumNames
        {
            get { return columnNames; }
        }

        public MapCollectionPart<TIndex, TValue> WithTableName(string name)
        {
            tableName = name;
            return this;
        }

        public MapCollectionPart<TIndex, TValue> WithIndexColumn(string name)
        {
            indexColumnName = name;
            return this;
        }

        public MapCollectionPart<TIndex, TValue> WithCollectionColumn(string name)
        {
            collectionColumnName = name;
            return this;
        }

        IColumnNameCollection IMapCollectionPart.KeyColumnNames
        {
            get { return KeyColumNames; }
        }

        IMapCollectionPart IMapCollectionPart.WithTableName(string name)
        {
            return WithTableName(name);
        }

        IMapCollectionPart IMapCollectionPart.WithIndexColumn(string name)
        {
            return WithIndexColumn(name);
        }

        IMapCollectionPart IMapCollectionPart.WithCollectionColumn(string name)
        {
            return WithCollectionColumn(name);
        }

        private void WriteKeyElement(IMappingVisitor visitor, XmlElement collectionElement)
        {
            var columns = columnNames.List();

            if (columns.Count == 1)
                keyProperties.Store("column", columns[0]);

            var key = collectionElement.AddElement("key")
                .WithProperties(keyProperties);

            if (columns.Count <= 1) return;

            foreach (var columnName in columns)
            {
                key.AddElement("column")
                    .WithAtt("name", columnName);
            }
        }

        #region IMappingPart Members

        public void Write(XmlElement classElement, IMappingVisitor visitor)
        {
            XmlElement mapElement = classElement.AddElement("map").WithProperties(properties);

            if (!string.IsNullOrEmpty(TableName))
                mapElement.WithAtt("table", TableName);

            WriteKeyElement(visitor, mapElement);

            indexMapping = IndexMappingBase.GetIndexMappingTypeFor<TIndex>();
            if (!string.IsNullOrEmpty(IndexColumnName))
                indexMapping.WithColumn(IndexColumnName);
            indexMapping.WithType(typeof(TIndex));
            indexMapping.WriteIndexElement(mapElement);

            var collection = "many-to-many";
            var collectionType = "class";
            var collectionTypeValue = typeof(TValue).AssemblyQualifiedName;
            if (typeof(TValue).IsPrimitive || typeof(TValue) == typeof(string))
            {
                collection = "element";
                collectionType = "type";
                collectionTypeValue = typeof(TValue).Name;
            }

            var collectionElement = mapElement.AddElement(collection);
            if (!string.IsNullOrEmpty(CollectionColumnName))
                collectionElement.WithAtt("column", CollectionColumnName);

            collectionElement.WithAtt(collectionType, collectionTypeValue);
        }

        public PartPosition PositionOnDocument
        {
            get { return PartPosition.Anywhere; }
        }

        public int LevelWithinPosition
        {
            get { return 1; }
        }

        #endregion

        #region IHasAttributes Members

        public void SetAttribute(string name, string value)
        {
            properties.Store(name, value);
        }

        public void SetAttributes(Attributes atts)
        {
            foreach (var key in atts.Keys)
            {
                SetAttribute(key, atts[key]);
            }
        }

        #endregion
    }
}
