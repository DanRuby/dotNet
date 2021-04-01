using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    public class AnimalService : IAnimalService
    {
        private HttpClient httpClient { get; }

        public AnimalService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<AnimalDTO> AddAnimal(AnimalCreateDTO animal)
        {
            throw new NotImplementedException();
        }

        public async Task<AnimalDTO> GetAnimal(int id)
        {
            var content = await GetContentAsync("http://localhost:52506/api/Animal/"+id);

            return JsonSerializer.Deserialize<AnimalDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<AnimalDTO>> GetAnimals()
        {

            var content = await GetContentAsync("http://localhost:52506/api/Animal/");

            return JsonSerializer.Deserialize<IEnumerable<AnimalDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<AnimalDTO> UpdateAnimal(AnimalUpdateDTO animal)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetContentAsync(string Url)
        {
            using var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            return  await response.Content.ReadAsStringAsync();
        }
    }
}
