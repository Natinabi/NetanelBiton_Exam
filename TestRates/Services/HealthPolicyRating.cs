using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TestRating.Interfaces;
using TestRating.Model;

namespace TestRating.Services
{
    /// <summary>
    /// Calculate and Validate Policy Type : Health
    /// </summary>
    public class HealthPolicyRating : IPolicyRating
    {
        private readonly IPLogger _logger;
        private decimal Rating;

        public PolicyType policyType
        {
            get { return PolicyType.Health; }
        }

        public HealthPolicyRating( IPLogger logger)
        {
            _logger = logger;
        }

        public decimal Rate(Policy policy)
        {
            _logger.LogInformation("Rating Health policy...");

            if (IsValidPolicy(policy))
            {
                if (policy.Gender == Gender.Male.ToString())
                {

                    if (policy.Deductible < 500)
                    {
                        Rating = 1000m;
                    }
                    else
                    {
                        Rating = 900m;
                    }
                }
                else
                {
                    if (policy.Deductible < 800)
                    {
                        Rating = 1100m;
                    }
                    else
                    {
                        Rating = 1000m;
                    }
                }
            }
            return Rating;
        }

        public bool IsValidPolicy(Policy policy)
        {
            _logger.LogInformation("Start Validating policy.");

            if (string.IsNullOrEmpty(policy.Gender))
            {
                throw new Exception("Health policy must specify Gender");
            }

            _logger.LogInformation("End Validating policy.");

            return true;
        }
    }
}
