using Atlant.Dal;
using Atlant.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        IEnumerable<DetailViewModel> GetDetails();
        DetailViewModel GetDetail(int id);
        void DeleteDetail(int id);
        void AddDetail(AddDetailViewModel detail);
        List<DetailViewModel> SearchDetails(string itemCode);
    }

    public class AtlantService : IAtlantService, IDisposable
    {
        private AtlantContext db = new AtlantContext();
        private IDetailRepository detailRepository;
        private IStorekeeperRepository storekeeperRepository;

        public AtlantService(IDetailRepository dRepo, IStorekeeperRepository sRepo) /*: base()*/
        {
            detailRepository = dRepo;
            storekeeperRepository = sRepo;            
        }

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
            ///////////else
        }

        public StorekeeperViewModel GetStorekeeper(int id)
        {
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
            Mapper.Initialize(cfg => cfg.CreateMap<Storekeeper, StorekeeperViewModel>()
                .ForMember("AmountDetails", c => c.Ignore()));
            var stopkeepers = Mapper.Map<IEnumerable<Storekeeper>, List<StorekeeperViewModel>>(storekeeperRepository.GetAll());

            foreach (var item in stopkeepers)
            {
                item.AmountDetails = detailRepository.CountDetails(item.Id).ToString();
            }
            return stopkeepers;
        }

        public IEnumerable<DetailViewModel> GetDetails()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Detail, DetailViewModel>()
                  .ForMember("Storekeeper", c => c.MapFrom(x => x.Storekeeper.Name))
                  .ForMember("DateAdded", c => c.MapFrom(x => x.DateAdded.ToShortDateString())));
            return Mapper.Map<IEnumerable<Detail>, IEnumerable<DetailViewModel>>(detailRepository.GetAll());
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
            var sk = storekeeperRepository.Get(detail.Storekeeper);

            Mapper.Initialize(cfg => cfg.CreateMap<AddDetailViewModel, Detail>()
                .ForMember("Storekeeper", c => c.UseValue(sk))
            );
            Detail newDetail = Mapper.Map<AddDetailViewModel, Detail>(detail);
            detailRepository.Create(newDetail);

        }

        public List<DetailViewModel> SearchDetails(string itemCode)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Detail, DetailViewModel>()
            .ForMember("Storekeeper", c => c.MapFrom(x => x.Storekeeper.Name))
            .ForMember("DateAdded", c => c.MapFrom(x => x.DateAdded.ToShortDateString())));
            return Mapper.Map<IEnumerable<Detail>, List<DetailViewModel>>(detailRepository.Search(itemCode));
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
