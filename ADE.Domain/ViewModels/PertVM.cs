using System;
using System.Collections.Generic;
using System.Text;

namespace ADE.Domain.ViewModels
{
    public class PertVM
    {
        public double Optimistic { get; set; }
        public double Pessimistic { get; set; }
        public double Neutral { get; set; }
        public double ExpectedDurationTask { get; set; }
        public double StandardDeviation { get; set; }
    }
}
