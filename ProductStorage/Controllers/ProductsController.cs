using ProductStorage.Core;
using ProductStorage.Core.Models.Products;
using ProductStorage.Core.Services.Products;
using ProductStorage.Data;
using ProductStorage.Services.Products;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProductStorage.Controllers
{
    public class ProductsController : Controller
    {
        private readonly StorageContextMySql _context = new StorageContextMySql();
        private readonly IProductService _service;
        private readonly IContextWorker _worker;
        

        public ProductsController()
        {
            _worker = new ContextWorker(_context);
            _service = new ProductService(_worker);
        }

        // GET: Products
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var products = await _service.GetAll();
            
            return View(products);
        }

        // GET: Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _service.Create(product);

            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}
