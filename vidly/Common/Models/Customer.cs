using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Common.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name= "Is Subscribed To News Letter")]
        public bool IsSubscribedToNewsLetter { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{MM/dd/yyyy}")]
        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DateofBirth { get; set; }

        
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
        public string ImagePath { get; set; }
        [NotMapped()]
        public HttpPostedFileBase DocumentFile { get; set; }
    }
}