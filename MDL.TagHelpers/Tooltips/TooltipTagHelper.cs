using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Tooltips
{
    [HtmlTargetElement("mdl-tooltip")] 
    public class TooltipTagHelper : TagHelper
    {
        public bool Large { get; set; }
        public bool MdlId { get; set; }

        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Top { get; set; }
        public bool Bottom { get; set; }

        public TooltipTagHelper ()
        {
            Large = false;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();

            // Switch the tag if they have an Icon, Link or Other. 
            output.TagName = "div";
            
            if(Large) {
                output.AppendClass("mdl-tooltip--large");
            }

            if(Left) {
                output.AppendClass("mdl-tooltip--left");
            }

            if(Right) {
                output.AppendClass("mdl-tooltip--right");
            }

            if(Top) {
                output.AppendClass("mdl-tooltip--top");
            }
            
            if(Bottom) {
                output.AppendClass("mdl-tooltip--bottom");
            }
                
            output.PrependClass("mdl-tooltip");

            output.Content.SetContent(content);

        }
    }
}