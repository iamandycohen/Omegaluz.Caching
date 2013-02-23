using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        private const string KEY_INDEX = "Message.Index";
        private const string KEY_ABOUT = "Message.About";
        private const string KEY_CONTACT = "Message.Contact";

        private readonly HttpCache Cache = new HttpCache();
        
        public ActionResult Index()
        {
            string message;

            if (!Cache.Get(KEY_INDEX, out message))
            {
                message = "Modify this template to jump-start your ASP.NET MVC application.";
                Cache.Set(KEY_INDEX, message);
            }

            ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            string message;

            if (!Cache.Get(KEY_ABOUT, out message))
            {
                message = "Your app description page.";
                Cache.Set(KEY_ABOUT, message);
            }

            ViewBag.Message = message;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            string message;

            if (!Cache.Get(KEY_CONTACT, out message))
            {
                message = "Your contact page.";
                Cache.Set(KEY_CONTACT, message);
            }

            ViewBag.Message = message;

            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowCache()
        {
            var viewModel = Cache.GetAll().Where(e => e.Key.StartsWith("Message"));

            return PartialView(viewModel);
        }
    }
}
