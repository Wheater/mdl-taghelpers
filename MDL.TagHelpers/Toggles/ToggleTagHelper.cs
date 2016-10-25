using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;

using System;

namespace MDL.TagHelpers.Toggles
{
    [HtmlTargetElement("mdl-toggle-checkbox")] 
    public class CheckboxTagHelper : TagHelper, HasRipple
    {
        public bool Ripple {get; set;}

        public CheckboxTagHelper ()
        {
            Ripple = true;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();
            var id = TagHelperOutputExtensions.UniqueId();
            output.TagName = "label";
            output.Attributes.SetAttribute("for", id);

            output.AppendClass("mdl-checkbox");
            output.AppendClass("mdl-js-checkbox");
 
            if(Ripple) {
                 output.AppendClass("mdl-js-ripple-effect");  
            }
            
            output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-checkbox__input\"/>");
            output.Content.AppendHtml($"<span class=\"mdl-checkbox__label\">{content}</span>");
        }
    }

}