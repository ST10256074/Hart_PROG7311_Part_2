using Hart_PROG7311_Part_2.Models;
using Hart_PROG7311_Part_2.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hart_PROG7311_Part_2.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository pr = new ProductRepository();

        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                products = pr.FetchProducts();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductModel model = new ProductModel();
            try
            {
                model = pr.FetchProductByID(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        //public ActionResult Create(ProductModel p)
        //{
        //    pr.Create(p);
        //    return Index();
        //}

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductModel p)
        {
            try
            {
                //ProductModel model = new ProductModel();
                //model.
                pr.Create(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            // Fetch Model to assign to Text Boxes
            ProductModel model = new ProductModel();
            try
            {
                model = pr.FetchProductByID(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel p)
        {
            try
            {
                pr.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            // Delete Product After warning
            try
            {
                pr.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
