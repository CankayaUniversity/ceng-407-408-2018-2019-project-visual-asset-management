using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using ASPCoreSample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ASPCoreSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null || username=="")
            {
                return Redirect("/login.html");
            }
            else
            {
                ViewData["department"] =HttpContext.Session.GetString("department");
                ViewData["UserNameM"] = HttpContext.Session.GetString("name") +" "+ HttpContext.Session.GetString("surname");
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            string username = HttpContext.Session.GetString("username");
            if (username == null || username == "")
            {
                return Redirect("/login.html");
            }
            else
            {
                ViewData["department"] = HttpContext.Session.GetString("department");
                ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
                return View();
            }

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            string username = HttpContext.Session.GetString("username");
            if (username == null || username == "")
            {
                return Redirect("/login.html");
            }
            else
            {
                ViewData["department"] = HttpContext.Session.GetString("department");
                ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            return Redirect("/login.html");
        }

    }
}
