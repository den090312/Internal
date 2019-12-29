using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        public static ValidatableObject<O, F> AsValidatableObject<O, F>(this O obj) where O : class => new ValidatableObject<O, F>(obj);

        /// <summary>
        /// Returns field from object by name prepared for validation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static ValidatableField<F> ForField<T, F>(this T obj, string fieldName) where T : class
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException(nameof(fieldName) + "must be fullfilled!");
            }

            var prop = typeof(T).GetProperty(fieldName);
            if (prop is null) throw new Exception($"Property {nameof(fieldName)} doesn't exists in class {nameof(T)}");

            return new ValidatableField<F>((F)prop.GetValue(obj), fieldName);
        }

        public static ValidatableField<F> Required<F>(this ValidatableField<F> field) where F : class
        {
            if (field is null) throw new ArgumentNullException(nameof(field));

            if (field.Field is null)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Required), $"Field {field.FieldName} is required"));
            }

            return field;
        }

        public static ValidatableField<F> Between<F>(this ValidatableField<F> field, F min, F max) where F : IComparable
        {
            if (field is null) throw new ArgumentNullException(nameof(field));

            if (field.Field.CompareTo(min) < 0)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Between), $"Field {field.FieldName} must be more than {min}"));
            }

            if (field.Field.CompareTo(max) > 0)
            {
                field.AddError(new Error(Error.Types.Warning, nameof(Between), $"Field {field.FieldName} must be less than {max}"));
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
    }
}
