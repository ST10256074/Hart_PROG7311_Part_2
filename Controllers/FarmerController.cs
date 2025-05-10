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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FarmerModelID,Name,Username,Password,Address,ProfilePicture,PhoneNumber,CreateedAt")] FarmerModel farmerModel)
        {
            if (ModelState.IsValid)
            {
                fr.Post(farmerModel);
                return RedirectToAction(nameof(Index));
            }
            return View(farmerModel);
        }

        // GET: Farmer/Edit/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FarmerModelID,Name,Username,Password,Address,ProfilePicture,PhoneNumber,CreateedAt")] FarmerModel farmerModel)
        {
            if (id != farmerModel.FarmerModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                fr.Update(farmerModel);
                return RedirectToAction(nameof(Index));
            }
            return View(farmerModel);
        }

        // GET: Farmer/Delete/5
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
