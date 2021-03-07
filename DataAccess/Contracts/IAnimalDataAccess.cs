using System.Threading.Tasks;
using System.Collections.Generic;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IAnimalDataAccess
    {
        Task<Animal> AsyncInsert(AnimalUpdateModel animal);
        Task<IEnumerable<Animal>> AsyncGet();
        Task<Animal> AsyncGet(IAnimalIdentity animalId);
        Task<Animal> AsyncUpdate(AnimalUpdateModel animal);
    }
}
