using HurriKane.Material.Design.Api;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Slider
{
    public class Slider : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-slider", "mdl-js-slider" };
        public override string TagName => "input";
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 2;
        public int Value { get; set; } = 1;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            output.Attributes.Add("type", "range");
            output.Attributes.Add("min", Min);
            output.Attributes.Add("max", Max);
            output.Attributes.Add("value", Value);
            return null;
        }
    }
}