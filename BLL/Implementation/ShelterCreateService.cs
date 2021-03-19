using System;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace BLL.Implementation
{
    public class ShelterCreateService:IShelterCreateService
    {
        private IShelterDataAccess dataAccess { get; }

        public ShelterCreateService(IShelterDataAccess dataAccess) => this.dataAccess = dataAccess;

        public async Task<Shelter> AsyncCreate(ShelterUpdateModel shelter)
        {
            if (shelter == null)
                throw new ArgumentNullException(nameof(shelter));

            return await dataAccess.AsyncInsert(shelter);
        }
    }
}
