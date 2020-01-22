using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAPI.Models
{
    public class NumberinStockBetween1and20:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return (movie.NumberinStock > 0 && movie.NumberinStock <= 20) ? ValidationResult.Success : new ValidationResult("The Field Number in Stock must be between 1 and 20");
        }
    }
}