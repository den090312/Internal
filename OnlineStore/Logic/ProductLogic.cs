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
            ProductNullCheck(product);
            NameCheck(product.Name);
            DescriptionCheck(product.Description);
            PhotoCheck(product.Photo);

            return productDao.Add(product);
        }

        private void ProductNullCheck(Product product)
        {
            NullCheck(product);
            NullCheck(product.Description);
            NullCheck(product.Photo);
            NullCheck(product.Photo);
        }

        private void DescriptionCheck(string description)
        {
            if (description.Length <= 0 || description.Length > 4000)
            {
                throw new ArgumentException($"{nameof(description)} has incorrect length!");
            }
        }

        private void PhotoCheck(byte[] byteArray)
        {
            if (byteArray.Length == 0)
            {
                throw new ArgumentException($"{nameof(byteArray)} is empty!");
            }
        }

        private void NameCheck(string name)
        {
            if (name.Length <= 0 || name.Length > 300)
            {
                throw new ArgumentException($"{nameof(name)} has incorrect length!");
            }

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

        private void NullCheck<T>(T classObject) where T : class
        {
            if (classObject is null)
            {
                throw new ArgumentNullException($"{nameof(classObject)} is null!");
            }
        }
    }
}
