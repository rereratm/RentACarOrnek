using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dtos.Car;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly RentACarDbContext _rentACarDbContext;
        public CarService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }
        public async Task<List<GetListCarDto>> GetCarList()
        {
            return await _rentACarDbContext.Cars.Include(p => p.OwnerFK).Where(p => !p.IsDeleted).Select(p => new GetListCarDto
            {
                Id = p.Id,
                Brand = p.Brand,
                Model = p.Model,
                Year = p.Year,
                GasDieselElectric = p.GasDieselElectric,
                OwnerId = p.OwnerFK.Id,
                OwnerName = p.OwnerFK.Name,
                OwnerSurname = p.OwnerFK.Surname
            }).ToListAsync();
        }
        public async Task<GetCarDto> GetCarById(int id)
        {
            return await _rentACarDbContext.Cars.Include(p => p.OwnerFK).Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetCarDto
            {
                Id = p.Id,
                Brand = p.Brand,
                Model = p.Model,
                GasDieselElectric = p.GasDieselElectric,
                Year = p.Year,
                OwnerId = p.OwnerFK.Id,
                OwnerName = p.OwnerFK.Name,
                OwnerSurname = p.OwnerFK.Surname
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddCar(AddCarDto addCarDto)
        {
            var newCar = new Car
            {
                Brand = addCarDto.Brand,
                Model = addCarDto.Model,
                GasDieselElectric = addCarDto.GasDieselElectric,
                Year = addCarDto.Year,
                OwnerId = addCarDto.OwnerId
            };
            await _rentACarDbContext.Cars.AddAsync(newCar);
            return await _rentACarDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCar(int id, UpdateCarDto updateCarDto)
        {
            var currentCar = await _rentACarDbContext.Cars.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCar != null)
            {
                currentCar.Brand = updateCarDto.Brand;
                currentCar.Model = updateCarDto.Model;
                currentCar.GasDieselElectric = updateCarDto.GasDieselElectric;
                currentCar.Year = updateCarDto.Year;
                currentCar.MDate = DateTime.Now;
                _rentACarDbContext.Cars.Update(currentCar);
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteCar(int id)
        {
            var currentCar = await _rentACarDbContext.Cars.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCar != null)
            {
                currentCar.IsDeleted = true;
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
