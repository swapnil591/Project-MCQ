﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationLayerMVC.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Test()
        {
            return View();
        }
    }
}