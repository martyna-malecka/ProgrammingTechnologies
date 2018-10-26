using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Catalog<T> : IEnumerable
    {
        private List<T> catalog;

        public Catalog()
        {
            catalog = new List<T>();
        }

        public void Add(T obj)
        {
            catalog.Add(obj);
        }

        public void Remove(T obj)
        {
            catalog.Remove(obj);
        }

        public List<T> GetCatalog()
        {
            return catalog;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
