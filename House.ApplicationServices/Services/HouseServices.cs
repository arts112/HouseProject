using House.Core.Domain;
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
            houses.Address = dto.Address;
            houses.Size = dto.Size;
            houses.Price = dto.Price;
            houses.Description = dto.Description;

            await _context.Houses.AddAsync(houses);
            await _context.SaveChangesAsync();
            return houses;
        
        }

        public async Task<Houses> Delete(Guid id)
        {
            var HousesId = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Houses.Remove(HousesId);
            await _context.SaveChangesAsync();

            return HousesId;
        }

        public async Task<Houses> Update(HouseDto dto)
        {
            Houses houses = new Houses();

            houses.Id = dto.Id;
            houses.Address = dto.Address;
            houses.Size = dto.Size;
            houses.Price = dto.Price;
            houses.Description = dto.Description;

            _context.Houses.Update(houses);
            await _context.SaveChangesAsync();
            return houses;
        }

        public async Task<Houses> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
