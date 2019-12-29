﻿using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Logic.Validate
{
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Returns object prepared for validation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ValidatableObject<O> AsValidatableObject<O>(this O obj) where O : class => new ValidatableObject<O>(obj);

        /// <summary>
        /// Returns field from object by name prepared for validation
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static ValidatableField<F> ForField<O, F>(this O obj, string fieldName) where O : class
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName) + " must be fullfilled!");
            }

            var prop = typeof(O).GetProperty(fieldName);
            if (prop is null) throw new Exception($"Property {nameof(fieldName)} doesn't exists in class {nameof(O)}");

            return new ValidatableField<F>((F)prop.GetValue(obj), fieldName);
        }

        public static ValidatableField<F> Required<F>(this ValidatableField<F> field) where F : class
        {
            if (field is null) throw new ArgumentNullException(nameof(field));

            if (field.Field is null)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Required), $"Field '{field.FieldName}' is required"));
            }

            return field;
        }

        public static ValidatableField<F> Between<F>(this ValidatableField<F> field, F min, F max) where F : IComparable
        {
            if (field is null) throw new ArgumentNullException(nameof(field));

            if (field.Field.CompareTo(min) < 0)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Between), $"Field '{field.FieldName}' must be more than {min}"));
            }

            if (field.Field.CompareTo(max) > 0)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Between), $"Field '{field.FieldName}' must be less than {max}"));
            }

            return field;
        }

        public static ValidatableField<string> Length(this ValidatableField<string> field, int min, int max)
        {
            if (field is null) throw new ArgumentNullException(nameof(field));

            var ff = new ValidatableField<int>(field.Field.Length, nameof(field.Field.Length));

            var result = ff.Between(min, max);

            if (!result.IsValid)
            {
                field.IsValid = false;
                field.Errors.AddRange(result.Errors);
            }

            return field;
        }

        public static ValidatableField<string> Match(this ValidatableField<string> field, string text, string expression)
        {
            if (field is null) throw new ArgumentNullException(nameof(field));
            if (text is null) throw new ArgumentNullException(nameof(field));
            if (expression is null) throw new ArgumentNullException(nameof(field));

            if (!Regex.IsMatch(text, expression))
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Match), $"Field '{field.FieldName}' doesn't match to '{expression}'"));
            }

            return field;
        }
    }
}
