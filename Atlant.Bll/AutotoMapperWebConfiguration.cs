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
    public static class AutotoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Storekeeper, StorekeeperViewModel>()
            .ForMember("AmountDetails", c => c.Ignore()));
            Mapper.Initialize(cfg => cfg.CreateMap<Detail, DetailViewModel>()
           .ForMember("Storekeeper", c => c.MapFrom(x => x.Storekeeper.Name)));

        }

    }

   
}
