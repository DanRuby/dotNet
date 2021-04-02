using Client.Models;
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
                ShelterCreateDTO shelter= new ShelterCreateDTO()
                {
                    Name = collection["Name"],
                    Address = collection["Address"]
                };

                var shelterlDTO = await shelterService.AddShelter(shelter);
                return View("Details", shelterlDTO);
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
                ShelterDTO shelter = new ShelterDTO()
                {
                    Id=id,
                    Name = collection["Name"],
                    Address = collection["Address"]
                };

                var shelterlDTO = await shelterService.UpdateShelter(shelter);
                return View("Details", shelterlDTO);
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
                await shelterService.DeleteShelter(id);
                return View("Index", await shelterService.GetShelters());
            }
            catch
            {
                return View();
            }
        }
    }
}
