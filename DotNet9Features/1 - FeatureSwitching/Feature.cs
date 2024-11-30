using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9Features.FeatureSwitching
{
    internal class Feature
    {
        [FeatureSwitchDefinition("Feature.IsEnabled")]
        private static bool IsFeatureEnabled =>
            !AppContext.TryGetSwitch("Feature.IsEnabled", out var isEnabled) || isEnabled;

        internal static void DoTheThing()
        {
            if (IsFeatureEnabled)
                Console.WriteLine("I did the thing");
        }

    }
}
