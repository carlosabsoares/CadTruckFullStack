﻿using System.Threading.Tasks;

namespace CadastraCaminhao.Domain.Repositories
{
    public interface IContextRepository
    {
        Task<bool> Add<T>(T entity) where T : class;

        Task<bool> Update<T>(T entity) where T : class;

        Task<bool> Delete<T>(T entity) where T : class;
    }
}