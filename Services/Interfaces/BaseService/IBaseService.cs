using ProductAPI.Utilities;

namespace ProductAPI.Services.Interfaces.BaseService
{
    public interface IBaseService<T>
    {
        public void Add(T entity); 
        public void Delete(T entity); 
        public T GetById(int id); 
        public Task<ResponseMessage> GetAll();
        public T Update(T entity);
    }
}
