﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestRating.Model
{
    public class LifePolicy : Policy
    {
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
    }
}
