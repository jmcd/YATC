using System;

namespace Yatc
{
    public interface IResolutionStrategy
    {
        object Resolve(Func<Type, object> dependencyResolver);
        Lifestyle Lifestyle { get; }
    }
}