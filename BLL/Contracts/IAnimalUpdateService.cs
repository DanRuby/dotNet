using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace BLL.Contracts
{
    public interface IAnimalUpdateService
    {
        Task<Animal> AsyncUpdate(AnimalUpdateModel animal);
    }
}
