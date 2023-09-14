using System;
using System.Collections.Generic;
using System.Text;

namespace TestRating.Model
{
    public class TravelPolicy:Policy
    {
        public string Country { get; set; }
        public int Days { get; set; }
    }
}
