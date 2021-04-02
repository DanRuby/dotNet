using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IShelterService
    {
        Task<IEnumerable<ShelterDTO>> GetShelters();

        Task<ShelterDTO> GetShelter(int id);

        Task<ShelterDTO> UpdateShelter(ShelterDTO shelter);

        Task<ShelterDTO> AddShelter(ShelterCreateDTO shelter);

        Task DeleteShelter(int id);
    }
}
