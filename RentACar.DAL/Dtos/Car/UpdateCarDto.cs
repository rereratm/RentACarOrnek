using AppCore.Entity;

namespace RentACar.DAL.Dtos.Car
{
    public class UpdateCarDto : IDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string GasDieselElectric { get; set; }
        public int OwnerId { get; set; }
    }
}
