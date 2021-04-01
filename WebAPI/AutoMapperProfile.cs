using AutoMapper;
using Client.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Animal, Domain.Animal>();
            this.CreateMap<Domain.Animal, AnimalDTO>();
            this.CreateMap<Domain.Shelter, ShelterDTO>();
            this.CreateMap<AnimalCreateDTO, AnimalUpdateModel>();
            this.CreateMap<AnimalUpdateDTO, AnimalUpdateModel>();
            this.CreateMap<AnimalUpdateModel, DataAccess.Entities.Animal>();


            this.CreateMap<ShelterCreateDTO, ShelterUpdateModel>();
            this.CreateMap<DataAccess.Entities.Shelter, Domain.Shelter>(); 
            this.CreateMap<ShelterUpdateModel, DataAccess.Entities.Shelter>();
            this.CreateMap<ShelterUpdateModel, Domain.Shelter>();
            this.CreateMap<Domain.Shelter, DataAccess.Entities.Shelter>();
            this.CreateMap<ShelterUpdateModel, DataAccess.Entities.Shelter >();
            this.CreateMap<ShelterDTO, ShelterUpdateModel>();
        }
    }
}
