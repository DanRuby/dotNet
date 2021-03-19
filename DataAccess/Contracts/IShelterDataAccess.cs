using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace DataAccess.Contracts
{
    public interface IShelterDataAccess
    {
        Task<IEnumerable<Shelter>> AsyncGet();

        Task<Shelter> AsyncGet(IShelterContainer shelter);
        Task<Shelter> AsyncInsert(ShelterUpdateModel shelter);

    }
}
