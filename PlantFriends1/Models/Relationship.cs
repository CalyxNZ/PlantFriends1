using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace PlantFriends1.Models
{
    public class Relationship
    {
        public int RelationshipId { get; set; }


        [Display(Name = "The Host Plant")]
        public int? HostPlantId { get; set; }
        [ForeignKey("HostPlantId ")]
        public virtual Plant HostPlant { get; set; }


        [Display(Name = "The Companion/Enemy Plant")]
        public int? CompanionPlantId { get; set; }
        [ForeignKey("CompanionPlantId ")]
        public virtual Plant CompanionPlant { get; set; }


        [Display(Name = "Type of Plant Relationship")]
        public int? RelationshipTypeId { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
    }
}