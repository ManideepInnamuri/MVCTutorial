using System.Collections.Generic;
using VidlyAPI.Models;

namespace VidlyAPI.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie{ get; set; }
        public List<Genere> Generes { get; set; }
        public List<Customer> Customers { get; set; }
    }
}