using System;
using Nancy;

namespace NancyApplication
{

    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get("/api/ping", args => "Pong");
        }
    } 
}