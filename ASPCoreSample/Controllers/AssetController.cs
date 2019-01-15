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
    public class AssetController : Controller
    {
        private readonly assetRepository assetRepository;
        IConfiguration configuration;

        public AssetController(IConfiguration configuration)
        {

            configuration = configuration;
            assetRepository = new assetRepository(configuration);
        }


        public IActionResult Index(int roomID)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            var k = "" + DateTime.Now;
            HttpContext.Session.SetString("Test", k);
            return View(assetRepository.FindAll(roomID));
        }

        public IActionResult Create()
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> types = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in types)
            {
                temp.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.types = temp;


            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();


            List<SelectListItem> tempowner = new List<SelectListItem>
            {

            };

            tempowner.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (OwnerModel item in owners)
            {
                tempowner.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.owners = tempowner;

            DepotRepository depotRepository = new DepotRepository(configuration);
            System.Collections.Generic.IEnumerable<DepotModel> depots = depotRepository.FindAll();


            List<SelectListItem> tempdepot = new List<SelectListItem>
            {

            };

            tempdepot.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (DepotModel item in depots)
            {
                tempdepot.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.depots = tempdepot;


            RoomRepository roomRepository = new RoomRepository(configuration);
            System.Collections.Generic.IEnumerable<RoomModel> rooms = roomRepository.FindAll();


            List<SelectListItem> temproom = new List<SelectListItem>
            {

            };

            temproom.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (RoomModel item in rooms)
            {
                temproom.Add(new SelectListItem { Text = item.roomname, Value = "" + item.Id });
            }
            ViewBag.rooms = temproom;


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

        // POST: Asset/Create
        [HttpPost]
        public IActionResult Create(AssetModel cust)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            cust.acquisition_date = DateTime.Now;
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {
                Boolean success=changeDepo(false, cust);
                if (success)
                {
                    assetRepository.Add(cust);
                    return RedirectToAction("Index");
                }
            }
            ViewData["error"] = "İşlem Başarısız";
            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> types = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in types)
            {
                temp.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.types = temp;


            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();


            List<SelectListItem> tempowner = new List<SelectListItem>
            {

            };

            tempowner.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (OwnerModel item in owners)
            {
                tempowner.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.owners = tempowner;

            DepotRepository depotRepository = new DepotRepository(configuration);
            System.Collections.Generic.IEnumerable<DepotModel> depots = depotRepository.FindAll();


            List<SelectListItem> tempdepot = new List<SelectListItem>
            {

            };

            tempdepot.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (DepotModel item in depots)
            {
                tempdepot.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.depots = tempdepot;


            RoomRepository roomRepository = new RoomRepository(configuration);
            System.Collections.Generic.IEnumerable<RoomModel> rooms = roomRepository.FindAll();


            List<SelectListItem> temproom = new List<SelectListItem>
            {

            };

            temproom.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (RoomModel item in rooms)
            {
                temproom.Add(new SelectListItem { Text = item.roomname, Value = "" + item.Id });
            }
            ViewBag.rooms = temproom;


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

            return View(cust);

        }

        // GET: /Asset/Edit/1
        public IActionResult Edit(int? id)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> types = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in types)
            {
                temp.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.types = temp;

            DepotRepository depotRepository = new DepotRepository(configuration);
            System.Collections.Generic.IEnumerable<DepotModel> depots = depotRepository.FindAll();


            List<SelectListItem> tempdepots = new List<SelectListItem>
            {

            };

            tempdepots.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (DepotModel item in depots)
            {
                tempdepots.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.depots = tempdepots;


            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();

            List<SelectListItem> tempowner = new List<SelectListItem>
            {

            };

            tempowner.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (OwnerModel item in owners)
            {
                tempowner.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.owners = tempowner;



            RoomRepository roomRepository = new RoomRepository(configuration);
            System.Collections.Generic.IEnumerable<RoomModel> rooms = roomRepository.FindAll();

            List<SelectListItem> temproom = new List<SelectListItem>
            {

            };

            temproom.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (RoomModel item in rooms)
            {
                temproom.Add(new SelectListItem { Text = item.roomname, Value = "" + item.Id });
            }
            ViewBag.rooms = temproom;



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
            if (id == null)
            {
                return NotFound();
            }
            AssetModel obj = assetRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }


        // POST: /Asset/Edit   
        [HttpPost]
        public IActionResult Edit(AssetModel obj)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            ViewData["UserNameM"] = HttpContext.Session.GetString("name") + " " + HttpContext.Session.GetString("surname");
            ViewData["department"] = HttpContext.Session.GetString("department");
            if (ModelState.IsValid)
            {

                AssetModel assetModelOrigin = assetRepository.FindByID((int)obj.Id);
                Boolean depoResponse= updateDepo(false, obj, assetModelOrigin);
                if (depoResponse)
                {
                    assetRepository.Update(obj);
                    return RedirectToAction("Index");
                }
            }

            AssetTypeRepository assetTypeRepository = new AssetTypeRepository(configuration);
            System.Collections.Generic.IEnumerable<AssetTypeModel> types = assetTypeRepository.FindAll();


            List<SelectListItem> temp = new List<SelectListItem>
            {

            };

            temp.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (AssetTypeModel item in types)
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

            RoomRepository roomRepository = new RoomRepository(configuration);
            System.Collections.Generic.IEnumerable<RoomModel> rooms = roomRepository.FindAll();


            List<SelectListItem> temproom = new List<SelectListItem>
            {

            };

            temproom.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (RoomModel item in rooms)
            {
                temproom.Add(new SelectListItem { Text = item.roomname, Value = "" + item.Id });
            }
            ViewBag.rooms = temproom;

            DepotRepository depotRepository = new DepotRepository(configuration);
            System.Collections.Generic.IEnumerable<DepotModel> depots = depotRepository.FindAll();


            List<SelectListItem> tempdepots = new List<SelectListItem>
            {

            };

            tempdepots.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (DepotModel item in depots)
            {
                tempdepots.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.depots = tempdepots;


            OwnerRepository ownerRepository = new OwnerRepository(configuration);
            System.Collections.Generic.IEnumerable<OwnerModel> owners = ownerRepository.FindAll();


            List<SelectListItem> tempowner = new List<SelectListItem>
            {

            };

            tempowner.Add(new SelectListItem { Text = "Yok", Value = "" + 0 });
            foreach (OwnerModel item in owners)
            {
                tempowner.Add(new SelectListItem { Text = item.name, Value = "" + item.Id });
            }
            ViewBag.owners = tempowner;
            return View(obj);
        }

        // GET:/Asset/Delete/1
        public IActionResult Delete(int? id)
        {

            ViewData["department"] = HttpContext.Session.GetString("department");
            if (id == null)
            {
                return NotFound();
            }
            int idtemp = (int)id;
            AssetModel assetModel= assetRepository.FindByID(idtemp);
            deleteDepo(false, assetModel);
            assetRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }


        public Boolean changeDepo(Boolean before, AssetModel obj)
        {
            if (before == false)
            {
                DepotRepository DepotRepository = new DepotRepository(configuration);
                DepotModel depoObj = DepotRepository.FindByID(obj.depot_id);
                if (depoObj.notusecount > obj.numberofasset)
                {
                    depoObj.inusecount += obj.numberofasset;
                    depoObj.notusecount -= obj.numberofasset;
                    DepotRepository.Update(depoObj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean deleteDepo(Boolean before, AssetModel obj)
        {
            if (before == false)
            {
                DepotRepository DepotRepository = new DepotRepository(configuration);
                DepotModel depoObj = DepotRepository.FindByID(obj.depot_id);
                
                    depoObj.inusecount -= obj.numberofasset;
                    depoObj.notusecount += obj.numberofasset;
                    DepotRepository.Update(depoObj);
                    return true;
               
            }
            return true;
        }

        public Boolean updateDepo(Boolean before, AssetModel obj, AssetModel objBefore)
        {
            if (before == false)
            {
                int differenceUse =  obj.numberofasset- objBefore.numberofasset ;
                if (differenceUse != 0)
                {
                    DepotRepository DepotRepository = new DepotRepository(configuration);
                    DepotModel depoObj = DepotRepository.FindByID(obj.depot_id);
                    if (depoObj.notusecount > differenceUse)
                    {
                        depoObj.inusecount += differenceUse;
                        depoObj.notusecount -= differenceUse;
                        DepotRepository.Update(depoObj);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
