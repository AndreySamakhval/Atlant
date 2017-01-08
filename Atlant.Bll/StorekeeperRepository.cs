using Atlant.Dal;
using Atlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Bll
{
    public interface IStorekeeperRepository
    {
        IEnumerable<Storekeeper> GetAll();
        Storekeeper Get(int id);
        void Create(Storekeeper stopkeeper);
        void Delete(int id);
    }

    public class StorekeeperRepository : IStorekeeperRepository
    {
        private AtlantContext db;

        public StorekeeperRepository(AtlantContext context)
        {
            this.db = context;
        }

        public void Create(Storekeeper stopkeeper)
        {
            db.Storekeepers.Add(stopkeeper);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Storekeeper stopkeeper = db.Storekeepers.Find(id);
            if (stopkeeper != null)
            {
                db.Storekeepers.Remove(stopkeeper);
                db.SaveChanges();
            }
        }

        public Storekeeper Get(int id)
        {
            return db.Storekeepers.Find(id);
        }

        public IEnumerable<Storekeeper> GetAll()
        {
            return db.Storekeepers.ToList();
        }
    }
}
