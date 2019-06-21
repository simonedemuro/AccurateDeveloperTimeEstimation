using ADE.Domain.Models;
using ADE.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADE.Engine.Utils
{
    class DistributionManagerUtils
    {
        public static PertVM CalculateBetaDistributionAndDeviationLineItems(PertInput pertInput)
        {
            return new PertVM()
            {
                Optimistic = pertInput.Optimistic,
                Neutral = pertInput.Neutral,
                Pessimistic = pertInput.Pessimistic,
                ExpectedDurationTask = (pertInput.Optimistic + 4 * pertInput.Neutral + pertInput.Pessimistic) / 6,
                StandardDeviation = (pertInput.Pessimistic - pertInput.Optimistic) / 6 
            };
        }
    }
}
