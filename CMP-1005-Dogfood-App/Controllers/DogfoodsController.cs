using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMP_1005_Dogfood_App.Data;
using CMP_1005_Dogfood_Models.Models;

namespace CMP_1005_Dogfood_App.Controllers
{
    public class DogfoodsController : Controller
    {
        private readonly CMP_1005_Dogfood_AppContext _context;

        public DogfoodsController(CMP_1005_Dogfood_AppContext context)
        {
            _context = context;
        }

        // GET: Dogfoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dogfood.ToListAsync());
        }

        // GET: Dogfoods/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogfood = await _context.Dogfood
                .FirstOrDefaultAsync(m => m.UPC == id);
            if (dogfood == null)
            {
                return NotFound();
            }

            return View(dogfood);
        }

        // GET: Dogfoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dogfoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UPC,Name,Description")] Dogfood dogfood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogfood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogfood);
        }

        // GET: Dogfoods/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogfood = await _context.Dogfood.FindAsync(id);
            if (dogfood == null)
            {
                return NotFound();
            }
            return View(dogfood);
        }

        // POST: Dogfoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UPC,Name,Description")] Dogfood dogfood)
        {
            if (id != dogfood.UPC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogfood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogfoodExists(dogfood.UPC))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dogfood);
        }

        // GET: Dogfoods/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogfood = await _context.Dogfood
                .FirstOrDefaultAsync(m => m.UPC == id);
            if (dogfood == null)
            {
                return NotFound();
            }

            return View(dogfood);
        }

        // POST: Dogfoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dogfood = await _context.Dogfood.FindAsync(id);
            _context.Dogfood.Remove(dogfood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogfoodExists(string id)
        {
            return _context.Dogfood.Any(e => e.UPC == id);
        }
    }
}
