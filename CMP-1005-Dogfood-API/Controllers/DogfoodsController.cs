using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMP_1005_Dogfood_API.Data;
using CMP_1005_Dogfood_Models.Models;

namespace CMP_1005_Dogfood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogfoodsController : ControllerBase
    {
        private readonly CMP_1005_Dogfood_APIContext _context;

        public DogfoodsController(CMP_1005_Dogfood_APIContext context)
        {
            _context = context;
        }

        // GET: api/Dogfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogfood>>> GetDogfood()
        {
            return await _context.Dogfood.ToListAsync();
        }

        // GET: api/Dogfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogfood>> GetDogfood(string id)
        {
            var dogfood = await _context.Dogfood.FindAsync(id);

            if (dogfood == null)
            {
                return NotFound();
            }

            return dogfood;
        }

        // PUT: api/Dogfoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogfood(string id, Dogfood dogfood)
        {
            if (id != dogfood.UPC)
            {
                return BadRequest();
            }

            _context.Entry(dogfood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogfoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dogfoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dogfood>> PostDogfood(Dogfood dogfood)
        {
            _context.Dogfood.Add(dogfood);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DogfoodExists(dogfood.UPC))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDogfood", new { id = dogfood.UPC }, dogfood);
        }

        // DELETE: api/Dogfoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogfood(string id)
        {
            var dogfood = await _context.Dogfood.FindAsync(id);
            if (dogfood == null)
            {
                return NotFound();
            }

            _context.Dogfood.Remove(dogfood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogfoodExists(string id)
        {
            return _context.Dogfood.Any(e => e.UPC == id);
        }
    }
}
