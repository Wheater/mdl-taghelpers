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
    
    [RestrictChildren("card-title-text")]
    public class CardTitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__title" };

        public bool Expand { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Expand)
                output.AppendCssClass("mdl-card--expand");
            return content;
        }
    }

    public class CardMedia : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__media" };
    }

    public class CardSubtitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__subtitle-text" };
    }
    
    public class CardTitleText : BaseTag
    {        
        public override string[] CssClasses => new string[] { "mdl-card__title-text" };
        public int HeadingSize { get; set; } = 2;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (HeadingSize > 0 && HeadingSize < 7)
                output.TagName = $"h{HeadingSize}";
            return content;
        }
    }


    public class CardMenu: BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__menu" };
    }


    public class CardActions : BaseTag
    {
        public bool HasBorder { get; set; } = false;
        public override string[] CssClasses => new string[] { "mdl-card__actions" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if(HasBorder)
                output.AppendCssClass($"mdl-card--border");
            return content;
        }
    }

    public class CardSupportingtext : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-card__supporting-text" };
    }
}