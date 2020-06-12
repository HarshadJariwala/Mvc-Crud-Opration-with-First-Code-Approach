using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrud.Models
{
    public class City
    {

        [Key]
        public int City_id { get; set; }

        public string City_name { get; set; }

        [ForeignKey("State")]
        public int? State_id { get; set; }
        public virtual State State { get; set; }

    }
}