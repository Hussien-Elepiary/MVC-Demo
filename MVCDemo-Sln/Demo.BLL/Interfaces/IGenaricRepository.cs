﻿using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    //this Genaric InterFace Have the most Common Segneturs 
    public interface IGenaricRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        int Add(T item);
        int Update(T item);
        int Delete(T item);
    }
}
