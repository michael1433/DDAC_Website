using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Website.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Location_Name { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime travel_Date { get; set; }
        public int cruise_id { get; set; }
        public string location_coordinate { get; set; }
    }

}
