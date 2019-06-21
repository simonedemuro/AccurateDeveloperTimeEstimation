using ADE.Domain.Models;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            PertInput p = new PertInput()
            {
                Optimistic = 1,
                Neutral = 2,
                Pessimistic = 5
            };
            Assert.Pass();
        }
    }
}