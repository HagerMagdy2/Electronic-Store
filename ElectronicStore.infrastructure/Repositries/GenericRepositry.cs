﻿using ElectronicStore.Core.Interfaces;
using ElectronicStore.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : class

    {
        private readonly AppDbContext _context;
        public GenericRepositry(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var entity= await _context.Set<T>().FindAsync(Id);
            return entity;
        }

        public Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            var entity = query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == Id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task IGenericRepositry<T>.GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepositry<T>.GetByIdAsync(int Id, params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
