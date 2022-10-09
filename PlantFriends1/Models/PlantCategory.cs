using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlantFriends1.Models
{
    public class PlantCategory
    {
        public int PlantCategoryId { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}