using Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class ShelterController : Controller
    {
        private IShelterService shelterService { get; }

        public ShelterController(IShelterService shelterService) => this.shelterService = shelterService;

        // GET: ShelterController
        public async Task<ActionResult> IndexAsync()
        {
            return View(await shelterService.GetShelters());
        }

        // GET: ShelterController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            return View(await shelterService.GetShelter(id));
        }

        // GET: ShelterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShelterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShelterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShelterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
