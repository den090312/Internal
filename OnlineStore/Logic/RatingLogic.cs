using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class RatingLogic : IRatingLogic
    {
        private readonly IRatingDao ratingDao;

        public RatingLogic(IRatingDao iRatingDao)
        {
            NullCheck(iRatingDao);

            ratingDao = iRatingDao;
        }

        public bool Add(Rating rating)
        {
            NullCheck(rating);
            NegativeIntCheck(rating.UserCount);

            return ratingDao.Add(rating);
        }

        private void NegativeIntCheck(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must be more than zero");
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
