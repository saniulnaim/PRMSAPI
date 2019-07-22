using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRMSAPI.Models.Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Add(T postParam);
        IEnumerable<T> GetAll();
    }
}
