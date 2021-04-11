using System;

namespace CadastraCaminhao.Domain.Entities
{
    public class Truck
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public EnumModel Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }

        public string Image { get; set; }

        public Truck()
        {
            Id = Guid.NewGuid().ToString();
            YearOfManufacture = DateTime.Now.Year;
        }
    }
}