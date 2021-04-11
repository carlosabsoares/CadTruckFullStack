using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Entities;
using CadastraCaminhao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CadastraCaminhao.Infra.Repositories
{
    public class TruckRepository : ITruckRepository
    {

        private readonly DataContext _context;

        public TruckRepository(DataContext context)
        {
            _context = context;
        }

        public TruckRepository(){}

        public async Task<IList<Truck>> GetAll(string id)
        {
            return await _context.Trucks.AsNoTracking().ToListAsync();
        }

        public async Task<Truck> GetById(string id) 
        {
            return await _context.Trucks.AsNoTracking().FirstOrDefaultAsync(x=> x.Id.ToString() == id);
        }
    }
}
