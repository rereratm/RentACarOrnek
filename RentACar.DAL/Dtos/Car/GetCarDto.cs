using AppCore.Entity;

namespace RentACar.DAL.Dtos.Car
{
    public class GetCarDto : IDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string GasDieselElectric { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
    }
}
