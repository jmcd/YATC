using System.Collections.Generic;
using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingTwoSpecificTypesOfCommonOpenGeneric
    {
        private IList<string> _listOfString;
        private IList<int> _listOfInt;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var container = new Container()
                .Register<IList<string>>(() => new List<string>())
                .Register<IList<int>>(() => new List<int>());

            _listOfString = container.Resolve<IList<string>>();
            _listOfInt = container.Resolve<IList<int>>();
        }

        [Test]
        public void FirstTypeIsResolved()
        {
            Assert.IsNotNull(_listOfString);
        }

        [Test]
        public void SecondTypeIsResolved()
        {
            Assert.IsNotNull(_listOfInt);
        }
    }
}