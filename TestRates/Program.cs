using System;
using Microsoft.Extensions.DependencyInjection;
using TestRating.Interfaces;
using Microsoft.Extensions.Hosting;
using TestRating.Services;
using TestRating.Model;

namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = HostConfig();

            //initial services
            var logger = ActivatorUtilities.CreateInstance<PLogger>(host.Services);
            var PolicyUtility = ActivatorUtilities.CreateInstance<PolicyUtility>(host.Services);
            var RatingEngine = ActivatorUtilities.CreateInstance<RatingEngine>(host.Services);

            logger.LogInformation("Application Starting");
            
            try
            {
                var PolicyPathFile = "policy.json";
                var Policy = PolicyUtility.LoadPolicy(PolicyPathFile);
               
                logger.LogInformation("Starting rate.");

                var Rating = RatingEngine.Rate(Policy);
                
                logger.LogInformation("Rating completed.");
                logger.LogInformation($"Policy Rate is : {Rating}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error : {ex.Message}");
            }

            Console.ReadLine();
        }
        private static IHost HostConfig()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((contex, services) =>
                {
                    services.AddTransient<IRatingEngine, RatingEngine>();
                    services.AddTransient<IPolicyRating, HealthPolicyRating>();
                    services.AddTransient<IPolicyRating, TravelPolicyRating>();
                    services.AddTransient<IPolicyRating, LifePolicyRating>();
                    services.AddSingleton<PolicyUtility>();
                    services.AddSingleton<PolicyRatingFactory>();
                    services.AddSingleton<IPLogger, PLogger>();
                })
            .Build();
        }
        

    }
}
