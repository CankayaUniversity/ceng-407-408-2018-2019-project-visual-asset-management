using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace ASPCoreSample.Controllers
{
    public class BrandController : Controller
    {
        private readonly BrandRepository BrandRepository;

        public BrandController(IConfiguration configuration)
        {

            BrandRepository = new BrandRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(BrandRepository.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public IActionResult Create(BrandModel cust)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                BrandRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /Brand/Edit/1
        public IActionResult Edit(int? id)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            BrandModel obj = BrandRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        public string hey()
        {
            return HttpContext.Session.GetString("Test") ;

        }

        // POST: /Brand/Edit   
        [HttpPost]
        public IActionResult Edit(BrandModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                BrandRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Brand/Delete/1
        public IActionResult Delete(int? id)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            BrandRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        
    }
}
