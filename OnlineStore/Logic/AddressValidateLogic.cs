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

            if (!IsNull(address))
            {
                //ToDo реализация валидации
            }

            return errors.Count == 0;
        }

        private bool IsNull<T>(T address) where T : class
        {
            if (address is null)
            {
                return true;

                throw new ArgumentNullException($"{nameof(address)} is null!");
            }
            else
            {
                return false;
            }
        }
    }
}
