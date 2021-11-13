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
        [MaxLength(15, ErrorMessage = "Your ingredient SKU cannot be longer than 15 characters.")]
        [MinLength(3, ErrorMessage = "Your ingredient SKU has to be at least 3 characters.")]
        public string SKU { get; set; }
         [Required]
        [MaxLength(100, ErrorMessage = "Your ingredient name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
