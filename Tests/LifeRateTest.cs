using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating;
using TestRating.Services;
using TestRating.Model;


namespace Tests
{
    [TestClass]
    public class LifeRateTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForDateOfBirth()
        {
            //Arrange
            
            Policy policy = new LifePolicy
            {
                Type = PolicyType.Life,
                FullName = "Israel",
                DateOfBirth = new DateTime(),
                IsSmoker = true,
                Amount = 10
               
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var life = new LifePolicyRating(logger);

                //Act
                life.Rate(policy);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForAgeOver100()
        {
            //Arrange
           
            Policy policy = new LifePolicy
            {
                Type = PolicyType.Life,
                FullName = "Israel",
                DateOfBirth = new DateTime(1920, 1, 1),
                IsSmoker = true,
                Amount = 10
               
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var life = new LifePolicyRating(logger);

                //Act
                life.Rate(policy);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void RateForAmountZero()
        {
            //Arrange

            Policy policy = new LifePolicy
            {
                Type = PolicyType.Life,
                FullName = "Israel",
                DateOfBirth = new DateTime(1920, 1, 1),
                IsSmoker = true,
                Amount = 0,
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var life = new LifePolicyRating(logger);

                //Act
                life.Rate(policy);
            }
        }
    }
}
