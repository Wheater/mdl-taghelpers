using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDL.TagHelpers.API
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CssAttribute: Attribute
    {
        public CssAttribute(params string[] classes)
        {
            Classes = classes;
        }
        
        public string[] Classes { get; set; }

    }
}
