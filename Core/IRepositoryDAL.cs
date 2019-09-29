using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepositoryDAL<T>
    {
        void Create(T entity);
        T Restore(int id);
        void Update(T entity);
        void Delete(T entity);

        IList<T> RestoreAll();
    }

}
