using BLL.Contracts;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementation
{
    public class ShelterGetService : IShelterGetService
    {
        private IShelterDataAccess dataAccess { get; }

        public ShelterGetService(IShelterDataAccess dataAccess) => this.dataAccess = dataAccess;

        public async Task<IEnumerable<Shelter>> AsyncGet() => await dataAccess.AsyncGet();
        public async Task<Shelter> AsyncGet(IShelterContainer shelter) => await dataAccess.AsyncGet(shelter);
    }
}
