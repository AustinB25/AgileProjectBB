using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProjectBB.Models
{
    public class IngredientDetails
    {

        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }   
        public DateTimeOffset CreationDate { get; set; }
    }
}
