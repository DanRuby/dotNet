using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain.Contracts;

namespace BLL.Implementation
{
    public class ShelterDeleteService:IShelterDeleteService
    {
        private IShelterDataAccess ShelterDataAccess { get; }

        public ShelterDeleteService(IShelterDataAccess ShelterDataAccess) => this.ShelterDataAccess = ShelterDataAccess;

        public async Task AsyncDelete(IShelterContainer shelterID)
        {
            await ShelterDataAccess.AsyncDelete(shelterID);
        }
    }
}
