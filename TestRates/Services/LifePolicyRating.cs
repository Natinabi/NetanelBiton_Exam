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

            var lPolicy = (LifePolicy)policy;
            int age = ValidatePolicy.GetAge(policy.DateOfBirth);

            decimal baseRate = lPolicy.Amount * age / 200;

            if (lPolicy.IsSmoker)
            {
                Rating = baseRate * 2;
            }
            Rating = baseRate;
          
            return Rating;
        }
      
    }
}
