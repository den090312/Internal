using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductDao productDao;

        public ProductLogic(IProductDao iProductDao)
        {
            NullCheck(iProductDao);

            productDao = iProductDao;
        }

        public bool Add(Product product)
        {
            NullCheck(product);
            ProductNameCheck(product.Name);
            EmptyStringCheck(product.Description);
            ProductPhotoCheck(product.Photo);
            NullCheck(product.Price);

            return productDao.Add(product);
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

        private void ProductNameCheck(string name)
        {
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
