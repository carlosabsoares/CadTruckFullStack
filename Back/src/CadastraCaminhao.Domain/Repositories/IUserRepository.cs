using CadastraCaminhao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);

        Task<User> GetValidate(string login, string password);

        Task<IList<User>> GetAll();
    }
}