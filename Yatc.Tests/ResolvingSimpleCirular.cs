using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingSimpleCircular
    {
        private Container _container;

        private class Foo
        {
            public Foo(Foo foo) {}
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container().Register<Foo, Foo>();
        }

        [Test]
        public void CircularReferenceExceptionThrown()
        {
            Assert.Throws<CircularReferenceException>(() => _container.Resolve<Foo>());
        }
    }
}