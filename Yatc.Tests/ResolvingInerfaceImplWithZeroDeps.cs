using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingInterfaceImplementationWithNoDependency
    {
        private Container _container;

        private interface IInterface {}

        private class Class : IInterface {}

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container().Register<IInterface, Class>();
        }

        [Test]
        public void ObjectResolved()
        {
            var resolvedObj = _container.Resolve<IInterface>();
            Assert.IsInstanceOf<Class>(resolvedObj);
        }
    }
}