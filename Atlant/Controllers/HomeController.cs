using Atlant.Bll;
using Atlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atlant.Controllers
{
    public class HomeController : Controller
    {
        IAtlantService _service;

        public HomeController(IAtlantService service)
        {
            _service = service;
        }

        
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Storekeepers()
        {
            return View();
        }

        public ActionResult NewStorekeepers()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewStorekeepers(NewStorekeeperViewModel nStor)
        {
            if (ModelState.IsValid)
            {
                _service.AddStorekeeper(nStor);
                return View();
            }
            return PartialView(nStor);
        }


        [HttpPost]
        public JsonResult Search(string codeSearch)
        {
            var result = _service.SearchDetails(codeSearch);
            if (result != null)
                return Json(result);
            else return null;
        }
            
    }
}