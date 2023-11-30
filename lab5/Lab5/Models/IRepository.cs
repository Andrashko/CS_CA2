using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    interface IRepository<T>
    {
        //T GetById(int id);
        List<T> GetAll();
    }
}
