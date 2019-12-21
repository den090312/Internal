using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PriceLogic : IPriceLogic
    {
        private readonly IPriceDao priceDao;

        public PriceLogic(IPriceDao iPriceDao)
        {
            NullCheck(iPriceDao);

            priceDao = iPriceDao;
        }

        public bool Add(Price price)
        {
            NullCheck(price);
            DateTimeCheck(price.Date);
            NullCheck(price.Currency);
            NegativeZeroDecimalCheck(price.Value);

            return priceDao.Add(price);
        }

        private void NegativeZeroDecimalCheck(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} must be more than zero");
            }
        }

        private void DateTimeCheck(DateTime value)
        {
            if (value <= DateTime.Now)
            {
                throw new ArgumentException($"{nameof(value)} is less than current date!");
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
