using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DDAC_Website.Models
{
    public class State
    {
       
       public int id { get; set; }
       public string stateRoomType { get; set; }
       public double stateRoomPrice { get; set; }

        
    }
}