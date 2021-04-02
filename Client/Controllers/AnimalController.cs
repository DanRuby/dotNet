using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Services;
using Client.Models;

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
        public async Task<ActionResult> CreateAsync(IFormCollection collection)
        {
            try
            {
                AnimalCreateDTO animal = new AnimalCreateDTO();
                animal.Name=collection["Name"];
                animal.MoneyNeededPerMonth = decimal.Parse(collection["MoneyNeededPerMonth"]);
                animal.ArrivalDate = DateTime.Parse(collection["ArrivalDate"]);
                animal.BirthDate = DateTime.Parse(collection["BirthDate"]);
                animal.ShelterId = Int32.TryParse(collection["ShelterId"], out var tempVal) ? tempVal : (int?)null;

                var animalDTO=await animalService.AddAnimal(animal);
                return View("Details",animalDTO);
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
        public async Task<ActionResult> EditAsync(int id, IFormCollection collection)
        {
            try
            {
                AnimalUpdateDTO animal = new AnimalUpdateDTO();
                animal.Id = id;
                animal.Name = collection["Name"];
                animal.MoneyNeededPerMonth = decimal.Parse(collection["MoneyNeededPerMonth"]);
                animal.ArrivalDate = DateTime.Parse(collection["ArrivalDate"]);
                animal.BirthDate = DateTime.Parse(collection["BirthDate"]);
                animal.ShelterId = Int32.TryParse(collection["ShelterId"], out var tempVal) ? tempVal : (int?)null;

                var animalDTO = await animalService.UpdateAnimal(animal);
                return View("Details", animalDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: AnimalController/Edit/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnimalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                await animalService.DeleteAnimal(id);
                return View("Index",await animalService.GetAnimals());
            }
            catch
            {
                return View();
            }
        }

    }
}
