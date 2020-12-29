using SourceControlAssignment1.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SourceControlAssignment1.Controllers
{
    public class HomeController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // Index page
        public ActionResult Index()
        {
            return View();
        }

        // GET: Get the all users
        [HttpGet]
        public ActionResult GetAllUsers ()
        {
            var users = from user in db.Users
                        orderby user.Id
                        select user;

            return View(users.ToList());
        }

        // POST: Create an user
        [HttpPost]
        public string CreateUser(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                return "Created Successfully!!";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}