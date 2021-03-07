using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace DataAccess.Contracts
{
    public interface IShelterDataAccess
    {
        Task<Shelter> AsyncGet(IShelterContainer shelter);
        Task<Shelter> AsyncInsert(IShelterContainer shelter);
    }
}
