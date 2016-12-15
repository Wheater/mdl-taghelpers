using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Loading
{
    public class ProgressBar : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-progress mdl-js-progress" };
        public bool Indeterminate { get; set; }
        public override bool IgnoreNullContent => true;
        public override bool IgnoreId => false;
        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Indeterminate)
                output.AppendCssClass("mdl-progress__indeterminate");
            output.PostElement.AppendHtml($"<script type='text/javascript'>document.querySelector('#{Id}').addEventListener('mdl-componentupgraded', function() {{ {content} }});</script>");
            return null;
        }
    }
}