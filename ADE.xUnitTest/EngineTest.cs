using ADE.Domain.Models;
using ADE.Engine;
using System;
using System.Collections.Generic;
using Xunit;

namespace ADE.xUnitTest
{
    public class EngineTest
    {
        [Fact]
        public void Test1()
        {
            List<PertInput> pertInputs = new List<PertInput>()
            {
                new PertInput()
                {
                    Optimistic = 1,
                    Neutral = 3,
                    Pessimistic = 12
                },
                new PertInput()
                {
                    Optimistic = 1,
                    Neutral = 1.5,
                    Pessimistic = 14
                },
                new PertInput()
                {
                    Optimistic = 3,
                    Neutral = 6.25,
                    Pessimistic = 11
                }
            };

            DistributionManager distributionManager = new DistributionManager(pertInputs);
            double odds = distributionManager.LikelihoodCompleteWithinDays(15);

            Assert.True(differenceNotExcedesTolerance(odds,60,1));

        }

        private static bool differenceNotExcedesTolerance(double odds, double expectedVal, double tollerance)
        {
            return Math.Abs(expectedVal - odds) < tollerance;
        }
    }
}
