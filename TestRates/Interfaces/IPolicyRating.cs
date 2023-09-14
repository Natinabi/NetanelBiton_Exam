using System;
using System.Collections.Generic;
using System.Text;
using TestRating.Model;

namespace TestRating.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPolicyRating
    {
        PolicyType policyType { get; }
        decimal Rate(Policy policy);
       // bool IsValidPolicy(Policy policy);
    }
}
