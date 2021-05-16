using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationLayerMVC.Controllers
{
    [AllowAnonymous]
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}