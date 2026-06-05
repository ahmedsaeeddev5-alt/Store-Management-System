using CRUD_Smartstore.Models;
using CRUD_Smartstore.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Smartstore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string search)
        {
            var products = _repo.GetAll(search);
            ViewBag.Search = search;
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                TempData["SuccessData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                TempData["SuccessData"] = "Item has been Updated successfully";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            TempData["SuccessData"] = "Item has been delete successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }
    }
}
