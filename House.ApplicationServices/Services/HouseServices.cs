﻿using House.Core.Domain;
using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace House.ApplicationServices.Services
{
    public class HouseServices : IHouseService
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
            HouseDbContext context
            )

        {
            _context = context;
        }
        public async Task<Houses> Add(HouseDto dto)
        {
            Houses houses = new Houses();

            houses.Id = Guid.NewGuid();
            houses.Adress = dto.Adress;
            houses.Size = dto.Size;
            houses.Price = dto.Price;
            houses.Description = dto.Description;

            await _context.Houses.AddAsync(houses);
            await _context.SaveChangesAsync();
            return houses;
        
    }
    }
}
