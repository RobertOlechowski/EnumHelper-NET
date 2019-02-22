using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace EnumDescriptionDemo
{
    public static class EnumHelper
    {
        public static IEnumerable<Tuple<T, string>>
        GetValueDescriptionEnumerable<T>() where T : struct
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                var fi = typeof(T).GetField(item.ToString());
                var description = !(fi
                     .GetCustomAttributes(typeof(DescriptionAttribute), false)
                     .FirstOrDefault() is DescriptionAttribute attribute) ?
                    item.ToString() :
                    attribute.Description;
                yield return new Tuple<T, string>(item, description);
            }
        }
    }
}
