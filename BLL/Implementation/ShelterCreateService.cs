using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;

namespace BLL.Implementation
{
    class ShelterCreateService:IShelterCreateService
    {
        private IShelterDataAccess dataAccess { get; }

        public ShelterCreateService(IShelterDataAccess dataAccess) => this.dataAccess = dataAccess;

        public async Task<Shelter> AsyncCreate(IShelterContainer shelter)
        {
            if (shelter == null)
                throw new ArgumentNullException(nameof(shelter));

            return await dataAccess.AsyncInsert(shelter);
        }
    }
}
