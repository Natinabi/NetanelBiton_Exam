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

            Policy policy = new TravelPolicy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                Country = "Argentina",
                Days = -1
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var travel = new TravelPolicyRating(logger);

                //Act 

                travel.Rate(policy);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDaysMoreThen180()
        {
            //Arrange

            Policy policy = new TravelPolicy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                Country = "Argentina",
                Days = 200
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var travel = new TravelPolicyRating(logger);

                //Act + Assert

                travel.Rate(policy);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDaysWithoutCountry()
        {
            //Arrange

            Policy policy = new TravelPolicy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                Country = "",
                Days = 10
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var travel = new TravelPolicyRating(logger);

                //Act 

                travel.Rate(policy);
            }

        }
        [TestMethod]
        public void RateForItaly()
        {
            //Arrange

            TravelPolicy policy = new TravelPolicy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                Country = "Italy",
                Days = 10
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

            TravelPolicy policy = new TravelPolicy
            {
                Type = PolicyType.Travel,
                FullName = "Israel",
                Country = "Argentina",
                Days = 10
            };

            decimal expected = policy.Days * 2.5m;
            var logger = new PLogger();
            var travel = new TravelPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, travel.Rate(policy));
        }
    }
}
