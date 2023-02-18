using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRepository.Data.Repositories.Interfaces
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void AddRange<T>(List<T> entity) where T : class;
        void Update<T>(T entity) where T : class;
        void UpdateRange<T>(List<T> entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(List<T> entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
