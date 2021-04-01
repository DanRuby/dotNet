using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Client.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShelterController : ControllerBase
    {
        private ILogger<AnimalController> logger { get; }
        private IShelterCreateService shelterCreateService { get; }
        private IShelterGetService shelterGetService { get; }

        private IMapper mapper { get; }

        public ShelterController(ILogger<AnimalController> logger, IMapper mapper, IShelterCreateService shelterCreateService, IShelterGetService shelterGetService)
        {
            this.logger = logger;
            this.shelterCreateService = shelterCreateService;
            this.shelterGetService = shelterGetService;
            this.mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ShelterDTO> PutAsync(ShelterCreateDTO shelter)
        {
            logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await shelterCreateService.AsyncCreate(mapper.Map<ShelterUpdateModel>(shelter));

            return mapper.Map<ShelterDTO>(result);
        }


        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ShelterDTO>> GetAsync()
        {
            logger.LogTrace($"{nameof(this.GetAsync)} called");

            return mapper.Map<IEnumerable<ShelterDTO>>(await shelterGetService.AsyncGet());
        }

        [HttpGet]
        [Route("{shelterId}")]
        public async Task<ShelterDTO> GetAsync(int shelterId)
        {
            logger.LogTrace($"{nameof(this.GetAsync)} called for {shelterId}");

            return mapper.Map<ShelterDTO>(await shelterGetService.AsyncGet(new ShelterIdentityModel(shelterId)));
        }


    }
}
