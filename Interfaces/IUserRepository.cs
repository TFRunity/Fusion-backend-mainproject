using Fusion.Models;
using Fusion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public Task Create(RegisterViewModel viewModel);
        public Task Delete(string email);
        public Task<T> Get(string email);
        public List<T> GetAll();
        public Task Update(T updatingmodel);
    }
}
