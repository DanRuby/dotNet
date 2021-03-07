using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class ShelterValidateService: IShelterValidateService
    {
        private IShelterDataAccess dataAccess { get; }

        public ShelterValidateService(IShelterDataAccess dataAccess) => this.dataAccess = dataAccess;

        public async Task AsyncValidateShelter(IShelterContainer shelter)
        {
            if (shelter == null)
                throw new ArgumentNullException(nameof(shelter));

            var res = await dataAccess.AsyncGet(shelter);

            if (res == null && shelter.ShelterId.HasValue)
                throw new InvalidOperationException($"В базе не было найдено приюта с Id ={shelter.ShelterId}");
        }
    }
}
