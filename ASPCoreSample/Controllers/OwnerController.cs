using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace ASPCoreSample.Controllers
{
    public class OwnerController : Controller
    {
        private readonly OwnerRepository ownerRepository;

        public OwnerController(IConfiguration configuration)
        {

            ownerRepository = new OwnerRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(ownerRepository.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public IActionResult Create(OwnerModel cust)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                ownerRepository.Add(cust);
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
            OwnerModel obj = ownerRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

     

        // POST: /Brand/Edit   
        [HttpPost]
        public IActionResult Edit(OwnerModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                ownerRepository.Update(obj);
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
            ownerRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        
    }
}
