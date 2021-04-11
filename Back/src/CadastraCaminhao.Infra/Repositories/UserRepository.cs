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
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IList<User>> GetAll()
        {
            var query = _context.Users.AsNoTracking();

            return await query.Select(x => new User { Id = x.Id, Email = x.Email, Login = x.Login, Name = x.Name, Role = x.Role }).ToListAsync();

        }

        public async Task<User> GetById(string id)
        {
            var query = _context.Users.AsNoTracking();

            return await query.Where(x => x.Id.ToString() == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetValidate(string login, string password)
        {
            var query = _context.Users.AsNoTracking();

            return await query.Where(x => x.Login == login && x.Password == password).Select(x => new User
            {
                Id = x.Id,
                Email = x.Email,
                Login = x.Login,
                Name = x.Name,
                Role = x.Role
            }).FirstOrDefaultAsync();
        }
    }
}
