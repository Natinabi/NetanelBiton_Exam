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
            var tPolicy = (TravelPolicy)policy;
           
            Rating = tPolicy.Days * 2.5m;

            if (tPolicy.Country == ExceptionalCountries.Italy.ToString())
            {
                Rating *= 3;
            }
           
            return Rating;

        }
    }
}
