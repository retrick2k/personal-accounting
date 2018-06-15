using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Server.Db
{
    public interface IRepository<T, V> : IDisposable
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(V id);
        T Create(T item);
        void Update(T item);
        T Delete(T item);
    }
}
