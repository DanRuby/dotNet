using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class AnimalGetService: IAnimalGetService
    {
        private IAnimalDataAccess dataAccess { get; }

        public AnimalGetService(IAnimalDataAccess dataAccess) => this.dataAccess = dataAccess;

        public async Task<IEnumerable<Animal>> AsyncGet() => await dataAccess.AsyncGet();
        public async Task<Animal> AsyncGet(IAnimalIdentity animal) => await dataAccess.AsyncGet(animal);
    }
}
