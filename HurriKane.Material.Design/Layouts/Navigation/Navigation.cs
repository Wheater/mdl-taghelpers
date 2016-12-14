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
        public bool NoDrawerIcon { get; set; } = false;
        public bool NoDrawerIconDesktop { get; set; } = false;
        public bool NoDrawerIconTablet { get; set; } = false;
        public bool NoDrawerIconMobile { get; set; } = false;
        public override string[] CssClasses => new string[] { "mdl-layout", "mdl-js-layout" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (FixedDrawer)
                output.AppendCssClass("mdl-layout--fixed-drawer");
            if (FixedHeader)
                output.AppendCssClass("mdl-layout--fixed-header");
            if (FixedTabs)
                output.AppendCssClass("mdl-layout--fixed-tabs");

            if (NoDrawerIcon)
                output.AppendCssClass("mdl-layout--no-drawer-button");
            if (NoDrawerIconDesktop)
                output.AppendCssClass("mdl-layout--no-desktop-drawer-button");
            if (NoDrawerIconTablet)
                output.AppendCssClass("mdl-layout--no-tablet-drawer-button");
            if (NoDrawerIconMobile)
                output.AppendCssClass("mdl-layout--no-mobile-drawer-button");


            
            return content;
        }
    }

    [RestrictChildren("navigation-header-row","navigation-header-tab-bar")]
    public class NavigationHeader : BaseTag
    {
        public bool Transparent { get; set; } = false;
        public bool Scrollable { get; set; } = false;
        public bool Waterfall { get; set; } = false;
        public bool HasIcon { get; set; } = false;
        public bool HasShadow { get; set; } = false;
        public bool WaterfallHideTopRow { get; set; } = false;
        public bool ShowTabBar { get; set; } = false;
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
            if (HasShadow)
                output.AppendCssClass("mdl-layout__header--seamed");
            if (Waterfall && WaterfallHideTopRow)
                output.AppendCssClass("mdl-layout__header--waterfall-hide-top");

            var additional = "";
            if (HasIcon)
                additional += "<div class='mdl-layout-icon'></div>";
            return $"{additional}{content}";
        }
    }

    [RestrictChildren("navigation-title", "navigation-spacer", "navigation-link-list", "button", "img", "nav")]
    public class NavigationHeaderRow : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-layout__header-row" };
    }

    [RestrictChildren("navigation-title", "navigation-link-list", "navigation-header-tab-bar", "navigation-header")]
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

    [RestrictChildren("navigation-link-list-item")]
    public class NavigationLinkList : BaseTag
    {
        public override string TagName => "nav";
        public override string[] CssClasses => new string[] { "mdl-navigation" };
    }

    public class NavigationLinkListItem : BaseTag
    {
        public override string TagName => "a";
        public override string[] CssClasses => new string[] { "mdl-navigation__link" };
    }

    [RestrictChildren("navigation-header-tab-bar-item")]
    public class NavigationHeaderTabBar : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-layout__tab-bar" };
    }

    public class NavigationHeaderTabBarItem : BaseTag
    {
        public override string TagName => "a";
        public bool Active { get; set; } = false;
        public override string[] CssClasses => new string[] { "mdl-layout__tab" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Active)
                output.AppendCssClass("is-active");

            return content;
        }
    }

    public class NavigationTabPanel : BaseTag
    {
        public override string TagName => "section";
        public bool Active { get; set; } = false;
        public override string[] CssClasses => new string[] { "mdl-layout__tab-panel" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Active)
                output.AppendCssClass("is-active");

            return content;
        }
    }
}