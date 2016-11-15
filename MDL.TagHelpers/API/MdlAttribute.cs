using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDL.TagHelpers.API
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MdlAttribute : Attribute
    {
        public MdlAttribute(string tag)
        {
            TagName = tag;
            GenerateUniqueId = false;
        }

        public MdlAttribute(string tag, bool generateUniqueId = false)
        {
            TagName = tag;
            GenerateUniqueId = generateUniqueId;
        }
        
        public string TagName { get; set; }
        public bool GenerateUniqueId { get; set; }
    }
}
