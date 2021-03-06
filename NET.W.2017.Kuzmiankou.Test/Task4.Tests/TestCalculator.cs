﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task4.Solution;


namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {

            //Calculator calculator = new Calculator();
            
            double expected = 8.3636363;

            double actual = Calculator.CalculateAverage(values, new ICalcImplMean());

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            //Calculator calculator = new Calculator();

            double expected = 8.0;

            double actual = Calculator.CalculateAverage(values, new ICalcImplMedian());

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}