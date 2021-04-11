using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastraCaminhao.Infra.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;

        public TruckRepository(DataContext context)
        {
            _context = context;
        }

        public TruckRepository()
        {
        }

        public async Task<IList<Truck>> GetAll()
        {
            return await _context.Trucks.AsNoTracking().ToListAsync();
        }

        public async Task<Truck> GetById(string id)
        {
            return await _context.Trucks.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}