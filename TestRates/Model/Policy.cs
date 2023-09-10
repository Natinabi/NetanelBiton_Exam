using System;
using TestRating.Interfaces;

namespace TestRating.Model
{

    public class Policy
    {
        public PolicyType Type { get; set; }

        #region General Policy Prop
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        #endregion
        
        #region Life Insurance
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        #endregion

        #region Travel
        public string Country { get; set; }
        public int Days { get; set; }
        #endregion

        #region Health
        public string Gender { get; set; }
        public decimal Deductible { get; set; }

        #endregion

        

        /*
         * Option to seperate this class and add 3 model class each per policy type
         * I've added the class, but I dont know if it's ok to change json class - so this is an option
         * 
            public HealthPolicy HealthPolicy { get; set; }
            public LifePolicy LifePolicy { get; set; }
            public TravelPolicy TravelPolicy { get; set; }

         */

    }
}
