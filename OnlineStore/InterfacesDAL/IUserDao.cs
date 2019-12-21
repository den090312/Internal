using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface IUserDao
    {
        bool Add(User user);
    }
}
