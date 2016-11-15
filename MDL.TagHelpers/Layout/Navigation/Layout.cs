using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Layout.Navigation
{
    [HtmlTargetElement(LAYOUT)]
    [Mdl("div")]
    [Css("mdl-layout", "mdl-js-layout")]
    [RestrictChildren(LAYOUT_HEADER, LAYOUT_DRAWER, LAYOUT_CONTENT)]
    public class Layout : BaseTagHelper
    {
        public bool FixedDrawer { get; set; } = false;
        public bool NoDrawerButton { get; set; } = false;
        public bool NoDesktopDrawerButton { get; set; } = false;
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetHtmlContent(content);
            if (FixedDrawer)
            {
                output.AppendClass("mdl-layout--fixed-drawer");
            }
            if(NoDrawerButton)
            {
                output.AppendClass("mdl-layout--no-drawer-button");
            }
            if (NoDesktopDrawerButton)
            {
                output.AppendClass("mdl-layout--no-desktop-drawer-button");
            }
            
        }
    }

    [HtmlTargetElement(LAYOUT_HEADER)]
    [Mdl("header")]
    [Css("mdl-layout__header")]
    [RestrictChildren(LAYOUT_CONTENT_LINK)]
    public class LayoutHeader : BaseTagHelper
    {
        public string Title { get; set; }
        public bool Spacer { get; set; } = true;
        public bool Scrollable { get; set; } = false;
        public bool Waterfall { get; set; } = false;
        public bool WaterfallHideTop { get; set; } = false;
        public bool Transparent { get; set; } = false;
        public bool Shadow { get; set; } = true;

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var icon = $"<div class='mdl-layout-icon'></div>";
            var nav = $"<nav class='mdl-navigation'>{content}</anv>"; // Add links here in the child html 
            var spacer = (Spacer) ? $"<div class='mdl-layout-spacer'></div>": "";
            var title = $"<span class='mdl-layout__title'>{Title}</span>";
            var headerRow = $"<div class='mdl-layout__header-row'>{title}{spacer}{nav}</div>";           ;
            
            // Combine everything now.
            output.Content.SetHtmlContent($"{icon} {headerRow}");

            if (Scrollable)
            {
                output.AppendClass("mdl-layout__header--scroll");
            }

            if (Waterfall)
            {
                output.AppendClass("mdl-layout__header--waterfall");
                if (WaterfallHideTop)
                {
                    output.AppendClass("mdl-layout__header--waterfall-hide-top");
                }
            }
            
            if (Transparent)
            {
                output.AppendClass("mdl-layout__header--transparent");
            }
            
            if (Shadow)
            {
                output.AppendClass("mdl-layout__header--seamed");
            }
            
        }
    }

    [HtmlTargetElement(LAYOUT_DRAWER)]
    [Mdl("div")]
    [Css("mdl-layout__drawer")]
    [RestrictChildren(LAYOUT_CONTENT_LINK)]
    public class LayoutDrawer : BaseTagHelper
    {
        public string Title { get; set; }
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var title = $"<span class='mdl-layout__title'>{Title}</span>";
            var nav = $"<nav class='mdl-navigation'>{content}</anv>"; // Add links here in the child html 
            output.Content.SetHtmlContent($"{title} {nav}");
        }
    }

    [HtmlTargetElement(LAYOUT_CONTENT)]
    [Mdl("main")]
    [Css("mdl-layout__content")]
    public class LayoutContent : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetHtmlContent($"<div>{content}<div>");
        }
    }
    
    [HtmlTargetElement(LAYOUT_CONTENT_LINK)]
    [Mdl("a")]
    [Css("mdl-navigation__link")]
    public class LayoutContentLink : BaseTagHelper
    {
        public string Href { get; set; }
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetHtmlContent(content);
            output.Attributes.SetAttribute("href", Href);
        }
    }
}
