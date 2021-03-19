using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IAnimalCreateService
    {
        Task<Animal> AsyncCreate(AnimalUpdateModel animal);
    }
}
