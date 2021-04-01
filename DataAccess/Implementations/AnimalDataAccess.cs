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
    public class AnimalDataAccess:IAnimalDataAccess
    {
        private IMapper mapper { get; }
        private AnimalSherlterContext dbContext { get; }

        public AnimalDataAccess(IMapper mapper, AnimalSherlterContext context)
        {
            this.mapper = mapper;
            dbContext = context;
        }

        public async Task<Animal> AsyncInsert(AnimalUpdateModel animal)
        {
            var data = await dbContext.AddAsync(mapper.Map<Entities.Animal>(animal));
            await dbContext.SaveChangesAsync();
            return mapper.Map<Animal>(data.Entity);
        }

        public async Task<IEnumerable<Animal>> AsyncGet()
        {
            return mapper.Map<IEnumerable<Animal>>
                (await dbContext.Animal.Include(e => e.Shelter).ToListAsync());
        }

        public async Task<Animal> AsyncGet(IAnimalIdentity animal) => mapper.Map<Animal>(await GetAnimal(animal));

        public async Task<Animal> AsyncUpdate(AnimalUpdateModel animal)
        {
            var existingEntity = await GetAnimal(animal);

            var res = mapper.Map(animal, existingEntity);

            dbContext.Update(res);
            await dbContext.SaveChangesAsync();
            return mapper.Map<Animal>(res);
        }

        private async Task<Entities.Animal> GetAnimal(IAnimalIdentity animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal));
            
            return await dbContext.Animal.Include(e => e.Shelter)
                .FirstOrDefaultAsync(e => e.Id == animal.Id);
        }

        public async Task AsyncDelete(IAnimalIdentity animalId)
        {
            Entities.Animal animal = dbContext.Animal.Where(a => a.Id == animalId.Id).FirstOrDefault();

            if (animal == null)
                throw new InvalidOperationException("Entity with such ID does not exist");

            dbContext.Animal.Remove(animal);
            await dbContext.SaveChangesAsync();
        }
    }
}
