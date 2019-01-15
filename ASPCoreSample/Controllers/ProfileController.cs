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
    public class ProfileController : Controller
    {
        private readonly UserRepository UserRepository;

        public ProfileController(IConfiguration configuration)
        {

            UserRepository = new UserRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });

            temp.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            temp.Add(new SelectListItem { Text = "Personel", Value = "Personel" });

            ViewBag.departments = temp;
            ViewData["department"] = HttpContext.Session.GetString("department");
            int id= Int32.Parse(HttpContext.Session.GetString("userID")); 
            if (id == null)
            {
                return NotFound();
            }
            UserModel obj = UserRepository.FindByID(id);
            if (obj == null)
            {
                return NotFound();
            }

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View(obj);
            return View(UserRepository.FindAll());
        }
        [HttpPost]
        public IActionResult Index(UserModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");

            ViewData["department"] = HttpContext.Session.GetString("department");
            int id = Int32.Parse(HttpContext.Session.GetString("userID"));
            UserModel objOld = UserRepository.FindByID(id);
            obj.Id = id;
            obj.department = objOld.department;
            
                UserRepository.Update(obj);

                ViewData["success"] = "İşlem Başarılı";
                return View(obj);
            

            ViewData["error"] = "İşlem Başarısız";
            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            ViewBag.departments = temp;
            return View(obj);
        }
        public int changeMyPassword()
        {
            return 1;
        }

        
        
    }
}
