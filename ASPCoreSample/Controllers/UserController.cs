using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASPCoreSample.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository UserRepository;

        public UserController(IConfiguration configuration)
        {

            UserRepository = new UserRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(UserRepository.FindAll());
        }

        public IActionResult Create()
        {

            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });

            temp.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            temp.Add(new SelectListItem { Text = "Personel", Value = "Personel" });

            ViewBag.departments = temp;
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public IActionResult Create(UserModel cust)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                UserRepository.Add(cust);
                return RedirectToAction("Index");
            }

            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });

            temp.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            temp.Add(new SelectListItem { Text = "Personel", Value = "Personel" });

            ViewBag.departments = temp;
            return View(cust);

        }

        // GET: /User/Edit/1
        public IActionResult Edit(int? id)
        {

            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });

            temp.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            temp.Add(new SelectListItem { Text = "Personel", Value = "Personel" });

            ViewBag.departments = temp;
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            UserModel obj = UserRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View(obj);

        }

      

        // POST: /User/Edit   
        [HttpPost]
        public IActionResult Edit(UserModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                UserRepository.Update(obj);
                return RedirectToAction("Index");
            }

            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });

            temp.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            temp.Add(new SelectListItem { Text = "Personel", Value = "Personel" });

            ViewBag.departments = temp;
            return View(obj);
        }

        // GET:/User/Delete/1
        public IActionResult Delete(int? id)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            UserRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        
    }
}
