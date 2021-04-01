using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Services;

namespace Client.Controllers
{
    public class AnimalController : Controller
    {
        private IAnimalService animalService { get; }

        public AnimalController(IAnimalService animalService) => this.animalService = animalService;

        // GET: AnimalController
        public async Task<IActionResult> Index()
        {
            return View(await animalService.GetAnimals());
        }

        // GET: AnimalController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            return View(await animalService.GetAnimal(id));
        }

        // GET: AnimalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AnimalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
