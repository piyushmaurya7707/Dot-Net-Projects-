using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers;

public class CategoriesController : Controller
{
    private readonly AppDbContext _db;
    public CategoriesController(AppDbContext db) => _db = db;


    public async Task<IActionResult> Index()
    {
        var cats = await _db.Categories.Include(c=> c.Transactions).AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        return View(cats);  
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string name)
    {
        name = (name ?? "").Trim();
        if (name.Length is 0 or > 50)
        TempData["Error"] = "Category name must br 1-50 characters. ";
        else if (await _db.Categories.AnyAsync(c => c.name == name ))
           TempData["Error"] = $"Category \"{name}\" already exists. "; 
           else
        {
            _db.Categories.Add(new Category {Name = name });
            await _db.SaveChangesAsync();
            TempData["Success"] = "Category added.";
        }
        return RedirectToAction(nameof(Index));
    }


      [HttpPost, ValidateAntiForgeryToken]
      public async Task<IActionResult> Delete(int id )
    {
        var cat = await _db.Categories.Include(c => c.Transaction).FirstOrDefaultAsync(c => c.Id == id);
        if (cat == null) return NotFound();

        if (cat.Transaction.Any())
        TempData["Error"] = "Can't delete a catogry that still has transactions.";
        else
        {
            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deleted. ";

        }
        return RedirectToAction(nameof(Index));
    }
}