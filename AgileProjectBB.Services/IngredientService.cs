using AgileProjectBB.Data;
using AgileProjectBB.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AgileProjectBB.Services
{
    public class IngredientService
    {
        private readonly Guid _cookId;     
        public IngredientService (Guid Id)
        {
            _cookId = Id;
        }
        public bool CreateIngredient(IngredientCreate model)
        {
            
            var entity =
                  new Ingredient()
                  {
                      CookId = _cookId,
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
                                .Where(e => e.CookId == _cookId)
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
        public IngredientDetails GetIngredientById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                                .Ingredients
                                .Single(e => e.Id == id && e.CookId == _cookId);
                return
                    new IngredientDetails
                    {
                        IngredientId = entity.Id,
                        Name = entity.Name,
                        Price = entity.Price,
                        CreationDate = entity.CreationDate
                    };
            }
        }
    }
}

