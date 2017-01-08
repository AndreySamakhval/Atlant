using Atlant.Dal;
using Atlant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Bll
{
    public interface IDetailRepository
    {
        IEnumerable<Detail> GetAll();
        Detail Get(int id);
        void Create(Detail detail);
        void Delete(int id);
        int CountDetails(int storekeeperId);
        IEnumerable<Detail> Search(string value);
    }

    public class DetailRepository : IDetailRepository
    {
        private AtlantContext db;

        public DetailRepository(AtlantContext context)
        {
            this.db = context;
        }

        public void Create(Detail detail)
        {
            db.Details.Add(detail);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Detail detail = db.Details.Find(id);
            if (detail != null)
            {
                db.Details.Remove(detail);
                db.SaveChanges();
            }
        }

        public Detail Get(int id)
        {
            return db.Details.Find(id);
        }

        public IEnumerable<Detail> GetAll()
        {
            return db.Details;
        }

        public int CountDetails(int storekeeperId)
        {
            var details = db.Details.Where(d => d.Storekeeper.Id == storekeeperId);
            int count = 0;
            if(details!=null)
            foreach(var item in details)
            {
                count += (int)item.Amount;
            }

            return count;
        }

        public IEnumerable<Detail> Search(string value)
        {
            return db.Details.Where(x => x.ItemCode.Contains(value));
        }
    }
}
