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
    public class RoomController : Controller
    {
        private readonly RoomRepository roomRepository;
        IConfiguration configuration;

        public RoomController(IConfiguration configuration)
        {

            configuration = configuration;
            roomRepository = new RoomRepository(configuration);
        }


        public IActionResult Index()
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = ""+DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(roomRepository.FindAll());
        }
        
        

        // GET: /Room/Edit/1
        public IActionResult Edit(int? id)
        {
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            RoomModel obj = roomRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            foreach (OwnerModel item in owners)
            {
                temp.Add(new SelectListItem { Text = item.name , Value = "" + item.Id });
            }
            ViewBag.owners = temp;


            return View(obj);

        }
        

        // POST: /Room/Edit   
        [HttpPost]
        public IActionResult Edit(RoomModel obj)
        {

            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                roomRepository.Update(obj);
                return RedirectToAction("Index");
            }

            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {
            };

            foreach (OwnerModel item in owners)
            {
                temp.Add(new SelectListItem { Text = item.name , Value = "" + item.Id });
            }
            ViewBag.owners = temp;

            return View(obj);
        }
        
        
    }
}
