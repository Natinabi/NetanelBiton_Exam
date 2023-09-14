using System;
using System.Collections.Generic;
using System.Text;

namespace TestRating.Model
{
    public class HealthPolicy : Policy
    {
        public string Gender { get; set; }
        public decimal Deductible { get; set; }
    }
}
