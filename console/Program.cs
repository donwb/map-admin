using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using maplib;

namespace hwapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting....");

            // Check for envvars
            var dbVars = CheckEnvVars();
            if(dbVars.Item1 == null || dbVars.Item2 == null) {
                Console.WriteLine("Environment vars not set, stopping....");
                Environment.Exit(1);
            } else {
                Console.WriteLine("User: " + dbVars.Item1 + " Pass:" + dbVars.Item2);
            }
            
            var controller = new maplib.MapController();

            

            //controller.AllUserActions();

            //controller.ViaMapUsers();

            //controller.JustMe();

            //controller.AddUser("donwb@outlook.com");

            controller.AddItem("donwb@outlook.com");
        
            
            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        private static Tuple<string, string> CheckEnvVars() 
        {
            var user = Environment.GetEnvironmentVariable("DB_USER");
            var pass = Environment.GetEnvironmentVariable("DB_PASSWORD");
            
            return new Tuple<string, string>(user, pass);

        }

    }
}
