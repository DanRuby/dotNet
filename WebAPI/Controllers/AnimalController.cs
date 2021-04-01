using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contracts;
using AutoMapper;
using Domain.Models;
using Client.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private ILogger<AnimalController> logger { get; }
        private IAnimalCreateService animalCreateService { get; }
        private IAnimalGetService animalGetService { get; }
        private IAnimalUpdateService animalUpdateService { get; }
        private IAnimalDeleteService animalDeleteService { get; }
        private IMapper mapper { get; }

        public AnimalController(ILogger<AnimalController> logger, IMapper mapper, IAnimalUpdateService animalUpdateService, 
            IAnimalGetService animalGetService, IAnimalCreateService animalCreateService, IAnimalDeleteService animalDeleteService)
        {
            this.logger = logger;
            this.animalCreateService = animalCreateService;
            this.animalGetService = animalGetService;
            this.animalUpdateService = animalUpdateService;
            this.animalDeleteService = animalDeleteService;
            this.mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<AnimalDTO> PutAsync(AnimalCreateDTO animal)
        {
            logger.LogTrace($"{nameof(this.PutAsync)} called");


            var result = await animalCreateService.AsyncCreate(mapper.Map<AnimalUpdateModel>(animal));

            return mapper.Map<AnimalDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<AnimalDTO> PatchAsync(AnimalUpdateDTO animal)
        {
            logger.LogTrace($"{nameof(this.PatchAsync)} called");

            var result = await animalUpdateService.AsyncUpdate(mapper.Map<AnimalUpdateModel>(animal));

            return mapper.Map<AnimalDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AnimalDTO>> GetAsync()
        {
            logger.LogTrace($"{nameof(this.GetAsync)} called");

            return mapper.Map<IEnumerable<AnimalDTO>>(await animalGetService.AsyncGet());
        }

        [HttpGet]
        [Route("{animalId}")]
        public async Task<AnimalDTO> GetAsync(int animalId)
        {
            logger.LogTrace($"{nameof(this.GetAsync)} called for {animalId}");

            return mapper.Map<AnimalDTO>(await animalGetService.AsyncGet(new AnimalIdentityModel(animalId)));
        }

        [HttpPut]
        [Route("{animalId}")]
        public async Task DeleteAsync(int animalId)
        {
            logger.LogTrace($"{nameof(this.DeleteAsync)} called for {animalId}");

            await animalDeleteService.DeleteAsynnc(new AnimalIdentityModel(animalId));

        }
    }
}
