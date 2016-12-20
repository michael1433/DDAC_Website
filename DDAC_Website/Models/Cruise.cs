using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DDAC_Website.Models
{
    public class Cruise
    {
        public int id { get; set; }
        [Display(Name = "Cruise Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime cruise_start_date { get; set; }


        [Required]
        public string cruise_name { get; set; }


        [Display(Name = "Cruise End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime cruise_end_date { get; set; }

        public int cruise_duration { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        [StringLength(40)]
        public string Continent { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

    }
}