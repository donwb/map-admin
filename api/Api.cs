using System;
using Nancy;
using System.Collections.Generic;
using System.Web.Http;
using maplib;
using Newtonsoft.Json;

namespace NancyApplication
{

    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get("/api/ping", args => "Pong");
            Get("/api/allUserActions", args => AllUserActions(args));
        }

        private object AllUserActions(dynamic o)
        {
            maplib.MapController controller = new maplib.MapController();

            var users = controller.AllUserActions();
            AllUserActionsResponse resp = new AllUserActionsResponse();
            resp.Users = users;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.S‌​erializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore; 

            var j = JsonConvert.SerializeObject(resp);
            
            Console.WriteLine(j);
            
            Useractions ua = new Useractions();
            ua.Id = 1;
            ua.Userid = 1;
            ua.Actionsid = 2;
            ua.Actiondate = DateTime.Now;
            //ua.Actions = users[0].Actions;
            //ua.User = users[0].User;
            List<Useractions> uas = new List<Useractions>();
            uas.Add(ua);
            AllUserActionsResponse r = new AllUserActionsResponse{Users = uas};

            return Response.AsJson(r, HttpStatusCode.OK);

        }

    }

    public class AllUserActionsResponse
    {
        public List<Useractions> Users {get; set;}
    } 
}