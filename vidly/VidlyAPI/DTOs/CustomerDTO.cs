using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAPI.Models;

namespace VidlyAPI.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        [Min18YearsIfAMember]
        public DateTime? DateofBirth { get; set; }
        
        public int MembershipTypeId { get; set; }
    }
}