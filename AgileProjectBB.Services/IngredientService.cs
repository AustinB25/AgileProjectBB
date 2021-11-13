using AgileProjectBB.Data;
using AgileProjectBB.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AgileProjectBB.Services
{
    public class IngredientService
    {
        private readonly Guid _Id;     
        public IngredientService (Guid Id)
        {
            _Id = Id;
        }
        public bool CreateIngredient(IngredientCreate model)
        {

            var entity =
                  new Ingredient()
                  {
                      Id = _Id,
                      SKU = model.SKU,
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
        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                                .Ingredients
                                .Where(e => e.Id == _Id)
                                .Select(
                                            e =>
                                                new IngredientListItem
                                                {
                                                    SKU = e.SKU,
                                                    Name = e.Name
                                                }
                        );
                return query.ToArray();
            }
        }
        public IngredientDetails GetIngredientById(string SKU)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                                .Ingredients
                                .Single(e => e.SKU == SKU && e.Id == _Id);
                return
                    new IngredientDetails
                    {
                        IngredientSKU = entity.SKU,
                        Name = entity.Name,
                        Price = entity.Price,
                        CreationDate = entity.CreationDate
                    };
            }
        }
        public bool IngregientUpdate(IngredientUpdate model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Ingredients
                        .Single(e => e.SKU == model.SKU && e.Id == _Id);
                entity.Name = model.Name;
                entity.Price = model.Price;
                return context.SaveChanges() == 1;
            }
        }
    }
}

