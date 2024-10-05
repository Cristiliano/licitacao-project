﻿using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Licitacao.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LicitacaoContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(LicitacaoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddListAsync(List<T> entities)
        {
            if (entities.Count == 0) return;

            int batchSize = 10;

            for (int i = 0; i < entities.Count; i += batchSize)
            {
                var batch = entities.Skip(i).Take(batchSize).ToList();

                await _dbSet.AddRangeAsync(batch);
            }
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAllByIdAsync(List<Guid> ids)
        {
            if (ids.Count == 0) return false;

            List<T> entities = new List<T>();
            foreach (var id in ids)
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    entities.Add(entity);
                }
            }

            if (entities.Count == 0) return false;

            _dbSet.RemoveRange(entities);
            return true;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            return item!;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}