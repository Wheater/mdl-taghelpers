using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers
{
    public abstract class UniqueTagHelper : TagHelper
    {
        public string Id { get; private set; }

        public UniqueTagHelper ()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
