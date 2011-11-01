using System;

namespace Yatc
{
    public class FactoryResolutionStrategy : IResolutionStrategy
    {
        public Lifestyle Lifestyle { get; private set; }
        private readonly Func<object> _func;

        public FactoryResolutionStrategy(Func<object> func, Lifestyle lifestyle)
        {
            Lifestyle = lifestyle;
            _func = func;
        }

        public object Resolve(Func<Type, object> dependencyResolver)
        {
            return _func();
        }
    }
}