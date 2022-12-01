using FluentValidation;
using RentACar.DAL.Dtos.Car;

namespace RentACar.Business.Validation.Car
{
    public class CarAddValidator : AbstractValidator<AddCarDto>
    {
        public CarAddValidator()
        {
            RuleFor(p => p.Brand).NotEmpty().WithMessage("Marka Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz!");
            RuleFor(p => p.Model).NotEmpty().WithMessage("Model Alanı Boş Bırakılamaz")
                .MaximumLength(20).WithMessage("En Fazla 20 Karakter Girebilirsiniz.");
            RuleFor(p => p.Year).NotEmpty().WithMessage("Yıl Bilgisi Boş Bırakılamaz.");
            RuleFor(p => p.OwnerId).NotEmpty().WithMessage("Sahip ID' si Boş Bırakılamaz.");
        }
    }
}
