using Common.Models;
using System.Collections.Generic;

namespace Common.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie{ get; set; }
        public List<Genere> Generes { get; set; }
        public List<Customer> Customers { get; set; }
    }
}