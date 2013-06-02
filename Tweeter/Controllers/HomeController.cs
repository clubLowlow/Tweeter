using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweeter.Models;
using WebMatrix.WebData;

namespace Tweeter.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tweet");
        }

        
    }
}
