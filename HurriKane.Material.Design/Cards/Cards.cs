using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Cards
{
    public class Card : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card" };

        public int ShadowDepth { get; set; } = 2;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            output.AppendCssClass($"mdl-shadow--{ShadowDepth}dp");
            return content;
        }
    }

    public class CardTitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__title" };
    }

    public class CardMedia : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__media" };
    }

    public class CardSubtitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__subtitle-text" };
    }

    public class CardActions : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__actions" };
    }

    public class CardSupportingtext : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__supporting-text" };
    }
}