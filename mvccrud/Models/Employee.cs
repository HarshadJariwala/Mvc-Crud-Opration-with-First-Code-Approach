    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace mvccrud.Models
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public bool Marial_Status { get; set; }

        public DateTime Birthdate { get; set; }

        public string Hobbies { get; set; }

        public string Photo { get; set; }


        public decimal Salary { get; set; }

        public string Address { get; set; }

        //public int Countryname { get; set; }

        //public int Statename { get; set; }

        //public int Cityname { get; set; }

        public string Zipcode { get; set; }

        public string Password { get; set; }

        public DateTime Create_date { get; set; }



        [ForeignKey("Country")]
        public int? Country_id { get; set; }
        public virtual Country Country { get; set; }


        [ForeignKey("City")]
        public int? City_id { get; set; }
        public virtual City City { get; set; }


        [ForeignKey("State")]
        public int? State_id { get; set; }
        public virtual State State { get; set; }
    }
}