using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions.Alterations;
using FluentNHibernate.MappingModel.Collections;
using NUnit.Framework;

namespace FluentNHibernate.Testing.ConventionsTests.Alterations
{
    [TestFixture, Category("Alteration DSL")]
    public class OneToManyAlterationTests
    {
        private OneToManyMapping mapping;
        private OneToManyAlteration alteration;

        [SetUp]
        public void CreateDsl()
        {
            mapping = new OneToManyMapping();
            alteration = new OneToManyAlteration(mapping);
        }

        [Test]
        public void NotFoundIgnoreShouldSetModelValue()
        {
            mapping.NotFound.ShouldBeNull();

            alteration.NotFound.Ignore();

            mapping.NotFound.ShouldEqual("ignore");
        }

        [Test]
        public void NotFoundExceptionShouldSetModelValue()
        {
            mapping.NotFound.ShouldBeNull();

            alteration.NotFound.Exception();

            mapping.NotFound.ShouldEqual("exception");
        }
    }
}
