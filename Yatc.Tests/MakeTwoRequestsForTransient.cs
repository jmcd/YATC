using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class MakeTwoRequestsForTransient
    {
        private Foo _firstResolution;
        private Foo _secondResolution;

        private class Foo {}

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var container = new Container().Register<Foo, Foo>(Lifestyle.Transient);
            _firstResolution = container.Resolve<Foo>();
            _secondResolution = container.Resolve<Foo>();
        }

        [Test]
        public void BothInstancesReferenceEqual()
        {
            Assert.AreNotSame(_firstResolution, _secondResolution);
        }
    }
}