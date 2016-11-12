using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDL.TagHelpers.API
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MdlAttribute : Attribute
    {
        public MdlAttribute(string tag, bool generateUniqueId = false, params string[] classes)
        {
            Classes = classes;
            TagName = tag;
            GenerateUniqueId = generateUniqueId;
        }

        public MdlAttribute(string tag, params string[] classes)
        {
            Classes = classes;
            TagName = tag;
            GenerateUniqueId = false;
        }

        public string[] Classes { get; set; }
        public string TagName { get; set; }
        public bool GenerateUniqueId { get; set; }
    }
}
