using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;

namespace HurriKane.Material.Design.Layouts.Navigation
{
    [RestrictChildren("navigation-header", "navigation-drawer", "navigation-main")]
    public class Navigation : BaseTag
    {
        public bool FixedHeader { get; set; }
        public bool FixedDrawer { get; set; }
        public bool FixedTabs { get; set; }
        public override string[] CssClasses => new string[] { "mdl-layout", "mdl-js-layout" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (FixedDrawer)
                output.AppendCssClass("mdl-layout--fixed-drawer");
            if (FixedHeader)
                output.AppendCssClass("mdl-layout--fixed-header");
            if (FixedTabs)
                output.AppendCssClass("mdl-layout--fixed-tabs");
            return content;
        }
    }

    [RestrictChildren("navigation-title", "navigation-spacer", "navigation-link-list", "button", "img", "nav")]
    public class NavigationHeader : BaseTag
    {
        public bool Transparent { get; set; } = false;
        public bool Scrollable { get; set; } = false;
        public bool Waterfall { get; set; } = false;

        public override string TagName => "header";

        public override string[] CssClasses => new string[] { "mdl-layout__header" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Transparent)
                output.AppendCssClass("mdl-layout__header--transparent");
            if (Scrollable)
                output.AppendCssClass("mdl-layout__header--scroll");
            if (Waterfall)
                output.AppendCssClass("mdl-layout__header--waterfall");

            return $"<div class='mdl-layout__header-row'>{content}</div>";
        }
    }

    [RestrictChildren("navigation-title", "navigation-link-list", "navigation-header")]
    public class NavigationDrawer : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-layout__drawer" };
    }

    public class NavigationMain : BaseTag
    {
        public override string TagName => "main";
        public override string[] CssClasses => new string[] { "mdl-layout__content" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            return $"<div class='page-content'>{content}</div>";
        }
    }

    ////////////////////////////////////
    public class NavigationTitle : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-layout-title" };
        public override string TagName => "span";
    }

    public class NavigationSpacer : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-layout-spacer" };
    }

    public class NavigationLinkList : BaseTag
    {
        public List<Tuple<string, string>> NavigationItems { get; set; } = new List<Tuple<string, string>>();
        public override string TagName => "nav";
        public override string[] CssClasses => new string[] { "mdl-navigation" };
    }

    public class NavigationLinkListItem : BaseTag
    {
        public List<Tuple<string, string>> NavigationItems { get; set; } = new List<Tuple<string, string>>();
        public override string TagName => "a";
        public override string[] CssClasses => new string[] { "mdl-navigation__link" };
    }
}