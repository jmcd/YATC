namespace Yatc
{
    public static class ContainerInstanceConstructionResolutionStrategyExtensions
    {
        public static Container Register<TRequestType, TClass>(this Container @this, Lifestyle lifestyle) where TClass : TRequestType
        {
            @this.AddResolutionStrategy<TRequestType>(new InstanceConstructionResolutionStrategy(typeof (TClass), lifestyle));
            return @this;
        }

        public static Container Register<TRequestType, TClass>(this Container @this) where TClass : TRequestType
        {
            return Register<TRequestType, TClass>(@this, Configuration.DefaultLifeStyle);
        }
    }
}