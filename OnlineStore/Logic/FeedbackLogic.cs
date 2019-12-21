using Entities;
using InterfacesBLL;
using InterfacesDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class FeedbackLogic : IFeedbackLogic
    {
        private readonly IFeedbackDao feedbackDao;

        public FeedbackLogic(IFeedbackDao iFeedbackDao)
        {
            NullCheck(iFeedbackDao);

            feedbackDao = iFeedbackDao;
        }

        public bool Add(Feedback feedback)
        {
            NullCheck(feedback);
            NullCheck(feedback.User);
            DateTimeCheck(feedback.DateTime);
            FeedbackTextCheck(feedback.Text);

            return feedbackDao.Add(feedback);
        }

        private void FeedbackTextCheck(string text)
        {
            NullCheck(text);
            EmptyStringCheck(text);
            TextLengthCheck(text);
            LinkCheck(text);
            HtmlTagCheck(text);
        }

        private void LinkCheck(string text)
        {
            if (text.Contains("http://") || text.Contains("https://"))
            {
                throw new ArgumentException($"{nameof(text)} has link!");
            }

            //ToDo exp www.domain.com check
        }

        private void HtmlTagCheck(string value)
        {
            //ToDo exp <> check
        }

        private void TextLengthCheck(string text)
        {
            if (text.Length < 3 || text.Length > 2000)
            {
                throw new ArgumentException($"{nameof(text)} has incorrect length!");
            }
        }

        private void DateTimeCheck(DateTime value)
        {
            if (value <= DateTime.Now)
            {
                throw new ArgumentException($"{nameof(value)} is less than current date!");
            }
        }

        private void EmptyStringCheck(string value)
        {
            if (value == string.Empty)
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
