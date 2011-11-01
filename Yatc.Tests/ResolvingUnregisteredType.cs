using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingUnregisteredType
    {
        [Test]
        public void NotRegisteredExceptionThrown()
        {
            Assert.Throws<NotRegisteredException>(() => new Container().Resolve<object>());
        }
    }
}