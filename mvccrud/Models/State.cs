using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvccrud.Models
{
    public class State
    {
        [Key]
        public int State_id { get; set; }

        public string State_name { get; set; }

        [ForeignKey("Country")]
        public int? Country_id { get; set; }
        public virtual Country Country { get; set; }
    }
}