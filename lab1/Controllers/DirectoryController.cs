using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Newtonsoft.Json;

namespace lab1.Controllers
{
    [Authorize]
    public class DirectoryController : Controller
    {
        // GET: GetDirectories
        [HttpGet]
        public ActionResult GetDirectories()
        {
            ViewBag.UserName = User.Identity?.Name ?? "Not authorise";
            return View();

        }

        // POST: CreateDirectory
        [HttpPost]
        public ActionResult CreateDirectory()
        {
            return View();
        }
    }
}