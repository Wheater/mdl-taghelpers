using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Buttons
{
    public class Button : BaseTag
    {
        public override string TagName => "button";

        public override string[] CssClasses => new string[] { "mdl-button", "mdl-js-button " };

        public bool Colored { get; set; } = false;
        public bool Fab { get; set; } = false;
        public bool Ripple { get; set; } = false;
        public bool Raised { get; set; } = false;
        public bool Accent { get; set; } = false;
        public bool Primary { get; set; } = false;
        public bool Icon { get; set; } = false;
        public bool Mini { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Fab && !Raised && !Mini && !Icon)
                output.AppendCssClass(new string[] { "mdl-button--fab" });
            if (Raised && !Fab && !Mini && !Icon)
                output.AppendCssClass(new string[] { "mdl-button--raised" });
            if (Icon && !Raised && !Fab && !Mini)
                output.AppendCssClass(new string[] { "mdl-button--icon" });
            if (Mini && !Raised && !Fab && !Icon)
                output.AppendCssClass(new string[] { "mdl-button--fab", "mdl-button--mini-fab" });

            if (Colored)
                output.AppendCssClass(new string[] { "mdl-button--colored" });
            if (Accent)
                output.AppendCssClass(new string[] { "mdl-button--accent" });
            if (Primary)
                output.AppendCssClass(new string[] { "mdl-button--primary" });

            if (Ripple)
                output.AppendCssClass(new string[] { "mdl-js-ripple-effect" });

            return content;
        }
    }
}