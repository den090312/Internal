using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderDao orderDao;

        public OrderLogic(IOrderDao iOrderDao)
        {
            NullCheck(iOrderDao);

            orderDao = iOrderDao;
        }

        public bool Add(Order order)
        {
            NullCheck(order);
            EmptyStringCheck(order.Number);

            //ToDo проверка на формат номера заказа

            NegativeZeroIntCheck(order.UserId);

            //TODo проверка существования юзера

            OrderDateCheck(order);

            NullCheck(order.ListProduct);
            OrderListProductCheck(order.ListProduct);
            NegativeZeroDecimalCheck(order.Sum);

            return orderDao.Add(order);
        }

        private void OrderDateCheck(Order order)
        {
            EmptyDateTimeCheck(order.Date);
            PastDateTimeCheck(order.Date);
        }

        private void PastDateTimeCheck(DateTime value)
        {
            if (value <= DateTime.Now)
            {
                throw new ArgumentException($"{nameof(value)} is less than current date!");
            }
        }

        private void EmptyDateTimeCheck(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                throw new ArgumentException($"{nameof(value)} is empty!");
            }
        }

        private void NegativeZeroDecimalCheck(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} must be more than zero");
            }
        }

        private void NegativeZeroIntCheck(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} must be more than zero");
            }
        }

        private void OrderListProductCheck(List<Product> listProduct)
        {
            if (listProduct.Count == 0)
            {
                throw new ArgumentException($"{nameof(listProduct)} is empty!");
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
