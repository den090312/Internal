using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao iUserDao)
        {
            NullCheck(iUserDao);

            userDao = iUserDao;
        }

        public bool Add(User user)
        {
            NullCheck(user);
            UserNameCheck(user.FirstName);
            UserNameCheck(user.Lastname);

            //ToDo проверка-замена первой буквы имени/фамилии на заглавную

            UserEmailCheck(user.Email);
            UserPhoneNumberCheck(user.PhoneNumber);
            UserLoginCheck(user.Login);
            UserPasswordCheck(user.Password);
            ProductPhotoCheck(user.Photo);
            
            NullCheck(user.ListOrder);

            return userDao.Add(user);
        }

        private void ProductPhotoCheck(byte[] photo)
        {
            NullCheck(photo);
            EmptyByteArrayCheck(photo);
        }

        private void EmptyByteArrayCheck(byte[] byteArray)
        {
            if (byteArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(byteArray)} is empty!");
            }
        }

        private void UserPasswordCheck(string password)
        {
            NullCheck(password);
            EmptyStringCheck(password);

            //ToDo хэширование пароля
        }

        private void UserLoginCheck(string login)
        {
            NullCheck(login);
            EmptyStringCheck(login);
        }

        private void UserPhoneNumberCheck(string phoneNumber)
        {
            NullCheck(phoneNumber);
            EmptyStringCheck(phoneNumber);
        }

        private void UserEmailCheck(string email)
        {
            NullCheck(email);
            EmptyStringCheck(email);
            EmailCheck(email);
        }

        private void EmailCheck(string email)
        {
            //ToDo проверка на валидный имейл
        }

        private void UserNameCheck(string name)
        {
            NullCheck(name);
            EmptyStringCheck(name);
            NameCheck(name);
        }

        private void NameCheck(string name)
        {
            if (!CyrillicOnly(name))
            {
                throw new ArgumentException($"{nameof(name)} is incorrect!");
            }
        }

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
