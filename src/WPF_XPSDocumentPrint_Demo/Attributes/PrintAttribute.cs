using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_XPSDocumentPrint_Demo.Attributes
{
    public class PrintAttribute : Attribute
    {
        public string Name;
        public PrintAttribute(string name)
        {
            Name = name;
        }

        public string GetName() => Name;
    }
}
