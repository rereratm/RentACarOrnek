using FluentValidation;
using RentACar.DAL.Dtos.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Owner
{
    public class OwnerAddValidator : AbstractValidator<AddOwnerDto>
    {
        public OwnerAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz.")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Soyadı Alanı Boş Bırakılamaz.")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz.");
        }
    }
}
