using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FluentNHibernate.Utils;

namespace FluentNHibernate.Mapping
{
	public class KeyPart<TChild> : IMappingPart, IKeyPart
	{
		private readonly KeyColumnCollection columnNames = new KeyColumnCollection();
		private readonly Cache<string, string> keyProperties = new Cache<string, string>();

		public KeyColumnCollection Columns
		{
			get { return columnNames; }
		}

		public KeyPart<TChild> PropertyRef(string value)
		{
			keyProperties.Store("property-ref", value);
			return this;
		}

		public void Write(XmlElement collectionElement, IMappingVisitor visitor)
		{
			var columns = columnNames.List();
			if (columns.Count == 0) return;

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

		public PartPosition PositionOnDocument
		{
			get { return PartPosition.First; }
		}

		public int LevelWithinPosition
		{
			get { return 1; }
		}

		public void SetAttribute(string name, string value)
		{
			keyProperties.Store(name, value);
		}

		public void SetAttributes(Attributes attributes)
		{
			foreach (var key in attributes.Keys)
			{
				SetAttribute(key, attributes[key]);
			}
		}

		#region IKeyPart Members

		KeyColumnCollection IKeyPart.Columns
		{
			get { return Columns; }
		}

		IKeyPart IKeyPart.PropertyRef(string value)
		{
			return PropertyRef(value);
		}

		#endregion
	}
}
