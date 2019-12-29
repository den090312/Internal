using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Validate
{
    class Consts
    {
        public const string ExpRegion = @"[А-Я]+[а-я]+(\s*[а-я]+)+";

        public const string ExpLocality = @"[А-Я]+[а-я]+\s*\-*[а-я]+\-+[А-Я]+[а-я]+";

        public const string ExpStreet = @"[А-Я]+[а-я]+\s*\-*[а-я]+\-+[А-Я]+[а-я]+";
    }
}
