using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrud.Models
{
    public class Country
    {
        [Key]
        public int Country_id { get; set; }
        public string Country_name { get; set; }
    }
}