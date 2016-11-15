using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Buttons
{
    [HtmlTargetElement("mdl-button")] 
    [Mdl("button")]
    [Css("mdl-button", "mdl-js-button")]
    public class Button : BaseTagHelper
    {
        public bool Raised { get; set; } = false;
        public bool Fab { get; set; } = false;
        public bool Mini { get; set; } = false;
        public bool Icon { get; set; }
        public bool Colored { get; set; }
        public bool Primary { get; set; }
        public bool Accent{ get; set; }
        public bool Ripple { get; set; } = false;
        
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            if (Raised)
            {
                output.AppendClass("mdl-button--raised");
            }
            else if (Fab)
            {
                output.AppendClass("mdl-button--fab");
            }
            else if (Mini)
            {
                output.AppendClass("mdl-button--mini-fab");
            }

            if (Colored)
            {
                output.AppendClass("mdl-button--colored");
            }
            else if (Primary)
            {
                output.AppendClass("mdl-button--primary");
            }
            else if (Accent)
            {
                output.AppendClass("mdl-button--accent");
            }

            if (Ripple)
            {
                output.AppendClass("mdl-js-ripple-effect");
            }

            if (Icon)
            {
                output.AppendClass("mdl-button--icon");
                output.Content.SetHtmlContent(
                    "<i class=\"material-icons\">" + content + "</i>"
                );
            }
            else
            {
                output.Content.SetContent(content);
            }

        }
    }
}