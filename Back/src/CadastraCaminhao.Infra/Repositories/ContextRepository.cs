﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastraCaminhao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CadastraCaminhao.Infra.Repositories
{
    public class ContextRepository : IContextRepository
    {
        private readonly DataContext _context;

        public ContextRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<bool> Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            return (await _context.SaveChangesAsync()) > 0;
        }
        
    }
}
