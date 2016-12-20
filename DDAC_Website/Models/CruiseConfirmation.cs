using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDAC_Website.Models
{
    public class CruiseConfirmation
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        [StringLength(20)]
        public string f_name { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        [StringLength(20)]
        public string l_name { get; set; }

        [Required]
        [StringLength(40)]
        public string address { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        [StringLength(20)]
        public string city { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        [StringLength(20)]
        public string state { get; set; }

        [Required]
        [RegularExpression(@"[0-9]+")]
        public int zipcode { get; set; }

        [Required]
        [RegularExpression(@"[+,-,0-9]+")]
        public string mobile_num { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-z,0-9]+[@]+[a-zA-Z]+[.]+[a-zA-Z]+")]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string stateRoom { get; set; }

        [Required]
        public int state_room_quantity { get; set; }

        public int num_of_people_in_a_room { get; set; }
        public double total_payment { get; set; }
        public string payment_status { get; set; }
        public string username { get; set; }





    }
}