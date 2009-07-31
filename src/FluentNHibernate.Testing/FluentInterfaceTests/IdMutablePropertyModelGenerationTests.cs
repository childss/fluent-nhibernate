using System.Linq;
using FluentNHibernate.MappingModel;
using NUnit.Framework;

namespace FluentNHibernate.Testing.FluentInterfaceTests
{
    [TestFixture]
    public class IdMutablePropertyModelGenerationTests : BaseModelFixture
    {
        [Test]
        public void AccessShouldSetModelAccessPropertyToValue()
        {
            Id()
                .Mapping(m => m.Access.Field())
                .ModelShouldMatch(x => x.Access.ShouldEqual("field"));
        }

        [Test]
        public void ColumnNameShouldAddToModelColumnsCollection()
        {
            Id()
                .Mapping(m => m.Column("col"))
                .ModelShouldMatch(x => x.Columns.Count().ShouldEqual(1));
        }

        [Test]
        public void ColumnNameShouldSetModelColumnName()
        {
            Id()
                .Mapping(m => m.Column("col"))
                .ModelShouldMatch(x => x.Columns.First().Name.ShouldEqual("col"));
        }

        [Test]
        public void ShouldSetModelNamePropertyToPropertyName()
        {
            Id()
                .Mapping(m => {})
                .ModelShouldMatch(x => x.Name.ShouldEqual("IntId"));
        }

        [Test]
        public void ShouldSetModelTypePropertyToPropertyType()
        {
            Id()
                .Mapping(m => { })
                .ModelShouldMatch(x => x.Type.ShouldEqual(new TypeReference(typeof(int))));
        }

        [Test]
        public void UnsavedValueShouldSetModelTypePropertyToPropertyType()
        {
            Id()
                .Mapping(m => m.UnsavedValue(10))
                .ModelShouldMatch(x => x.UnsavedValue.ShouldEqual("10"));
        }


        [Test]
        public void GeneratedByShouldSetModelGeneratorProperty()
        {
            Id()
                .Mapping(m => m.GeneratedBy.Assigned())
                .ModelShouldMatch(x => x.Generator.ShouldNotBeNull());
        }

        [Test]
        public void GeneratedByShouldSetModelGeneratorPropertyToValue()
        {
            Id()
                .Mapping(m => m.GeneratedBy.Assigned())
                .ModelShouldMatch(x => x.Generator.Class.ShouldEqual("assigned"));
        }

        [Test]
        public void GeneratedByWithParamsShouldSetModelGeneratorParams()
        {
            Id()
                .Mapping(m => m.GeneratedBy.Assigned(p =>
                    p.AddParam("name", "value")
                     .AddParam("another", "another-value")))
                .ModelShouldMatch(x => x.Generator.Params.Count().ShouldEqual(2));
        }

        [Test]
        public void GeneratedByWithParamsShouldSetModelGeneratorParamsValues()
        {
            Id()
                .Mapping(m => m.GeneratedBy.Assigned(p =>
                    p.AddParam("name", "value")
                     .AddParam("another", "another-value")))
                .ModelShouldMatch(x =>
                {
                    var first = x.Generator.Params.First();

                    first.Key.ShouldEqual("name");
                    first.Value.ShouldEqual("value");

                    var second = x.Generator.Params.ElementAt(1);

                    second.Key.ShouldEqual("another");
                    second.Value.ShouldEqual("another-value");
                });
        }

        public void LengthShouldSetModelLengthPropertyToValue()
        {
            Id()
                .Mapping(m => m.Length(8))
                .ModelShouldMatch(x => x.Length.ShouldEqual(8));
        }
    }
}