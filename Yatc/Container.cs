using System;
using System.Collections.Generic;

namespace Yatc
{
    public class Container
    {
        private readonly IDictionary<Type, IResolutionStrategy> _resolutionStrategies = new Dictionary<Type, IResolutionStrategy>();
        private readonly HistoricResolutions _history = new HistoricResolutions();

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T), null);
        }

        private object Resolve(Type type, ResolutiuonContext parent)
        {
            if (!_resolutionStrategies.ContainsKey(type)) throw new NotRegisteredException(type);

            if (parent != null && parent.LineageContains(type)) throw new CircularReferenceException(type, parent.GetRoot().Type);

            var node = new ResolutiuonContext(parent, type);
            var resolutionStrategy = _resolutionStrategies[type];

            var result = default(object);
            if (_history.TryGet(resolutionStrategy, out result)) return result;

            result = resolutionStrategy.Resolve(dependencyType => Resolve(dependencyType, node));

            _history.TryPut(resolutionStrategy, result);

            return result;
        }

        public void AddResolutionStrategy<TRequestType>(IResolutionStrategy resolutionStrategy)
        {
            _resolutionStrategies[typeof (TRequestType)] = resolutionStrategy;
        }
    }
}