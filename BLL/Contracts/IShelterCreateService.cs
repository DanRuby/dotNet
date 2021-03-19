using System.Threading.Tasks;
using Domain;
using Domain.Contracts;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IShelterCreateService
    {
        Task<Shelter> AsyncCreate(ShelterUpdateModel shelter);
    }
}
