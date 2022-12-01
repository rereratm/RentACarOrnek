using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dtos.CarCustomer;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarCustomerService : ICarCustomerService
    {
        private readonly RentACarDbContext _rentACarDbContext;
        public CarCustomerService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }
        public async Task<List<GetListCarCustomerDto>> GetCarCustomerList()
        {
            return await _rentACarDbContext.CarCustomers.Include(p => p.CarFK).Include(p => p.CustomerFK)
                .Where(p => !p.IsDeleted).Select(p => new GetListCarCustomerDto
                {
                    Id = p.Id,
                    CarId = p.CarFK.Id,
                    CarBrand = p.CarFK.Brand,
                    CarModel = p.CarFK.Model,
                    CarYear = p.CarFK.Year,
                    GasDieselElectric = p.CarFK.GasDieselElectric,
                    CustomerId = p.CustomerFK.Id,
                    CustomerTcNo = p.CustomerFK.TcNo,
                    CustomerName = p.CustomerFK.Name,
                    CustomerSurname = p.CustomerFK.Surname
                }).ToListAsync();
        }
        public async Task<GetCarCustomerDto> GetCarCustomerById(int id)
        {
            return await _rentACarDbContext.CarCustomers.Include(p => p.CarFK).Include(p => p.CustomerFK)
                .Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetCarCustomerDto
                {
                    Id = p.Id,
                    CarId = p.CarFK.Id,
                    CarBrand = p.CarFK.Brand,
                    CarModel = p.CarFK.Model,
                    CarYear = p.CarFK.Year,
                    GasDieselElectric = p.CarFK.GasDieselElectric,
                    CustomerId = p.CustomerFK.Id,
                    CustomerTcNo = p.CustomerFK.TcNo,
                    CustomerName = p.CustomerFK.Name,
                    CustomerSurname = p.CustomerFK.Surname
                }).FirstOrDefaultAsync();
        }
        public async Task<int> AddCarCustomer(AddCarCustomerDto addCarCustomerDto)
        {
            var newCarCustomer = new CarCustomer
            {
                CarId = addCarCustomerDto.CarId,
                CustomerId = addCarCustomerDto.CustomerId
            };
            await _rentACarDbContext.CarCustomers.AddAsync(newCarCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCarCustomer(int id, UpdateCarCustomerDto updateCarCustomerDto)
        {
            var currentCarCustomer = await _rentACarDbContext.CarCustomers
                .Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCarCustomer != null)
            {
                currentCarCustomer.CarId = updateCarCustomerDto.CarId;
                currentCarCustomer.CustomerId = updateCarCustomerDto.CustomerId;
                currentCarCustomer.MDate = DateTime.Now;
                _rentACarDbContext.CarCustomers.Update(currentCarCustomer);
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteCarCustomer(int id)
        {
            var currentCarCustomer = await _rentACarDbContext.CarCustomers
                .Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCarCustomer != null)
            {
                currentCarCustomer.IsDeleted = true;
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
    }
}
