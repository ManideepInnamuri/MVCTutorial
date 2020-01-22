using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAPI.Models
{
    //Plain old CLR Object - POCO
    //It doesn't have any implementation and is just having some Properties
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public Genere Genere { get; set; }
        [Required]
        [Display(Name ="Genere")]
        public int GenereId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }        
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [NumberinStockBetween1and20]
        public int NumberinStock { get; set; }
    }
}