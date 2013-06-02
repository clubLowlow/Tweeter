using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tweeter.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ViewResult Index()
        {
            return View("Error");
        }

        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("FileNotFound");
        }

        public ViewResult Unauthorized()
        {
            Response.StatusCode = 403;
            return View("UnauthorizedAccess");
        }



    }
}
