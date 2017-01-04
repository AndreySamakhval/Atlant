using Atlant.Bll;
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
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult ShowFormDetail()
        {
            return PartialView();
        }
            
    }
}