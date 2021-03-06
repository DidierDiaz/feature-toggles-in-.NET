using System;
using System.Linq;

namespace FeatureToggle
{
    public class CompositeOrDecorator : IFeatureToggle
    {
        public IFeatureToggle[] WrappedToggles { get; private set; }

        public CompositeOrDecorator(params IFeatureToggle[] togglesToWrap)
        {
            if (togglesToWrap == null)
            {
                throw new ArgumentNullException("togglesToWrap");
            }

            if (!togglesToWrap.Any())
            {
                throw new ArgumentOutOfRangeException("togglesToWrap", "At least one toggle must be supplied");
            }

            WrappedToggles = togglesToWrap;
        }


        public bool FeatureEnabled
        {
            get
            {
                return WrappedToggles.Any(x => x.FeatureEnabled);                
            }
        }
    }
}