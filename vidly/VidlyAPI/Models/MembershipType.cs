using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAPI.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Display(Name ="Membership Type")]
        public string Membership { get; set; }
        [Display(Name = "SignUp Fee")]
        public short SignUpFee { get; set; }
        [Display(Name = "Duration in Months")]
        public byte DurationInMonths { get; set; }
        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }

        public static readonly byte UnKnown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}