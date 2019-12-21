using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DeliveryLogic : IDeliveryLogic
    {
        private readonly IDeliveryDao deliveryDao;

        public DeliveryLogic(IDeliveryDao iDeliveryDao)
        {
            NullCheck(iDeliveryDao);

            deliveryDao = iDeliveryDao;
        }

        public bool Add(Delivery delivery)
        {
            NullCheck(delivery);
            NullCheck(delivery.Order);
            DeliveryDeadlineCheck(delivery.Deadline);

            return deliveryDao.Add(delivery);
        }

        private void DeliveryDeadlineCheck(DateTime deadLine)
        {
            EmptyDateCheck(deadLine);
            DeadlineCheck(deadLine);

            //ToDo определить и проверять минимальный дэдлайн
        }

        private void DeadlineCheck(DateTime deadLine)
        {
            if (deadLine <= DateTime.Now)
            {
                throw new ArgumentException($"{nameof(deadLine)} is less than current date!");
            }
        }

        private void EmptyDateCheck(DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                throw new ArgumentException($"{nameof(value)} is empty!");
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
