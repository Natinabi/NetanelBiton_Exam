using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestRating;
using TestRating.Services;
using TestRating.Model;
using TestRating.Interfaces;

namespace Tests
{
    [TestClass]
    public class HealthRateTest
    {

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void CalcHealthRateWithoutGender()
        {
            //Arrange
            
            Policy policy = new HealthPolicy { 
                Type= PolicyType.Health,
                FullName = "Israel", 
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "",
                Deductible= 0 
            };

            if (ValidatePolicy.IsValidPolicy(policy))
            {
                var logger = new PLogger();
                var healt = new HealthPolicyRating(logger);
           
           
            //Act
            healt.Rate(policy);
            }
        }

        [TestMethod]
        public void RateForMaleWithDeductibleLessThen500()
        {
            //Arrange
            decimal expected = 1000m;
            
            Policy policy = new HealthPolicy
            {
                Type = PolicyType.Health,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "Male",
                Deductible = 300
            };
            var logger = new PLogger();
            var healt = new HealthPolicyRating(logger);

            //Act + Assert
             Assert.AreEqual(expected, healt.Rate(policy));
        }
      
        [TestMethod]
        public void RateForMaleWithDeductibleMoreThenEqual500()
        {
            //Arrange
            decimal expected = 900m;
            
            Policy policy = new HealthPolicy
            {
                Type = PolicyType.Health,
                FullName = "Israel",
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "Male",
                Deductible = 500
            };
            var logger = new PLogger();
            var healt = new HealthPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, healt.Rate(policy));
        }
       
        [TestMethod]
        public void RateForFeMaleWithDeductibleLessThen800()
        {
            //Arrange
            decimal expected = 1100m;
            
            Policy policy = new HealthPolicy { Type = PolicyType.Health, FullName = "Israel", DateOfBirth = new DateTime(2000, 1, 1), Gender = "FeMale", Deductible = 500 };

            var logger = new PLogger();
            var healt = new HealthPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, healt.Rate(policy));
        }
        
        [TestMethod]
        public void RateForFeMaleWithDeductibleMoreThen800()
        {
            //Arrange
            decimal expected = 1000m;
            
            Policy policy = new HealthPolicy { Type = PolicyType.Health, FullName = "Israel", DateOfBirth = new DateTime(2000, 1, 1), Gender = "FeMale", Deductible = 900 };

            var logger = new PLogger();
            var healt = new HealthPolicyRating(logger);

            //Act + Assert
            Assert.AreEqual(expected, healt.Rate(policy));
        }
    }
}
