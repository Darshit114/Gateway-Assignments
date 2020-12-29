using System.Web.Mvc;
using System.Linq;
using Source_Control_Final_Assignment.Models;
using Microsoft.AspNet.Identity;


namespace Source_Control_Final_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();

            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == id);

            UserViewModel user = new UserViewModel();

            user.User = currentUser;

            Logger.Info("LogedIn......");

            return View(user);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}