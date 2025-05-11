using Hart_PROG7311_Part_2.Models;
using Hart_PROG7311_Part_2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hart_PROG7311_Part_2.Controllers
{
    //[Authorize]
    //[Authorize(Policy = "Employee")]
    //[Authorize(Roles = "Employee")]
    public class ProductController : Controller
    {
        ProductRepository pr = new ProductRepository();
        FarmerRepository fr = new FarmerRepository();

        [HttpGet]
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

        [HttpGet]
        public ActionResult FarmerIndex(int id)
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                // get ID variable from session
                if (HttpContext.Session.GetString("UserType") == "Employee")
                {
                    // If employee
                    products = pr.FetchProductsByFarmerID((int) id);
                }
                else
                {
                    id = (int) HttpContext.Session.GetInt32("ID");
                }
                products = pr.FetchProductsByFarmerID((int) id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            ViewData["Farmer"] = fr.Get(id);
            return View(products);
        }

        // GET: ProductController/Details/5
        [HttpGet]
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

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductModel p)
        {
            try
            {
                if (p.ImageFile != null)
                {
                    string path =  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "ProductImages", p.ImageFile.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        p.ImageFile.CopyTo(stream);
                    }
                    p.Image = "ProductImages/" + p.ImageFile.FileName;

                    // turn into forward slashes

                }
                pr.Create(p);
                if (HttpContext.Session.GetString("UserType") == "Employee")
                {
                    // If employee
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // If farmer
                    return RedirectToAction(nameof(FarmerIndex));
                }
            }
            catch
            {
                return RedirectToPage("Home");
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
