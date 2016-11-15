using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Sliders
{
    [HtmlTargetElement("mdl-slider")]
    [Mdl("input")]
    [Css("mdl-slider", "mdl-js-slider")]
    public class Slider : BaseTagHelper
    {
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 2;
        public int Value { get; set; } = 1;
        public int Step { get; set; } = 1;
        
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var id = TagHelperOutputExtensions.UniqueId();
            output.Attributes.SetAttribute("type", "range");

            //TODO : Add validation

            output.Attributes.SetAttribute("min", Min);
            output.Attributes.SetAttribute("max", Max);
            output.Attributes.SetAttribute("step", Step);
            output.Attributes.SetAttribute("value", Value);

        }
    }
}
