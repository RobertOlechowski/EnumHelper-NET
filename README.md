# EnumHelper-NET

## What is the purpose of this project?
It is extension method to generate item description pairs for enums to bind it with lists in easy way. 

## How to use it?

```csharp

internal enum ExampleEnum
{
    Element,

    [Description("Some description")]
    Element2,

    [Description("not ASCI : ĄĆĘŁŃ  普 通 话 ")]
    Element3,

    Element4,
}

private void Form1_Load(object sender, EventArgs e)
{
    var elements = EnumHelper.GetValueDescriptionEnumerable<ExampleEnum>()
    .Select(a => new { wartosc = a.Item1, opis = a.Item2 })
    .ToList();

    comboBox1.DataSource = elements;
    comboBox1.DisplayMember = "opis";
    comboBox1.ValueMember = "wartosc";

}
```

## How it looks like when at work?
![](https://github.com/RobertOlechowski/EnumHelper-NET/blob/master/Doc/Screen.png?raw=true)

## How is it implemented?
```csharp
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
```

## Where i can get more information?
On author's blog [bind to enum](https://blog.robertolechowski.com/bindowanie-enum/)






