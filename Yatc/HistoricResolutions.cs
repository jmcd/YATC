using System.Collections.Generic;

namespace Yatc
{
    public class HistoricResolutions
    {
        private readonly IDictionary<IResolutionStrategy, object> _history = new Dictionary<IResolutionStrategy, object>();

        public bool TryGet(IResolutionStrategy resolutionStrategy, out object resolution)
        {
            if (_history.ContainsKey(resolutionStrategy))
            {
                resolution = _history[resolutionStrategy];
                return true;
            }
            resolution = null;
            return false;
        }

        public void TryPut(IResolutionStrategy resolutionStrategy, object resolution)
        {
            if (resolutionStrategy.Lifestyle == Lifestyle.Singleton) _history[resolutionStrategy] = resolution;
        }
    }
}