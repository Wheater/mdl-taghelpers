using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Badges
{
    [HtmlTargetElement("mdl-badge")]
    [Css("mdl-badge")]
    public class Badge : BaseTagHelper
    {
        public int Value { get; set; }
        public string Href { get; set; } = "";
        public bool NoBackground { get; set; } = false;
        public bool Overlap { get; set; } = false;
        public bool Icon { get; set; } = false;
        
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            // Switch the tag if they have an Icon, Link or Other. 
            if(String.IsNullOrEmpty(Href)) {
                if(Icon) {
                    output.TagName = "div";
                } else {
                    output.TagName = "span";
                }
            } else {
                output.TagName = "a";
                output.Attributes.SetAttribute("href", Href);

            }

            if(Icon) {
                output.AddMaterialIconClass();
            }

            if(NoBackground) {
                output.AppendClass("mdl-badge--no-background");
            }

            if(Overlap) {
                output.AppendClass("mdl-badge--overlap");
            }
            
            output.Attributes.SetAttribute("data-badge", Value);
            output.Content.SetContent(content);
        }
    }
}