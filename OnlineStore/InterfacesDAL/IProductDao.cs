using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IProductDao
    {
        bool Add(Product product);
    }
}
