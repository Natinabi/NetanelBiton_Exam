using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestRating.Interfaces;

namespace TestRating.Services
{
    /// <summary>
    /// This factory contains all Policy Rating interface and services,  to get specific service in O(1) complexity
    /// </summary>
    public class PolicyRatingFactory
    {
        private readonly IDictionary<PolicyType, IPolicyRating> dictionary;

        public PolicyRatingFactory(IEnumerable<IPolicyRating> services)
        {
            dictionary = services.ToDictionary(i => i.policyType, i => i);
        }

        public IPolicyRating GetPolicyRatingByPolicyType(PolicyType type)
        {
            return dictionary[type];
        }
    }
}
