using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Entities;

namespace CadastraCaminhao.Domain.Repositories
{
    public interface ITruckRepository
    {
        Task<Truck> GetById(string id);
        Task<IList<Truck>> GetAll(string id) ;
    }
}
