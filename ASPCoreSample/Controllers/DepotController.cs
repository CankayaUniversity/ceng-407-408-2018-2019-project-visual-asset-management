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
    public class DepotController : Controller
    {
        private readonly DepotRepository DepotRepository;
        IConfiguration configuration;

        public DepotController(IConfiguration configuration)
        {

            configuration = configuration;
            DepotRepository = new DepotRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(DepotRepository.FindAll());
        }

        public IActionResult Create()
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> assets = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in assets)
            {
                temp.Add(new SelectListItem { Text = item.name , Value = "" + item.Id });
            }
            ViewBag.types = temp;


            BrandRepository brandRepository = new BrandRepository(configuration);
            System.Collections.Generic.IEnumerable<BrandModel> brands = brandRepository.FindAll();


            List<SelectListItem> tempBrands = new List<SelectListItem>
            {

            };

            tempBrands.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (BrandModel item in brands)
            {
                tempBrands.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.brands = tempBrands;

            ViewData["department"] = HttpContext.Session.GetString("department");
            return View();
        }

        // POST: Depot/Create
        [HttpPost]
        public IActionResult Create(DepotModel cust)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                DepotRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /Depot/Edit/1
        public IActionResult Edit(int? id)
        {
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> assets = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in assets)
            {
                temp.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.types = temp;


            BrandRepository brandRepository = new BrandRepository(configuration);
            System.Collections.Generic.IEnumerable<BrandModel> brands = brandRepository.FindAll();


            List<SelectListItem> tempBrands = new List<SelectListItem>
            {

            };

            tempBrands.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (BrandModel item in brands)
            {
                tempBrands.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.brands = tempBrands;
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            DepotModel obj = DepotRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        

        // POST: /Depot/Edit   
        [HttpPost]
        public IActionResult Edit(DepotModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {

                DepotModel before = DepotRepository.FindByID((int)obj.Id);
                int difference = obj.totalcount - before.totalcount;
                
                    obj.notusecount = before.notusecount + difference;
                
                obj.inusecount = before.inusecount;
                DepotRepository.Update(obj);
                return RedirectToAction("Index");
            }
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> assets = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in assets)
            {
                temp.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.types = temp;


            BrandRepository brandRepository = new BrandRepository(configuration);
            System.Collections.Generic.IEnumerable<BrandModel> brands = brandRepository.FindAll();


            List<SelectListItem> tempBrands = new List<SelectListItem>
            {

            };

            tempBrands.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (BrandModel item in brands)
            {
                tempBrands.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.brands = tempBrands;
            return View(obj);
        }

        // GET:/Depot/Delete/1
        public IActionResult Delete(int? id)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            DepotRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        
    }
}
