﻿using AutoMapper;
using LBAreas.Entities.Models.Domain;
using LBAreas.Entities.Models.DTO;
using LBAreas.Services.CustomActionFilters;
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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
                // Map Dto to Domain model
                var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

                await repo.CreateAsync(walkDomain);


                // Map domain to DTO
                return Ok(mapper.Map<WalkDto>(walkDomain)); 
        }













        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var walksDomain = await repo.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            // Map Domain to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomain));
        }











        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var walkDomian = await repo.GetByIdAsync(id);

            if (walkDomian == null)
            {
                return NotFound();
            }

            // Map domain to DTO
            return Ok(mapper.Map<WalkDto>(walkDomian));    
        }











        [HttpPut("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            
                //map DTO to Domain
                var walkDomain = mapper.Map<Walk>(updateWalkRequestDto);

                walkDomain = await repo.UpdateAsync(id, walkDomain);

                if (walkDomain == null)
                {
                    return NotFound();
                }

                // Map domain to dto
                return Ok(mapper.Map<WalkDto>(walkDomain));
            
      
        }







        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var deletedWalkDomain = await repo.DeleteAsync(id);

            if (deletedWalkDomain == null)
            {
                return NotFound();
            }

            // Map Domain to DTO
             

            return Ok(mapper.Map<WalkDto>(deletedWalkDomain));
        }
    }
}
