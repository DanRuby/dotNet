using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDTO>> GetAnimals();

        Task<AnimalDTO> GetAnimal(int id);

        Task<AnimalDTO> UpdateAnimal(AnimalUpdateDTO animal);

        Task<AnimalDTO> AddAnimal(AnimalCreateDTO animal);
    }
}
