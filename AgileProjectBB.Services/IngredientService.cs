using AgileProjectBB.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AgileProjectBB.Services
{
    public class IngredientService
    {
        private readonly Guid _Id;
        public IngredientService(Guid Id)
        {
            _Id = Id;
        }
        public bool CreateIngredient(Models.IngredientCreate model)
        {
            var entity =
                  new Ingredient()
                  {
                      Id = _Id,
                      Name = model.Name,
                      Price = model.Price,
                      CreationDate = DateTimeOffset.Now
                  };
            using (var context = new ApplicationDbContext())
            {              
                context.Ingredients.Add(entity);
                return context.SaveChanges() == 1;                                
            }
        }
        public IEnumerable<Ingredient> GetIngredients()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                                .Ingredients
                                .Where(e => e.Id == _Id)
                                .Select(
                                            e =>
                                                new Ingredient
                                                {
                                                    Id = e.Id,
                                                    Name = e.Name
                                                }
                        );
                return query.ToArray();
            }
        }
    }
}

