
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDAC_Website.Models
{
    public class Images
    {
        public int id { get; set; }
        public int cruise_id { get; set; }
        public string imageName { get; set; }
        public byte[] Image { get; set; }
    }
}
