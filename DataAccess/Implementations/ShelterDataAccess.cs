using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using Domain.Models;
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

        public async Task<Shelter> AsyncInsert(ShelterUpdateModel shelter)
        {
            var data = await dbContext.AddAsync(mapper.Map<Entities.Shelter>(shelter));
            await dbContext.SaveChangesAsync();
            return mapper.Map<Shelter>(data.Entity);
        }

        public async Task<IEnumerable<Shelter>> AsyncGet()
        {
            return mapper.Map<IEnumerable<Shelter>>
                (await dbContext.Shelter.ToListAsync());
        }

        public async Task AsyncDelete(IShelterContainer shelterId)
        {
            Entities.Shelter shelter= dbContext.Shelter.Where(a => a.Id == shelterId.ShelterId).FirstOrDefault();

            if (shelter == null)
                throw new InvalidOperationException("Entity with such ID does not exist");

            dbContext.Shelter.Remove(shelter);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Shelter> AsyncUpdate(ShelterUpdateModel shelter)
        {
            if (shelter == null)
                throw new ArgumentNullException(nameof(shelter));

            var existingEntity = await dbContext.Shelter.FirstOrDefaultAsync(e => e.Id == shelter.Id);

            if (existingEntity == null)
                throw new ArgumentException("No entity with such ID");

            var res = mapper.Map(shelter, existingEntity);

            dbContext.Update(res);
            await dbContext.SaveChangesAsync();
            return mapper.Map<Shelter>(res);
        }

    }
}