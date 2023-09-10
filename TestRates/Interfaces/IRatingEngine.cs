using System;
using System.Collections.Generic;
using System.Text;
using TestRating.Model;

namespace TestRating.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRatingEngine
    {
        decimal Rate(Policy policy);
    }
}
