using AdamsShop.DataModel;
using AdamsShop.Models;
using AdamsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdamsShop.Controllers
{
    public class PiesController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PiesController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository=pieRepository;
            _categoryRepository=categoryRepository;
        }

        public ViewResult Index(string category)
        {
            string? currentCategory;
            IEnumerable<Pie> pie;

            if (string.IsNullOrEmpty(category))
            {
                pie = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pie = _pieRepository.AllPies.Where(c => c.Category.CategoryName == category).OrderBy(p =>p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieIndexViewModel(pie,currentCategory));
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
        /*
        // GET: Pies/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PieId,PieName,ShortDescription,LongDescription,AllergyInformation,Price,ImageUrl,ImageThumbnailUrl,IsPieOfTheWeek,InStock,CategoryId")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // GET: Pies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pies == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies.FindAsync(id);
            if (pie == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // POST: Pies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PieId,PieName,ShortDescription,LongDescription,AllergyInformation,Price,ImageUrl,ImageThumbnailUrl,IsPieOfTheWeek,InStock,CategoryId")] Pie pie)
        {
            if (id != pie.PieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PieExists(pie.PieId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", pie.CategoryId);
            return View(pie);
        }

        // GET: Pies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pies == null)
            {
                return NotFound();
            }

            var pie = await _context.Pies
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.PieId == id);
            if (pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pies == null)
            {
                return Problem("Entity set 'AdamsShopDbContext.Pies'  is null.");
            }
            var pie = await _context.Pies.FindAsync(id);
            if (pie != null)
            {
                _context.Pies.Remove(pie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PieExists(int id)
        {
            return _context.Pies.Any(e => e.PieId == id);
        } */
    }
}
