using Microsoft.Extensions.Logging;
using System;
using TestRating.Interfaces;
using TestRating.Model;

namespace TestRating.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class LifePolicyRating : IPolicyRating
    {
        private readonly IPLogger _logger;
        private decimal Rating;
        public PolicyType policyType
        {
            get { return PolicyType.Life; }
        }
        public LifePolicyRating( IPLogger logger)
        {
            _logger = logger;
        }

        public decimal Rate(Policy policy)
        {
            _logger.LogInformation("Rating LIFE policy...");
           
            int age = GetAge(policy.DateOfBirth);

            if (IsValidPolicy(policy))
            {
                decimal baseRate = policy.Amount * age / 200;

                if (policy.IsSmoker)
                {
                    Rating = baseRate * 2;
                }
                Rating = baseRate;
            }
            return Rating;
        }
        public bool IsValidPolicy(Policy policy)
        {
            _logger.LogInformation("Validating policy.");

            int age = GetAge(policy.DateOfBirth);

            if (policy.DateOfBirth == DateTime.MinValue)
            {
                throw new Exception("Life policy must include Date of Birth.");
            }
            if (age > 100)
            {
                throw new Exception("Max eligible age for coverage is 100 years.");
            }
            if (policy.Amount == 0)
            {
                throw new Exception("Life policy must include an Amount.");
            }

            _logger.LogInformation("End Validating policy.");

            return true;

        }
        private int GetAge(DateTime DateOfBirth)
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }
            return age;
        }
    }
}
