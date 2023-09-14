using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TestRating.Model;
using Newtonsoft.Json.Linq;

namespace TestRating.Services
{
    /// <summary>
    ///  Policy Utility contains method to load policy from file and validation, can include other utility helper.
    /// </summary>
    public class PolicyUtility
    {
        public ILogger<PolicyUtility> logger;

        public PolicyUtility(ILogger<PolicyUtility> Logger)
        {
            this.logger = Logger;
        }
        public Policy LoadPolicy(string PolicyFilePath)
        {
            try
            {
                string jsonData = LoadPolicyFromFile(PolicyFilePath);

                if (IsValidJson(jsonData))
                {
                    return GetPolicyObject(jsonData);
                }
                else
                {
                    throw new Exception("Content file data not valid");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Load Policy: {ex.Message}");
            }
        }

        public string LoadPolicyFromFile(string PolicyFilePath)
        {
            if (PolicyFilePath == null)
            {
                throw new Exception("Error loading Policy file");
            }

            if (!File.Exists(PolicyFilePath))
            {
                throw new Exception("Policy file not exists");
            }
            try
            {
                return File.ReadAllText(PolicyFilePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: can not open/read policy file : {ex.Message}");
            }
        }

        private Policy GetPolicyObject(string PolicyJson)
        {
            try
            {
                if (GetPolicyType(PolicyJson) == PolicyType.Health)
                    return JsonConvert.DeserializeObject<HealthPolicy>(PolicyJson, new StringEnumConverter());
                else if (GetPolicyType(PolicyJson) == PolicyType.Travel)
                    return JsonConvert.DeserializeObject<TravelPolicy>(PolicyJson, new StringEnumConverter());
                else
                    return JsonConvert.DeserializeObject<LifePolicy>(PolicyJson, new StringEnumConverter());
            }
            catch (Exception ex)
            {

                throw new Exception($"Error Deserialize Policy object : {ex.Message}");
            }
        }

        private PolicyType GetPolicyType(string PolicyJson)
        {
            dynamic data = JObject.Parse(PolicyJson);
            if (data.type == "Helth")
                return PolicyType.Health;
            else if (data.type == "Travel")
                return PolicyType.Travel;
            else if (data.type == "Life")
                return PolicyType.Life;

            throw new Exception("Error Policy type in policy");


        }
        private bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);

                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }


    }
}
