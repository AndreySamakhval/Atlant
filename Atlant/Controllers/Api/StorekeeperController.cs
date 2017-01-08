using Atlant.Bll;
using Atlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atlant.Controllers.Api
{
    public class StorekeeperController : ApiController
    {
        IAtlantService _service;

        public StorekeeperController(IAtlantService service)
        {
            _service = service;
        }

        public IEnumerable<StorekeeperViewModel> Get()
        {
            return _service.GetStorekeepers2();
        }

        public StorekeeperViewModel Get(int id)
        {
           return _service.GetStorekeeper(id);
        }

        public void Post([FromBody]NewStorekeeperViewModel storekeeper)
        {
            _service.AddStorekeeper(storekeeper);
        }
        
        public void Delete(int id)
        {
            _service.DeleteStorekeeper(id);
        }
    }
}
