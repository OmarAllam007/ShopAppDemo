using Microsoft.AspNetCore.Mvc;
using ShopApp.Web.Data;
using ShopApp.Web.Models;

namespace ShopApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var categoryInDb = _context.Categories.Find(id);

            if (categoryInDb == null)
            {
                return NotFound();
            }

            return View(categoryInDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var categoryInDb = _context.Categories.Find(id);

            if (categoryInDb == null)
            {
                return NotFound();
            }

            return View(categoryInDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var categoryInDb = _context.Categories.Find(id);

            if (categoryInDb == null)
            {
                return NotFound();
            }


            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
