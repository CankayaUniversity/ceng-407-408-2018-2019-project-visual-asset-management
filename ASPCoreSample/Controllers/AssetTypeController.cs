using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ASPCoreSample.Models;
using ASPCoreSample.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace ASPCoreSample.Controllers
{
    public class AssetTypeController : Controller
    {
        private readonly AssetTypeRepository AssetTypeRepository;

        public AssetTypeController(IConfiguration configuration)
        {

            AssetTypeRepository = new AssetTypeRepository(configuration);
        }


        public IActionResult Index()
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(AssetTypeRepository.FindAll());
        }

        public IActionResult Create()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            return View();
        }

        // POST: AssetType/Create
        [HttpPost]
        public IActionResult Create(AssetTypeModel cust)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                AssetTypeRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /AssetType/Edit/1
        public IActionResult Edit(int? id)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            AssetTypeModel obj = AssetTypeRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

      

        // POST: /AssetType/Edit   
        [HttpPost]
        public IActionResult Edit(AssetTypeModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                AssetTypeRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/AssetType/Delete/1
        public IActionResult Delete(int? id)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            AssetTypeRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        
    }
}
