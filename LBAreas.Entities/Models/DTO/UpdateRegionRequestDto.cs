using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Entities.Models.DTO
{
    public class UpdateRegionRequestDto
    {
        [Required, MinLength(2, ErrorMessage = "Code has to be maximum of 2 charachters"), MaxLength(2, ErrorMessage = "Code has to be minimum of 2 charachters")]
        public string Code { get; set; } = "";
        [Required, MaxLength(100, ErrorMessage = "Name has to be maximum of 100 charachters")]

        public string Name { get; set; } = "";

        public string? RegionImageUrl { get; set; }
    }
}
