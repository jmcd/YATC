using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingInterfaceImplementationWithDependency
    {
        private Container _container;

        private interface IInterface {}

        private class ClassWithDep : IInterface
        {
            public ClassWithoutDep Dep { get; set; }

            public ClassWithDep(ClassWithoutDep dep)
            {
                Dep = dep;
            }
        }

        private class ClassWithoutDep {}

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _container = new Container()
                .Register<IInterface, ClassWithDep>()
                .Register<ClassWithoutDep, ClassWithoutDep>();
        }

        [Test]
        public void ObjectResolved()
        {
            var resolvedObj = _container.Resolve<IInterface>();
            Assert.IsInstanceOf<ClassWithDep>(resolvedObj);
        }
    }
}