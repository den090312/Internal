using Entities;
using InterfacesBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AddressValidateLogic : IValidateLogic
    {
        public Validator GetValidator<T>(T validatedObject) where T: class
        {
            var validator = new Validator();

            if (validatedObject is null)
            {
                throw new ArgumentNullException($"{nameof(validatedObject)} is null!");
            }
            else
            {
                var errors = new List<(Validator.ErrorType, string, string)>();

                //ToDO валидация адреса
            }

            return validator;
        }
    }
}
