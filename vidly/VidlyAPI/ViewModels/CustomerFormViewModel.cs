using System.Collections.Generic;
using VidlyAPI.Models;

namespace VidlyAPI.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes{ get; set; }
        public Customer Customer { get; set; }
    }
}