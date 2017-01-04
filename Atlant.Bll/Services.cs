using Atlant.Dal;
using Atlant.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlant.Bll
{
    public interface IAtlantService
    {
        List<StorekeeperViewModel> GetStorekeepers();
        List<StorekeeperViewModel> GetStorekeepers2();
        StorekeeperViewModel GetStorekeeper(int id);
        void AddStorekeeper(NewStorekeeperViewModel newStorekeeper);
        void DeleteStorekeeper(int id);
        List<DetailViewModel> GetDetails();
        DetailViewModel GetDetail(int id);
        void DeleteDetail(int id);
        void AddDetail(AddDetailViewModel detail);
    }

    public class AtlantService : IAtlantService, IDisposable
    {
        private AtlantContext db = new AtlantContext();
        private DetailRepository detailRepository;
        private StorekeeperRepository storekeeperRepository;

        public AtlantService(): base()
        {
            detailRepository = new DetailRepository(db);
            storekeeperRepository = new StorekeeperRepository(db);
        }
        //поменять через конструктор
        //public DetailRepository Details
        //{
        //    get
        //    {
        //        if (detailRepository == null)
        //            detailRepository = new DetailRepository(db);
        //        return detailRepository;
        //    }
        //}
        ////поменять через конструктор
        //public StorekeeperRepository Storekeepers
        //{
        //    get
        //    {
        //        if (storekeeperRepository == null)
        //            storekeeperRepository = new StorekeeperRepository(db);
        //        return storekeeperRepository;
        //    }
        //}



        public void AddStorekeeper(NewStorekeeperViewModel newStorekeeper)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<NewStorekeeperViewModel, Storekeeper>());
            Storekeeper storkeeper = Mapper.Map<NewStorekeeperViewModel, Storekeeper>(newStorekeeper);
            storekeeperRepository.Create(storkeeper);
        }

        public void DeleteStorekeeper(int id)
        {
            if (detailRepository.CountDetails(id) == 0)
            {
                storekeeperRepository.Delete(id);
            }
            ///////////else!!!!!!!!!!!
        }

        public StorekeeperViewModel GetStorekeeper(int id)
        {
            //StorekeeperViewModel storekeeper = new StorekeeperViewModel();
            //using (var DB = new AtlantContext())
            //{
            //   // storekeeper = DB.Storekeepers.First(s=>s.Id==id);
            //}

            //return storekeeper;
           
            Mapper.Initialize(cfg => cfg.CreateMap<Storekeeper, StorekeeperViewModel>());
            return Mapper.Map<Storekeeper, StorekeeperViewModel>(storekeeperRepository.Get(id));
        }

        public List<StorekeeperViewModel> GetStorekeepers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Storekeeper, StorekeeperViewModel>());
            return Mapper.Map<IEnumerable<Storekeeper>, List<StorekeeperViewModel>>(storekeeperRepository.GetAll());
        }

        public List<StorekeeperViewModel> GetStorekeepers2()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Storekeeper, StorekeeperViewModel>());
            var stopkeepers = Mapper.Map<IEnumerable<Storekeeper>, List<StorekeeperViewModel>>(storekeeperRepository.GetAll());
            foreach(var item in stopkeepers)
            {
                item.AmountDetails = detailRepository.CountDetails(item.Id).ToString();
            }
            return stopkeepers;
        }

        public List<DetailViewModel> GetDetails()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Detail, DetailViewModel>());
            return Mapper.Map<IEnumerable<Detail>, List<DetailViewModel>>(detailRepository.GetAll());
        }

        public DetailViewModel GetDetail(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Detail, DetailViewModel>());
            return Mapper.Map<Detail, DetailViewModel>(detailRepository.Get(id));
        }

        public void DeleteDetail(int id)
        {
            detailRepository.Delete(id);
        }

        public void AddDetail(AddDetailViewModel detail)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AddDetailViewModel, Detail>());
            Detail newDetail = Mapper.Map<AddDetailViewModel, Detail>(detail);
            detailRepository.Create(newDetail);

        }





        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
