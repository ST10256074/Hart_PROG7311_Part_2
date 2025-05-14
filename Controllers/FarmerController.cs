using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hart_PROG7311_Part_2.Data;
using Hart_PROG7311_Part_2.Models;
using Hart_PROG7311_Part_2.Repository;

namespace Hart_PROG7311_Part_2.Controllers
{
    public class FarmerController : Controller
    {
        FarmerRepository fr = new FarmerRepository();

        // GET: Farmer
        public async Task<IActionResult> Index()
        {
            List<FarmerModel> farmers = fr.GetAll();
            return View(farmers);
        }

        // GET: Farmer/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerModel = fr.Get((int)id);
            if (farmerModel == null)
            {
                return NotFound();
            }

            return View(farmerModel);
        }

        // GET: Farmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FarmerModel farmerModel)
        {
            if (ModelState.IsValid)
            {
                if (farmerModel.ProfilePictureFile != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfileImages", farmerModel.ProfilePictureFile.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        farmerModel.ProfilePictureFile.CopyTo(stream);
                    }
                    farmerModel.ProfilePicture = "ProfileImages/" + farmerModel.ProfilePictureFile.FileName;
                }

                fr.Post(farmerModel);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Farmer/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmerModel = fr.Get((int)id);
            if (farmerModel == null)
            {
                return NotFound();
            }
            return View(farmerModel);
        }

        // POST: Farmer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FarmerModel farmerModel)
        {
            if (id != farmerModel.FarmerModelID)
            {
                return NotFound();
            }

            if (farmerModel.ProfilePictureFile != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfileImages", farmerModel.ProfilePictureFile.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    farmerModel.ProfilePictureFile.CopyTo(stream);
                }
                farmerModel.ProfilePicture = "ProfileImages/" + farmerModel.ProfilePictureFile.FileName;
            }
            fr.Update(farmerModel);
            return RedirectToAction(nameof(Index));
        }

        // DELETE: Farmer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            fr.Delete((int)id);

            return RedirectToAction(nameof(Index));
        }
    }
}
