using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using HurriKane.Material.Design.Icons;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace HurriKane.Material.Design.List
{
    [RestrictChildren("list-item", "list-item-two-lines", "list-item-three-lines")]
    public class List : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list" };
        public override string TagName => "ul";
    }

    [RestrictChildren("list-item-primary-content", "list-item-secondary-content")]
    public class ListItem : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item" };
        public override string TagName => "li";
        public bool TwoLine { get; set; } = false;
        public bool ThreeLine { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (TwoLine)
                output.AppendCssClass("mdl-list__item--two-line");
            if (ThreeLine)
                output.AppendCssClass("mdl-list__item--three-line");
            return content;
        }
    }

    /*
     * CONTENT
     */

    [RestrictChildren("list-item-avatar", "span", "list-item-text-body", "list-item-subtitle")]
    public class ListItemPrimaryContent : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-primary-content" };
        public override string TagName => "span";
    }

    public class ListItemSecondaryContent : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-secondary-content" };
        public override string TagName => "span";
    }

    public class ListItemAvatar : Icon
    {
        public override string[] CssClasses => base.CssClasses.Append("mdl-list__item-avatar").ToArray();
    }

    public class ListItemSecondaryAction : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-secondary-action" };
        public override string TagName => "span";
    }

    public class ListItemSecondaryInfo : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-secondary-info" };
    }

    public class ListItemTextBody : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-text-body" };
    }

    public class ListItemSubtitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-list__item-sub-title" };
    }
}