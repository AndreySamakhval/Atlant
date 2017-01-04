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
        AtlantService _service = new AtlantService();


        // GET: api/Storekeeper
        public IEnumerable<StorekeeperViewModel> Get()
        {
            return _service.GetStorekeepers2();
        }

        // GET: api/Storekeeper/5
        public StorekeeperViewModel Get(int id)
        {
           return _service.GetStorekeeper(id);
        }

        // POST: api/Storekeeper
        public void Post([FromBody]NewStorekeeperViewModel storekeeper)
        {
            _service.AddStorekeeper(storekeeper);
        }


        // DELETE: api/Storekeeper/5
        public void Delete(int id)
        {
            _service.DeleteStorekeeper(id);
        }
    }
}
