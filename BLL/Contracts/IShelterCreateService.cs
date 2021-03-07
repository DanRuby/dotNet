using System.Threading.Tasks;
using Domain;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IShelterCreateService
    {
        Task<Shelter> AsyncCreate(IShelterContainer shelter);
    }
}
