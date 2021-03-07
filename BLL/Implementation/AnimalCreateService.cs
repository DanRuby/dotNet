using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class AnimalCreateService : IAnimalCreateService
    {
        private IAnimalDataAccess dataAccess { get; }
        private IShelterValidateService shelterValidateService { get; }

        public AnimalCreateService(IAnimalDataAccess dataAccess, IShelterValidateService shelterValidateService)
        {
            this.dataAccess = dataAccess;
            this.shelterValidateService = shelterValidateService;
        }
        public async Task<Animal> AsyncCreate(AnimalUpdateModel animal)
        {
            await shelterValidateService.AsyncValidateShelter(animal);
            return await dataAccess.AsyncInsert(animal);
        }
    }
}
