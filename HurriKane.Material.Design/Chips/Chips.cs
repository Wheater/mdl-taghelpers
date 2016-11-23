using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Chips
{
    [RestrictChildren("chip-action-link", "img", "chip-text", "chip-contact")]
    public class Chip : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-chip" };
        public bool Deletable { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Deletable)
                output.AppendCssClass("mdl-chip--deletable");
            return content;
        }
    }

    [RestrictChildren("chip-action-link", "img", "chip-text", "chip-contact")]
    public class ChipButton : Chip
    {
        public override string TagName => "button";
    }

    public class ChipActionLink : Chip
    {
        public override string TagName => "a";
        public override string[] CssClasses => new string[] { "mdl-chip__action" };
    }

    public class ChipText : Chip
    {
        public override string TagName => "span";
        public override string[] CssClasses => new string[] { "mdl-chip__text" };
    }

    public class ChipContact : Chip
    {
        public override string TagName => "span";
        public override string[] CssClasses => new string[] { "mdl-chip__contact" };
    }
}