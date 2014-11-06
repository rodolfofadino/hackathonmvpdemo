using LocalAccountsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

using System.Threading.Tasks;

namespace LocalAccountsApp.Controllers
{
    [Authorize]
    public class ActivityController : ApiController
    {
        // GET api/ Activity
        public List<Activity> Get()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var id = this.RequestContext.Principal.Identity.GetUserId();
                var user = context.Users.FirstOrDefault(a => a.Id == id);

                return user.Activities.ToList();
            }
        }

        // GET api/Activity
        public string Post(Activity activity)
        {
            activity.Date = DateTime.Now;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var id =this.RequestContext.Principal.Identity.GetUserId();
                var user = context.Users.FirstOrDefault(a=>a.Id==id );

                user.Activities.Add(activity);

                context.SaveChanges();
            }
            return "";
        }
    }
}

