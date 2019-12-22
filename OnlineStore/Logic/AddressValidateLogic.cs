using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic
    {
        public bool IsValid<T>(T address, out List<KeyValuePair<string, string>> errors) where T : class
        {
            errors = new List<KeyValuePair<string, string>>();

            if (address != null)
            {
                //ToDo реализация валидации
            }

            return errors.Count == 0;
        }
    }
}
