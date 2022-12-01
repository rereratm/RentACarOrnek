using Microsoft.EntityFrameworkCore;
using RentACar.Business.Abstract;
using RentACar.DAL.Context;
using RentACar.DAL.Dtos.Customer;
using RentACar.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly RentACarDbContext _rentACarDbContext;
        public CustomerService(RentACarDbContext rentACarDbContext)
        {
            _rentACarDbContext = rentACarDbContext;
        }
        public async Task<List<GetListCustomerDto>> GetCustomerList()
        {
            return await _rentACarDbContext.Customers.Where(p => !p.IsDeleted).Select(p => new GetListCustomerDto
            {
                Id = p.Id,
                TcNo = p.TcNo,
                Name = p.Name,
                Surname = p.Surname
            }).ToListAsync();
        }
        public async Task<GetCustomerDto> GetCustomerById(int id)
        {
            return await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == id).Select(p => new GetCustomerDto
            {
                Id = p.Id,
                TcNo = p.TcNo,
                Name = p.Name,
                Surname = p.Surname
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddCustomer(AddCustomerDto addCustomerDto)
        {
            var newCustomer = new Customer
            {
                TcNo = addCustomerDto.TcNo,
                Name = addCustomerDto.Name,
                Surname = addCustomerDto.Surname
            };
            await _rentACarDbContext.Customers.AddAsync(newCustomer);
            return await _rentACarDbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateCustomer(int id, UpdateCustomerDto updateCustomerDto)
        {
            var currentCustomer = await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCustomer != null)
            {
                currentCustomer.TcNo = updateCustomerDto.TcNo;
                currentCustomer.Name = updateCustomerDto.Name;
                currentCustomer.Surname = updateCustomerDto.Surname;
                currentCustomer.MDate = DateTime.Now;
                _rentACarDbContext.Customers.Update(currentCustomer);
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public async Task<int> DeleteCustomer(int id)
        {
            var currentCustomer = await _rentACarDbContext.Customers.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
            if (currentCustomer != null)
            {
                currentCustomer.IsDeleted = true;
                return await _rentACarDbContext.SaveChangesAsync();
            }
            return -1;
        }
        public bool AnyTCNumber(string tcNumber)
        {
            return _rentACarDbContext.Customers.Where(p => p.TcNo == tcNumber).Any();
        }
    }
}
