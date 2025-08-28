using Microsoft.AspNetCore.Mvc;
using ABC_Retail.Data;
using ABC_Retail.Models;
using ABC_Retail.Services;

namespace ABC_Retail.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly QueueService _queueService;

        public ProductsController(ApplicationDbContext context, QueueService queueService)
        {
            _context = context;
            _queueService = queueService;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                await _queueService.SendMessageAsync(new
                {
                    Action = "ProductCreated",
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CreatedAt = DateTime.UtcNow
                });

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

                await _queueService.SendMessageAsync(new
                {
                    Action = "ProductDeleted",
                    Name = product.Name,
                    ImageUrl = product.ImageUrl,
                    DeletedAt = DateTime.UtcNow
                });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
