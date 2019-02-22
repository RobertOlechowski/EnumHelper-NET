using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDescriptionDemo
{
    internal enum ExampleEnum
    {
        Element,

        [Description("Some description")]
        Element2,

        [Description("not ASCI : ĄĆĘŁŃ  普 通 话 ")]
        Element3,

        Element4,
    }

}
