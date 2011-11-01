using System.Collections.Generic;
using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingNestedCircular
    {
        private Container _container;
        private CircularReferenceException _ex = null;

        private class Foo
        {
            public Foo(Bar bar) {}
        }

        private class Bar
        {
            public Bar(Fizz fizz) {}
        }

        private class Fizz
        {
            public Fizz(Buzz buzz) {}
        }

        private class Buzz
        {
            public Buzz(Bar bar) {}
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container()
                .Register<Foo, Foo>()
                .Register<Bar, Bar>()
                .Register<Fizz, Fizz>()
                .Register<Buzz, Buzz>();

            try
            {
                _container.Resolve<Foo>();
            }
            catch (CircularReferenceException ex)
            {
                _ex = ex;
            }
        }

        [Test]
        public void CircularReferenceExceptionThrown()
        {
            Assert.IsNotNull(_ex);
        }

        [Test]
        public void RootTypeCorrect()
        {
            Assert.AreEqual(typeof (Foo), _ex.RootType);
        }

        [Test]
        public void SubjectTypeCorrect()
        {
            Assert.AreEqual(typeof (Bar), _ex.SubjectType);
        }
    }
}