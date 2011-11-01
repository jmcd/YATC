using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class MakeTwoRequestsForSingleton
    {
        private Foo _firstResolution;
        private Foo _secondResolution;

        private class Foo {}

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var container = new Container().Register<Foo, Foo>(Lifestyle.Singleton);
            _firstResolution = container.Resolve<Foo>();
            _secondResolution = container.Resolve<Foo>();
        }

        [Test]
        public void BothInstancesReferenceEqual()
        {
            Assert.AreSame(_firstResolution, _secondResolution);
        }
    }
}