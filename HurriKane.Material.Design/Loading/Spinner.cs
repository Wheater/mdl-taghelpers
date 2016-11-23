using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Loading
{
    public class Spinner : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-spinner", "mdl-js-spinner " };
        public bool Active { get; set; }
        public bool SingleColor { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Active)
                output.AppendCssClass("is-active");
            if (SingleColor)
                output.AppendCssClass("mdl-spinner--single-color");
            return content;
        }
    }
}