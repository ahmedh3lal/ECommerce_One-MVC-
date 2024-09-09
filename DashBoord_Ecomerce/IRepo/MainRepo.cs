using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoord_Ecomerce.IRepo
{
    public class MainRepo<T> : IRepoBase<T> where T : class
    {
        protected AppDbContext context;

        public MainRepo(AppDbContext context)
        {
            this.context = context;
        }
       public async Task<T> CreateAsync(T entity)
        {
            var enter = await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
            return enter.Entity;
        }

        async Task<bool> IRepoBase<T>.DeleteAsync(T entity)
        {
             context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();   
            return true ;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }

        async Task<T> IRepoBase<T>.GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        async Task<T> IRepoBase<T>.UpdateAsync(T entity)
        {

            context.Set<T>().Update(entity); 
            await context.SaveChangesAsync(); 
            return entity; 

        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
