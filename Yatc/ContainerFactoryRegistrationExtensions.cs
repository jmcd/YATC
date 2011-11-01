using System;

namespace Yatc
{
    public static class ContainerFactoryResolutionStrategyExtensions
    {
        public static Container Register<TRequestType>(this Container @this, Func<object> func, Lifestyle lifestyle)
        {
            @this.AddResolutionStrategy<TRequestType>(new FactoryResolutionStrategy(func, lifestyle));
            return @this;
        }

        public static Container Register<TRequestType>(this Container @this, Func<object> func)
        {
            return Register<TRequestType>(@this, func, Configuration.DefaultLifeStyle);
        }
    }
}