using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlantFriends1.Models
{
    public class Plant
    {
        public int PlantId { get; set; }

        [Display(Name="Plant Name (Common)")]
        public string Name { get; set; }
        public virtual ICollection<Relationship>  PlantRelationships{ get; set; }

        [Display(Name = "Plant Category")]
        public int? PlantCategoryId { get; set; }
        public virtual PlantCategory Category { get; set; }
    }
}