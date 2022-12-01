using FluentValidation;
using RentACar.Business.Abstract;
using RentACar.DAL.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Customer
{
    public class CustomerAddValidator : AbstractValidator<AddCustomerDto>
    {
        private readonly ICustomerService _customerService;
        public CustomerAddValidator(ICustomerService customerService)
        {
            _customerService = customerService;
            RuleFor(p => p.TcNo).NotEmpty().WithMessage("TC No Alanı Boş Bırakılamaz.")
                .Length(11, 11).WithMessage("11 Karakter Girmelisiniz.").Must(AnyTCNumber)
                .WithMessage("Bu TC Numarasına Ait Kayıt Vardır.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz.")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Soyadı Alanı Boş Bırakılamaz.")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz.");
        }
        public bool AnyTCNumber(string tcNumber)
        {
            return !_customerService.AnyTCNumber(tcNumber);
        }
    }
}
