using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace maplib
{
    public class MapController 
    {
        public List<Useractions> AllUserActions() 
        {
            using(var db = new mapContext())
            {
                // Collection of UserActions
                var users = db.Useractions
                .Include(mu => mu.User)
                .Include(act => act.Actions)
                .ToList();

                return users;
            }
        }

        public void ViaMapUsers() 
        {
            using(var ctx = new mapContext())
            {
                var mapUsers = ctx.Mapuser
                .Include(ua => ua.Useractions)
                .ToList();

                foreach(var u in mapUsers)
                {
                    Console.WriteLine("User: "+ u.Email);
                    
                    foreach(var act in u.Useractions)
                    {
                        // This killed me!
                        ctx.Entry(act)
                        .Reference(a => a.Actions)
                        .Load();

                        Console.WriteLine("Action: " + act.Actions.Action);
                    }
                }
                
            }
        }

        public Mapuser FindUser(string userEmail) 
        {
            using(var db = new mapContext())
            {
                try
                {
                    var me = db.Mapuser
                    .Include(ua => ua.Useractions)
                    .Single(u => u.Email.ToString() == userEmail);

                    if (me != null)
                    {
                        foreach (var a in me.Useractions) 
                        {
                            db.Entry(a)
                            .Reference(act => act.Actions)
                            .Load();
                        }
                    }

                    return me;
                }
                catch (System.Exception)
                {
                    return null;
                }
                
            }
            
        }

        public void AddUser(string emailAddress) 
        {
            using (var db = new mapContext())
            {
                Mapuser mu = new Mapuser{
                    Email = emailAddress};
                db.Mapuser.Add(mu);
                db.SaveChanges();

                Console.WriteLine(mu.Id + " " + mu.Email);
            }
            
        }

        public void AddItem(string who) 
        {
            using (var db = new mapContext())
            {
                // get the user
                var me = db.Mapuser
                .Single(u => u.Email.ToString() == who);

                // get the first action
                var action = db.Actions
                .Single(i => i.Id == 1);

                // New up an object
                var ua = new Useractions();
                ua.Actions = action;
                ua.User = me;
                ua.Actiondate = DateTime.Now;

                // Save it
                db.Useractions.Add(ua);
                db.SaveChanges();

                // if it returns an ID, we're good
                Console.WriteLine("Done: " + ua.Id);

            }
            
        }
    }
}