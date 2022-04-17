using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using HouseProject.Models.House;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseProject.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseService _houseService;
       
        public HouseController
            (
            HouseDbContext context,
            IHouseService houseServices
            )

        {
            _context = context;
            _houseService = houseServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Houses
                //.OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseListViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    Size = x.Size,
                    Price = x.Price,
                    Description = x.Description,
                });

                return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel housemodel = new HouseViewModel();

            return View("Edit", housemodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel housemodel)
        {
            var dto = new HouseDto()
            {
                Id = housemodel.Id,
                Address = housemodel.Address,
                Size = housemodel.Size,
                Price = housemodel.Price,
                Description = housemodel.Description,
            };
            var result = await _houseService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), housemodel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var housemodel = new HouseViewModel();

            housemodel.Id = house.Id;
            housemodel.Address = house.Address;
            housemodel.Size = house.Size;
            housemodel.Price = house.Price;
            housemodel.Description = house.Description;

            return View(housemodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseViewModel housemodel)
        {
            var dto = new HouseDto()
            {
                Id = housemodel.Id,
                Address = housemodel.Address,
                Size = housemodel.Size,
                Price = housemodel.Price,
                Description = housemodel.Description,
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), housemodel);
        }
    }
}
