using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ShelterService : IShelterService
    {
        private HttpClient httpClient { get; }

        public ShelterService(HttpClient httpClient) => this.httpClient = httpClient;

        public Task<ShelterDTO> AddShelter(ShelterCreateDTO shelter)
        {
            throw new NotImplementedException();
        }

        public async Task<ShelterDTO> GetShelter(int id)
        {
            var content = await GetContentAsync("http://localhost:52506/api/Shelter/"+id);

            return JsonSerializer.Deserialize<ShelterDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<ShelterDTO>> GetShelters()
        {
            var content = await GetContentAsync("http://localhost:52506/api/Shelter/");

            return JsonSerializer.Deserialize <IEnumerable<ShelterDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<ShelterDTO> UpdateShelter(ShelterDTO shelter)
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetContentAsync(string Url)
        {
            using var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
