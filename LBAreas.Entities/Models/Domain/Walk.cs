﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBAreas.Entities.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }


        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }



        public Difficulty Difficulty { get; set; } = new Difficulty();

        public Region Region { get; set; } = new Region();
    }
}
