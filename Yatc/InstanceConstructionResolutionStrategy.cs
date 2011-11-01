using System;
using System.Linq;

namespace Yatc
{
    public class InstanceConstructionResolutionStrategy : IResolutionStrategy
    {
        private readonly Type _classType;
        public Lifestyle Lifestyle { get; private set; }

        public InstanceConstructionResolutionStrategy(Type classType, Lifestyle lifestyle)
        {
            Lifestyle = lifestyle;
            _classType = classType;
        }

        public object Resolve(Func<Type, object> dependencyResolver)
        {
            var constructorInfo = _classType.GetConstructors().Single();

            var parameterInfos = constructorInfo.GetParameters();
            var parameters = new object[parameterInfos.Length];
            for (var i = 0; i < parameterInfos.Length; i++)
            {
                parameters[i] = dependencyResolver(parameterInfos[i].ParameterType);
            }

            var result = constructorInfo.Invoke(parameters);

            return result;
        }
    }
}