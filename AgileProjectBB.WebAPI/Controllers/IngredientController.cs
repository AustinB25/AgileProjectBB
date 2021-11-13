using AgileProjectBB.Models;
using AgileProjectBB.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileProjectBB.WebAPI.Controllers
{
    [Authorize]
    public class IngredientController : ApiController
    {
        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }
        public IHttpActionResult Get(string SKU)
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredient = ingredientService.GetIngredientById(SKU);
            return Ok(ingredient);
        }
        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateIngredientService();
            if (!service.CreateIngredient(ingredient))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(IngredientUpdate updatedIngredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateIngredientService();
            if (!service.IngregientUpdate(updatedIngredient))
                 return InternalServerError();
            return Ok();
        }
        private IngredientService CreateIngredientService()
        {
            var Id = Guid.Parse(User.Identity.GetUserId());
            var ingredientService = new IngredientService(Id);
            return ingredientService;
        }
   
    }
}
  