using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProjectBB.Models
{
    public class IngredientCreate
    {
         [Required]
        [MaxLength(100, ErrorMessage = "Your ingredient name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
