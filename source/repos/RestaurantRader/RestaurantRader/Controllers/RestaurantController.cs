using RestaurantRader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRader.Controllers
{
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        //Post (create)
        //api/Restaurant


        [HttpPost] 
        public async Task<IHttpActionResult> PostRestaurant([FromBody] Restaurant model)
        {

            if(model is null)
            {
                return BadRequest("Your request body cannot be empty.");
            }
            if (ModelState.IsValid)
            {
                //where model is stored in database
                _context.Restaurants.Add(model);
                int changeCount = await _context.SaveChangesAsync();
                return Ok("You did it!");
            }
            //the model is not valid, reject
            return BadRequest(ModelState);
        }

        //api/Restaurant
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        //api.Restaurant/{id}
        [HttpGet]
        public async Task<IHttpActionResult> GetById([FromUri] int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant != null)
            {
                return Ok(restaurant);
            }

            return NotFound();
        } 

        //api/Restaurant/{id}
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant updatedRestaurant)
        {
            //Check that ids match
            if(id != updatedRestaurant?.Id)
            {
                return BadRequest("Ids do not match.");
            }

            //check the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if restaurant does not exist then do something
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            return NotFound();

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurant([FromUri] int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);

            if(restaurant is null)
                return NotFound();

            _context.Restaurants.Remove(restaurant);

            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok("The restaurant was deleted");
            }

            return InternalServerError();
        }
    }
}
