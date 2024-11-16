using AutoMapper;
using LBAreas.Entities.Data;
using LBAreas.Entities.Models.Domain;
using LBAreas.Entities.Models.DTO;
using LBAreas.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBAreas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        
        private readonly IRegionRepository repo;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository repo, IMapper mapper) 
        {
            this.repo = repo;
            this.mapper = mapper;
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await repo.GetAllAsync();

            // Map Domain Models to DTO'S
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }



        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await repo.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Domain Models to DTO'S
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }










        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map Dto to Domain Model
            var regionDomain = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create region
            regionDomain = await repo.CreateAsync(regionDomain);

            // Map Domain model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

















        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model
            var regionDomain = mapper.Map<Region>(updateRegionRequestDto);


            // Check if region exists
            regionDomain =  await repo.UpdateAsync(id, regionDomain);      

            if (regionDomain == null)
            {
                return NotFound();
            }


            // Map Domain to DTO Model
            return Ok(mapper.Map<RegionDto>(regionDomain));
            
        }













        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var regionDomain = await repo.DeleteAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Region Model to DTO
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }
        

        
    }
}
