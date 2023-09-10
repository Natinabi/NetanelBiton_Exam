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
                return JsonConvert.DeserializeObject<Policy>(PolicyJson, new StringEnumConverter());
            }
            catch (Exception ex)
            {

                throw new Exception($"Error Deserialize Policy object : {ex.Message}");
            }
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
