using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UnitOfMeasurementLogic : IUnitOfMeasurementLogic
    {
        private readonly IUnitOfMeasurementDao unitOfMeasurementDao;

        public bool Add(UnitOfMeasurement unitOfMeasurement)
        {
            NullCheck(unitOfMeasurement);
            PositiveIntCheck(unitOfMeasurement.Id);
            UnitOfMeasurementNameCheck(unitOfMeasurement.Name);

            unitOfMeasurement.Name = unitOfMeasurement.Name.ToLower();

            return unitOfMeasurementDao.Add(unitOfMeasurement);
        }

        private void UnitOfMeasurementNameCheck(string name)
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

        private bool NameIsOk(string name) => name.Length <= 50 && CyrillicOnly(name);

        private bool CyrillicOnly(string name)
        {
            var nameLower = name.ToLower();

            foreach (var symbol in nameLower)
            {
                if (symbol >= 'а' && symbol <= 'я')
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

        private void PositiveIntCheck(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} is less than zero!");
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
