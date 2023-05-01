using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IRepository<T> where T: class
    {
        public Task Create(T modelclass);
        public Task Delete(Guid id);
        public T Get(Guid id);
        public List<T> GetAll(int id);
    }
}
