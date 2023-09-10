using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating;
using TestRating.Services;
using TestRating.Model;


namespace Tests
{
    [TestClass]
    public class TravelRateTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDaysLessThenOrEqual0()
        {
            //Arrange

            Policy policy = new Policy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsSmoker = true,
                Amount = 0,
                Country = "Argentina",
                Days = -1,
                Gender = "Male",
                Deductible = 0
            };

            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act 

            travel.Rate(policy);
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDaysMoreThen180()
        {
            //Arrange

            Policy policy = new Policy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsSmoker = true,
                Amount = 10,
                Country = "Argentina",
                Days = 200,
                Gender = "Male",
                Deductible = 0
            };
            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act + Assert

            travel.Rate(policy);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDaysWithoutCountry()
        {
            //Arrange

            Policy policy = new Policy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsSmoker = true,
                Amount = 10,
                Country = "",
                Days = 10,
                Gender = "Male",
                Deductible = 0
            };

            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act 

            travel.Rate(policy);

        }
        [TestMethod]
        public void RateForItaly()
        {
            //Arrange

            Policy policy = new Policy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsSmoker = true,
                Amount = 10,
                Country = "Italy",
                Days = 10,
                Gender = "Male",
                Deductible = 0
            };

            decimal expected = policy.Days * 2.5m * 3;

            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, travel.Rate(policy));
        }
        [TestMethod]
        public void RateForAllCountryExceptItaly()
        {
            //Arrange

            Policy policy = new Policy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsSmoker = true,
                Amount = 10,
                Country = "Argentina",
                Days = 10,
                Gender = "Male",
                Deductible = 0
            };

            decimal expected = policy.Days * 2.5m;
            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, travel.Rate(policy));
        }
    }
}
