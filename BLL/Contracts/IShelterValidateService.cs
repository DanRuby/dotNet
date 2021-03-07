using System.Threading.Tasks;
using Domain.Contracts;

namespace BLL.Contracts
{
    public interface IShelterValidateService
    {
        Task AsyncValidateShelter(IShelterContainer shelter);
    }
}
