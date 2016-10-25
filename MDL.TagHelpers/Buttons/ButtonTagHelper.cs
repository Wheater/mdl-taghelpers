using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Buttons
{
    [HtmlTargetElement("mdl-button")] 
    public class ButtonTagHelper : TagHelper, HasRipple
    {
        public bool Raised { get; set; }
        public bool Fab { get; set; }
        public bool Mini { get; set; }
        public bool Icon { get; set; }
        public bool Colored { get; set; }
        public bool Primary { get; set; }
        public bool Accent{ get; set; }
        public bool Ripple { get; set; }

        public ButtonTagHelper ()
        {
            Raised = false;
            Ripple = false;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();

            // Switch the tag if they have an Icon, Link or Other. 
            output.TagName = "button";
            
            if(Raised) {
                output.AppendClass("mdl-button--raised");
            } else if(Fab) {
                output.AppendClass("mdl-button--fab");
            } else if(Mini) {
                output.AppendClass("mdl-button--mini-fab");
            }

            if(Colored) {
                output.AppendClass("mdl-button--colored");
            } else if(Primary) {
                output.AppendClass("mdl-button--primary");
            } else if(Accent) {
                output.AppendClass("mdl-button--accent");
            }

            if(Ripple) {
                output.AppendClass("mdl-js-ripple-effect");
            } 

            output.PrependClass("mdl-js-button");
            output.PrependClass("mdl-button");

            if(Icon) {
                output.AppendClass("mdl-button--icon");
                output.Content.SetHtmlContent(
                    "<i class=\"material-icons\">"+content+"</i>"
                );
            }
            else {
                output.Content.SetContent(content);
            }

        }
    }
}