using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class CharacteristicLogic : ICharacteristicLogic
    {
        private readonly ICharacteristicDao characteristicDao;

        public CharacteristicLogic(ICharacteristicDao iCharacteristicDao)
        {
            characteristicDao = iCharacteristicDao;
        }

        public bool Add(Characteristic characteristic)
        {
            NullCheck(characteristic);         
            CharacteristicNameCheck(characteristic.Name);
            NegativeZeroDoubleCheck(characteristic.Value);
            NullCheck(characteristic.UnitOfMeasurement);

            characteristic.Name = characteristic.Name.ToLower();

            return characteristicDao.Add(characteristic);
        }

        private void CharacteristicNameCheck(string name)
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

        private void NegativeZeroDoubleCheck(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(value)} is less than zero!");
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
