using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Lists
{
    [RestrictChildren("mdl-list-item")]
    [HtmlTargetElement("mdl-list")]
    public class ListTagHelper : UniqueTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.AppendClass("mdl-list");
        }
    }


    [RestrictChildren("mdl-list-item-content", "mdl-list-item-action")]
    [HtmlTargetElement("mdl-list-item")]
    public class ListItemTagHelper : UniqueTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            output.AppendClass("mdl-list__item");
        }
    }

    [HtmlTargetElement("mdl-list-item-content")]
    public class ListItemPrimaryContentTagHelper : UniqueTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AppendClass("mdl-list__item-primary-content");
        }
    }

    [HtmlTargetElement("mdl-list-item-action")]
    public class ListItemSecondaryActionTagHelper : UniqueTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AppendClass("mdl-list__item-secondary-action");
        }
    }

    [HtmlTargetElement("mdl-list-item-action-info")]
    public class ListItemSecondaryActionInfoTagHelper : UniqueTagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.AppendClass("mdl-list__item-secondary-info");
        }
    }
}
