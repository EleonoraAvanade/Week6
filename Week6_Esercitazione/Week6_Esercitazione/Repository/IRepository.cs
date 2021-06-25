using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Esercitazione.Repository
{
    interface IRepository<T>
    {
        public T Create(T item);
        public bool Delete(string id);
        public T GetById(string id);
        public ICollection<T> GetAll();
    }
}
