using AutoMapper;
using LBAreas.Entities.Models.Domain;
using LBAreas.Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Services.Mappings
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();



            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();




            CreateMap<Difficulty, DifficultyDto>().ReverseMap();


        }
    }
}
