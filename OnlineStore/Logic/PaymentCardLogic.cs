using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PaymentCardLogic : IPaymentCardLogic
    {
        private readonly IPaymentCardDao paymentCardDao;

        public PaymentCardLogic(IPaymentCardDao iPaymentCardDao)
        {
            NullCheck(iPaymentCardDao);

            paymentCardDao = iPaymentCardDao;
        }

        public bool Add(PaymentCard paymentCard)
        {
            NullCheck(paymentCard);
            NullCheck(paymentCard.Number);
            EmptyStringCheck(paymentCard.Number);

            //ToDo проверка формата номера карты

            NullCheck(paymentCard.FirstName);
            EmptyStringCheck(paymentCard.FirstName);

            paymentCard.FirstName = paymentCard.FirstName.ToUpper();

            NullCheck(paymentCard.LastName);
            EmptyStringCheck(paymentCard.LastName);

            paymentCard.LastName = paymentCard.LastName.ToUpper();

            //ToDo проверка формата имени-фамилии

            NegativeZeroSByteCheck(paymentCard.ExpirationMonth);
            NegativeZeroSByteCheck(paymentCard.ExpirationYear);

            //ToDo проверка месяца-года истечения карты

            NegativeZeroSByteCheck(paymentCard.VerificationValue);

            return paymentCardDao.Add(paymentCard);
        }

        private void NegativeZeroSByteCheck(sbyte value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} must be more than zero!");
            }
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
