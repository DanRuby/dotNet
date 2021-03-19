using Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IAnimalGetService
    {
        Task<IEnumerable<Animal>> AsyncGet();

        Task<Animal> AsyncGet(IAnimalIdentity animal);
    }
}
