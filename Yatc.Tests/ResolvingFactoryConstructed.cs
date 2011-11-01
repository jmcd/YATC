using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingFactoryConstructed
    {
        private string _resolution;
        private const string Message = "Hello world!";

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _resolution = new Container().Register<string>(() => Message).Resolve<string>();
        }

        [Test]
        public void FactoryConstructedObjectResolved()
        {
            Assert.AreEqual(Message, _resolution);
        }
    }
}