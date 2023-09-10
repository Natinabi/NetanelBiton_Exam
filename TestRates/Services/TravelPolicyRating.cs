using Microsoft.Extensions.Logging;
using System;
using TestRating.Interfaces;
using TestRating.Model;

namespace TestRating.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TravelPolicyRating : IPolicyRating
    {
        private readonly IPLogger _logger;
        private decimal Rating;
        public PolicyType policyType
        {
            get { return PolicyType.Travel; }
        }

        public TravelPolicyRating(IPLogger logger)
        {
            _logger = logger;
        }

        public decimal Rate(Policy policy)
        {
            _logger.LogInformation("Rating TRAVEL policy...");

            if (IsValidPolicy(policy))
            {
                Rating = policy.Days * 2.5m;

                if (policy.Country == ExceptionalCountries.Italy.ToString())
                {
                    Rating *= 3;
                }
            }
            return Rating;

        }
        public bool IsValidPolicy(Policy policy)
        {
            _logger.LogInformation("Start Validating policy.");

            if (policy.Days <= 0)
            {
                throw new Exception("Travel policy must specify Days.");
            }

            if (policy.Days > 180)
            {
                throw new Exception("Travel policy cannot be more then 180 Days.");
            }

            if (string.IsNullOrEmpty(policy.Country))
            {
                throw new Exception("Travel policy must specify country.");
            }

            _logger.LogInformation("Start Validating policy.");

            return true;

        }
    }
}
