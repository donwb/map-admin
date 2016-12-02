using System;
using Microsoft.AspNetCore.Builder;
using Nancy.Owin;

 
namespace NancyApplication
{

    
   public class Startup
    {


        public void Configure(IApplicationBuilder app)
        {
            
            var dbVars = CheckEnvVars();
            if(dbVars.Item1 == null || dbVars.Item2 == null) {
                Console.WriteLine("Environment vars not set, stopping....");
                Environment.Exit(1);
            } else {
                Console.WriteLine("User: " + dbVars.Item1 + " Pass:" + dbVars.Item2);
            }
            

            app.UseOwin(x => x.UseNancy());
            

        }

        private Tuple<string, string> CheckEnvVars() 
        {
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASSWORD");
            
            return new Tuple<string, string>(user, pass);

        }

   }
}
