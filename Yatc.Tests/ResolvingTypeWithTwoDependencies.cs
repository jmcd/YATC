using NUnit.Framework;

namespace Yatc.Tests
{
    [TestFixture]
    public class ResolvingTypeWithTwoDependencies
    {
        private Foobar _resolution;

        public class Foobar
        {
            public readonly Foo Foo;
            public readonly Bar Bar;

            public Foobar(Foo foo, Bar bar)
            {
                Foo = foo;
                Bar = bar;
            }
        }

        public class Foo{}

        public class Bar {}

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            _resolution = new Container()
                .Register<Foobar, Foobar>()
                .Register<Foo, Foo>()
                .Register<Bar, Bar>()
                .Resolve<Foobar>();
        }

        [Test]
        public void FirstDependencyInjected()
        {
            Assert.IsNotNull(_resolution.Foo);
        }

        [Test]
        public void SecondDependencyInjected()
        {
            Assert.IsNotNull(_resolution.Bar);
        }
    }
}