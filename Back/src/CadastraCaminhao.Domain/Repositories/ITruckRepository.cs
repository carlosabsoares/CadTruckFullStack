using CadastraCaminhao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Repositories
{
    public interface ITruckRepository
    {
        Task<Truck> GetById(string id);

        Task<IList<Truck>> GetAll();
    }
}