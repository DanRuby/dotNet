using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Contracts;
using Domain.Contracts;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class AnimalDeleteService:IAnimalDeleteService
    {
        private IAnimalDataAccess animalDataAccess { get; }

        public AnimalDeleteService(IAnimalDataAccess animalDataAccess) => this.animalDataAccess = animalDataAccess;

        public async Task DeleteAsynnc(IAnimalIdentity animalID)
        {
           await animalDataAccess.AsyncDelete(animalID);
        }
    }
}
