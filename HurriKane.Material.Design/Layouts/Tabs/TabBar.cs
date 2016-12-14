using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Layouts.Tabs
{
    [RestrictChildren("tab-bar")]
    public class TabBarContainer : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-tabs mdl-js-tabs" };
        public bool Ripple { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            return content;
        }
    }

    [RestrictChildren("tab-bar-item")]
    public class TabBar : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-tabs__tab-bar" };
    }

    public class TabBarItem : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-tabs__tab" };
        public override string TagName => "a";

        public bool Active { get; set; } = false;
        public string ForTabPanelId { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Active)
                output.AppendCssClass("is-active");

            output.Attributes.SetAttribute("href", "#" + ForTabPanelId);
            return content;
        }
    }

    public class TabPanel : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-tabs__tab-panel" };
        public bool Active { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Active)
                output.AppendCssClass("is-active");

            return $"<div class='page-content'>{content}</div>";
        }
    }
}