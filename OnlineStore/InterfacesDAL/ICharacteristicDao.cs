using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesDAL
{
    public interface ICharacteristicDao
    {
        bool Add(Characteristic characteristic);
    }
}
