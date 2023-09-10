using System;
using System.Collections.Generic;
using System.Text;

namespace TestRating.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPLogger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);

    }
}
