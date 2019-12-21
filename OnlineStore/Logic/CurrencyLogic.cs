using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class CurrencyLogic : ICurrencyLogic
    {
        private readonly ICurrencyDao currencyDao;

        public CurrencyLogic(ICurrencyDao iCurrencyDao)
        {
            NullCheck(iCurrencyDao);

            currencyDao = iCurrencyDao;
        }

        public bool Add(Currency currency)
        {
            NullCheck(currency);
            CurrencyNameCheck(currency.Name);

            currency.Name = currency.Name.ToUpper();

            return currencyDao.Add(currency);
        }

        private void CurrencyNameCheck(string name)
        {
            NullCheck(name);
            EmptyStringCheck(name);
            NameCheck(name);
        }

        private void NameCheck(string name)
        {
            if (!NameIsOk(name))
            {
                throw new ArgumentException($"{nameof(name)} is incorrect!");
            }
        }

        private bool NameIsOk(string name) => name.Length <= 50 && LatinOnly(name);

        private bool LatinOnly(string name)
        {
            var nameLower = name.ToLower();

            foreach (var symbol in nameLower)
            {
                if (symbol >= 'a' && symbol <= 'z')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void EmptyStringCheck(string inputString)
        {
            if (inputString == string.Empty)
            {
                throw new ArgumentException($"{nameof(inputString)} is empty!");
            }
        }

        private void NullCheck<T>(T classObject) where T : class
        {
            if (classObject is null)
            {
                throw new ArgumentNullException($"{nameof(classObject)} is null!");
            }
        }
    }
}
