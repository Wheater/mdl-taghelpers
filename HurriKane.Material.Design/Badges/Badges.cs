using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Badges
{
    public class Badge : BaseTag
    {
        public override string TagName => "span";

        public override string[] CssClasses => new string[] { "mdl-badge" };

        public string Value { get; set; }
        public bool NoBackground { get; set; } = false;
        public bool Overlap { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            output.Attributes.Add("data-badge", Value);
            if (NoBackground)
                output.AppendCssClass(new string[] { "mdl-badge--no-background" });
            if (Overlap)
                output.AppendCssClass(new string[] { "mdl-badge--overlap" });

            return content;
        }
    }

    public class BadgeLink : Badge
    {
        public override string TagName => "a";
    }
}