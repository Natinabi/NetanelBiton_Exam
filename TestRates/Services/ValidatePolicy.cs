using System;
using System.Collections.Generic;
using System.Text;
using TestRating.Interfaces;
using TestRating.Model;

namespace TestRating.Services
{
    public class ValidatePolicy
    {
       
        public ValidatePolicy()
        {
          
        }
        public static bool IsValidPolicy(Policy policy)
        {
            if(policy.Type == PolicyType.Health)
            {
                return ValidateHealthPolicy((HealthPolicy)policy);
            }
            else if (policy.Type == PolicyType.Travel)
            {
                return ValidateTravelPolicy((TravelPolicy)policy);
            }
            else if (policy.Type == PolicyType.Life)
            {
                return ValidateLifePolicy((LifePolicy)policy);
            }
            return false;
        }

        private static bool ValidateHealthPolicy(HealthPolicy policy)
        {
           
            if (string.IsNullOrEmpty(policy.Gender))
            {
                throw new Exception("Health policy must specify Gender");
            }

         

            return true;
        }
        private static bool ValidateLifePolicy(LifePolicy policy)
        {
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

           

            return true;
        }
        private static bool ValidateTravelPolicy(TravelPolicy policy)
        {
          

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

          

            return true;
        }
        public static int GetAge(DateTime DateOfBirth)
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
