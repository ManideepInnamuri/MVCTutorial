using Common.Models;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes{ get; set; }
        public Customer Customer { get; set; }
    }
}