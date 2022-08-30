using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanDocConverter.Support
{
    public class HtmlSubstitution
    {
        public HtmlSubstitution(string htmlValue)
        {
            HtmlValue = htmlValue;
        }

        public string HtmlValue { get; private set; }
    }
}
