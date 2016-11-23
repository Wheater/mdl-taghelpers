using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Menu
{
    public class Menu : BaseTag
    {
        public string For { get; set; }
        public bool Ripple { get; set; }
        public override string[] CssClasses => new string[] { "mdl-menu", "mdl-js-menu" };
        public override string TagName => "ul";
        public MenuDirection Direction { get; set; } = MenuDirection.BottomLeft;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            output.Attributes.Add("data-mdl-for", For);

            switch (Direction)
            {
                case MenuDirection.BottomLeft:
                    // Default behaviour in css is bottom left
                    break;

                case MenuDirection.BottomRight:
                    output.AppendCssClass("mdl-menu--bottom-right");
                    break;

                case MenuDirection.TopLeft:
                    output.AppendCssClass("mdl-menu--top-left");
                    break;

                case MenuDirection.TopRight:
                    output.AppendCssClass("mdl-menu--top-right");
                    break;

                default:
                    break;
            }

            return content;
        }
    }

    public class MenuItem : BaseTag
    {
        public override string TagName => "li";
        public override string[] CssClasses => new string[] { "mdl-menu__item" };

        public bool HasDivider { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (HasDivider)
            {
                output.AppendCssClass("mdl-menu__item--full-bleed-divider");
            }

            return content;
        }
    }
}