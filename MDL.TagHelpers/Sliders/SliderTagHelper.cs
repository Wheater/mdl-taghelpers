using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Sliders
{
    [HtmlTargetElement("mdl-slider")]
    [Mdl("input","mdl-slider", "mdl-js-slider")]
    public class SliderTagHelper : BaseTagHelper
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Value { get; set; }
        public int Step { get; set; }
        public int TabIndex { get; set; }

        public SliderTagHelper()
        {
            Min = 0;
            Max = 2;
            Value = 1;
            Step = 1;
        }

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
