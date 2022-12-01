using AppCore.Entity;
using System.Collections.Generic;

namespace RentACar.DAL.Entities
{
    public class Owner : Audit, IEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Car> Cars { get; set; }
        public bool IsDeleted { get; set; }
    }
}
