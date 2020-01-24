using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Common.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
                
        [Required]
        public int GenereId { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }        
        public DateTime? DateAdded { get; set; }

        [Required]        
        public int NumberinStock { get; set; }
    }
}