using System;
using System.Collections.Generic;
using System.Text;

namespace ADE.Domain.Models
{
    public class PertInput
    {
        private double _optimistic;
        public double Optimistic
        {
            get => _optimistic; 
            set => _optimistic = value; 
        }

        private double _pessimistic;
        public double Pessimistic
        {
            get => _pessimistic;
            set => _pessimistic = value;
        }

        private double _neutral;
        public double Neutral
        {
            get => _neutral;
            set => _neutral = value;
        }

        public PertInput()
        {
        }

        public PertInput(double optimistic, double pessimistic, double neutral)
        {
            Optimistic = optimistic;
            Pessimistic = pessimistic;
            Neutral = neutral;
        }
    }
}
