using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        [Required(ErrorMessage ="Please enter customer's name")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MemberShipType memberShipType { get; set; }

        [Display(Name="MemberShip Type")]
        public byte memberShipTypeId { get; set; }

        
        [Display(Name = "Date of Birth")]
        [Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}