namespace FluentNHibernate.Mapping
{
	public interface IKeyPart
	{
		KeyColumnCollection Columns { get; }
		IKeyPart PropertyRef(string value);
	}
}