using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using TestRating.Interfaces;
using System.IO;
using System;
using TestRating.Model;

namespace TestRating.Services
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {

        private readonly IPLogger _logger;
        private readonly PolicyRatingFactory _policyRatingFactory;
        public RatingEngine(PolicyRatingFactory PolicyRatingFactory, IPLogger _logger)
        {
            this._logger = _logger;
            _policyRatingFactory = PolicyRatingFactory;
        }

        public decimal Rate(Policy Policy)
        {
            try
            {
                return _policyRatingFactory.GetPolicyRatingByPolicyType(Policy.Type).Rate(Policy);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Rate Policy : {ex.Message}");
            }
        }
    }
}
