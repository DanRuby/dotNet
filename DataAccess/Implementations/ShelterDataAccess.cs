using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementations
{
    public class ShelterDataAccess: IShelterDataAccess
    {
        private AnimalSherlterContext dbContext { get; }
        private IMapper mapper { get; }

        public ShelterDataAccess(IMapper mapper, AnimalSherlterContext context)
        {
            this.mapper = mapper;
            dbContext = context;
        }

        public async Task<Shelter> AsyncGet(IShelterContainer shelter)
        {
            return shelter.ShelterId.HasValue
                ?mapper.Map<Shelter>(await dbContext.Shelter.FirstOrDefaultAsync(e=>e.Id==shelter.ShelterId))
                :null;
        }

        public async Task<Shelter> AsyncInsert(IShelterContainer shelter)
        {
            var data = await dbContext.AddAsync(mapper.Map<Entities.Shelter>(shelter));
            await dbContext.SaveChangesAsync();
            return mapper.Map<Shelter>(data.Entity);
        }
    }
}