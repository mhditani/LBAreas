using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Entities.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        public string Code { get; set; } = "";

        public string Name { get; set; } = "";

        public string? RegionImageUrl { get; set; }
    }
}
