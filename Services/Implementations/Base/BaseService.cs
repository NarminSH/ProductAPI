using Microsoft.EntityFrameworkCore;
using ProductAPI.DAL;
using ProductAPI.Models.Common;
using ProductAPI.Services.Interfaces.BaseService;
using ProductAPI.Utilities;
using ProductAPI.Utilities.Exceptions;

namespace ProductAPI.Services.Implementations.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        public BaseService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
           _dbSet.Add(entity);

        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<ResponseMessage> GetAll()
        {
            return new ResponseMessage()
            {
                Data = await _dbSet.ToListAsync(),
                Message = "entities found",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        
        }

        public T GetById(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity== null)
            {
                throw new NotFoundException();
            }
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;

        }
    }
}
