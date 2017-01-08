using Atlant.Bll;
using Atlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Atlant.Controllers.Api
{
    public class DetailController : ApiController
    {
        IAtlantService _service;

        public DetailController(IAtlantService service)
        {
            _service = service;
        }
              
        public IEnumerable<DetailViewModel> Get()
        {
            return _service.GetDetails();
        }
        
        public DetailViewModel Get(int id)
        {
            return _service.GetDetail(id);
        }
        
        [ValidateAntiForgeryToken]
        public IHttpActionResult Post([FromBody]AddDetailViewModel detail)
        {
            if (detail == null)
                return BadRequest();

            if (detail.DateAdded.DayOfWeek == DayOfWeek.Saturday || detail.DateAdded.DayOfWeek == DayOfWeek.Sunday)
                ModelState.AddModelError("", "День не может быть выходным");

            if (ModelState.IsValid)
            {
                _service.AddDetail(detail);
                return Ok();
            }
            else return BadRequest(ModelState);
        }        

        public IHttpActionResult Delete(int id)
        {
            if (id != 0)
            {
                _service.DeleteDetail(id);
                return Ok();
            }
            else return BadRequest();
        }
    }
}
