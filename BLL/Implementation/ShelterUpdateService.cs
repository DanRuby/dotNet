using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Models;

namespace BLL.Implementation
{
    public class ShelterUpdateService : IShelterUpdateService
    {
        private IShelterDataAccess shelterDataAccess{get;}
        public ShelterUpdateService(IShelterDataAccess shelterDataAccess) => this.shelterDataAccess = shelterDataAccess;

        public async Task<Shelter> AsyncUpdate(ShelterUpdateModel shelter)
        {
            return await shelterDataAccess.AsyncUpdate(shelter);
        }
    }
}
