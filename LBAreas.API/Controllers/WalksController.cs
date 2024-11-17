using AutoMapper;
using LBAreas.Entities.Models.Domain;
using LBAreas.Entities.Models.DTO;
using LBAreas.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LBAreas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository repo;

        public WalksController(IMapper mapper, IWalkRepository repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }







        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map Dto to Domain model
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            await repo.CreateAsync(walkDomain);


            // Map domain to DTO
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }













        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomain = await repo.GetAllAsync();
            // Map Domain to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomain));
        }
    }
}
