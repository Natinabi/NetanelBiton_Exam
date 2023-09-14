using System;
using TestRating.Interfaces;

namespace TestRating.Model
{

   public abstract class Policy
    {
        public PolicyType Type { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
