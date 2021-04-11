using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Entities;

namespace CadastraCaminhao.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<User> GetValidate(string login, string password);
        Task<IList<User>> GetAll();
    }
}
