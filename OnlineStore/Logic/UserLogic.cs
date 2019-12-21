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
            UserNullCheck(user);
            EmptyFieldsCheck(user);

            FirstNameCheck(user.FirstName);
            LastNameCheck(user.LastName);

            //ToDo проверка-замена первой буквы имени/фамилии на заглавную

            EmailCheck(user.Email);
            UserPhoneNumberCheck(user.PhoneNumber);
            UserLoginCheck(user.Login);
            UserPasswordCheck(user.Password);
            ProductPhotoCheck(user.Photo);

            NullCheck(user.ListOrder);

            return userDao.Add(user);
        }

        private void EmptyFieldsCheck(User user)
        {
            EmptyStringCheck(user.FirstName);
            EmptyStringCheck(user.LastName);
            EmptyStringCheck(user.Email);
            EmptyStringCheck(user.Login);
            EmptyStringCheck(user.Password);

            EmptyByteArrayCheck(user.Photo);
        }

        private void UserNullCheck(User user)
        {
            NullCheck(user);
            NullCheck(user.FirstName);
            NullCheck(user.LastName);
            NullCheck(user.Email);
            NullCheck(user.PhoneNumber);
            NullCheck(user.Login);
            NullCheck(user.Password);
            NullCheck(user.Photo);
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
            //ToDo хэширование пароля
        }

        private void UserLoginCheck(string login)
        {
            //ToDo проверка на валидный логин
        }

        private void UserPhoneNumberCheck(string phoneNumber)
        {
            //ToDo проверка на валидный номер телефона
        }

        private void EmailCheck(string email)
        {
            //ToDo проверка на валидный имейл
        }

        private void FirstNameCheck(string firstName)
        {
            if (firstName.Length <= 0 || firstName.Length > 50)
            {
                throw new ArgumentException($"{nameof(firstName)} has incorrect length!");
            }

            if (!CyrillicOnly(firstName) && !LatinOnly(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} is incorrect!");
            }

        }

        private void LastNameCheck(string lastName)
        {
            if (lastName.Length <= 0 || lastName.Length > 150)
            {
                throw new ArgumentException($"{nameof(lastName)} has incorrect length!");
            }

            //ToDo валидация фамилии
        }

        private bool CyrillicOnly(string name)
        {
            var nameLower = name.ToLower();

            foreach (var symbol in nameLower)
            {
                if (symbol < 'а' || symbol > 'я')
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            return true;
        }

        private bool LatinOnly(string name)
        {
            var nameLower = name.ToLower();

            foreach (var symbol in nameLower)
            {
                if (symbol < 'a' || symbol > 'z')
                {
                    return false;
                }
                else
                {
                    continue;
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
