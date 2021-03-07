using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class AnimalUpdateService:IAnimalUpdateService
    {
        private IAnimalDataAccess dataAccess { get; }
        private IShelterValidateService shelterValidateService { get; }

        public AnimalUpdateService(IAnimalDataAccess dataAccess, IShelterValidateService shelterValidateService)
        {
            this.dataAccess = dataAccess;
            this.shelterValidateService = shelterValidateService;
        } 

        public async Task<Animal> AsyncUpdate(AnimalUpdateModel animal)
        {
            await shelterValidateService.AsyncValidateShelter(animal);

            return await dataAccess.AsyncUpdate(animal);
        }
    }
}
