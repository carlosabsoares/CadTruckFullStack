using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Entities
{
    public class Truck
    {
        public string Id { get; set; }
        public EnumModel Model { get; set; }
        public int YearOfManufacture { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }

        public string Image { get; set; }

        public Truck()
        {
            Id = new Guid().ToString();
            YearOfManufacture = DateTime.Now.Year;
        }

    }


}
