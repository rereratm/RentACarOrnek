using FluentValidation;
using RentACar.DAL.Dtos.CarCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.CarCustomer
{
    public class CarCustomerUpdateValidator : AbstractValidator<UpdateCarCustomerDto>
    {
        public CarCustomerUpdateValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("Araba ID' si Alanı Boş Bırakılamaz.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("Kullanıcı ID' si Alanı Boş Bırakılamaz.");
        }
    }
}
