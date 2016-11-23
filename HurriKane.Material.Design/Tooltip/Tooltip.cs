using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Tooltip
{
    public class Tooltip : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-tooltip" };
        public string ForId { get; set; }
        public bool Large { get; set; }
        public Direction Direction { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            output.Attributes.Add("data-mdl-for", ForId);

            if (Large)
                output.AppendCssClass("mdl-tooltip--large");

            switch (Direction)
            {
                case Direction.Top:
                    output.AppendCssClass("mdl-tooltip--top");
                    break;

                case Direction.Right:
                    output.AppendCssClass("mdl-tooltip--right");
                    break;

                case Direction.Bottom:
                    output.AppendCssClass("mdl-tooltip--bottom");
                    break;

                case Direction.Left:
                    output.AppendCssClass("mdl-tooltip--left");
                    break;

                default:
                    break;
            }
            return content;
        }
    }
}