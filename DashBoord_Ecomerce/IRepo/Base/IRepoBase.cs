﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DashBoord_Ecomerce.IRepo.Base
{
    public interface IRepoBase<T>where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(T entity);
    }
}
