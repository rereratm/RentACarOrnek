using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dtos.Owner;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class OwnerService : IOwnerService
    {
        private readonly RentACarDbContext _rentACarDbContext;
        public OwnerService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }
        public async Task<List<GetListOwnerDto>> GetOwnerList()
        {
            return await _rentACarDbContext.Owners.Where(p => !p.IsDeleted).Select(p => new GetListOwnerDto
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname
            }).ToListAsync();
        }
        public async Task<GetOwnerDto> GetOwnerById(int id)
        {
            return await _rentACarDbContext.Owners.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetOwnerDto
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddOwner(AddOwnerDto addOwnerDto)
        {
            var newOwner = new Owner
            {
                Name = addOwnerDto.Name,
                Surname = addOwnerDto.Surname
            };
            await _rentACarDbContext.Owners.AddAsync(newOwner);
            return await _rentACarDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateOwner(int id, UpdateOwnerDto updateOwnerDto)
        {
            var currentOwner = await _rentACarDbContext.Owners.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentOwner != null)
            {
                currentOwner.Name = updateOwnerDto.Name;
                currentOwner.Surname = updateOwnerDto.Surname;
                currentOwner.MDate = DateTime.Now;
                _rentACarDbContext.Owners.Update(currentOwner);
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteOwner(int id)
        {
            var currentOwner = await _rentACarDbContext.Owners.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentOwner != null)
            {
                currentOwner.IsDeleted = true;
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
