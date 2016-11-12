using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Badges
{
    [HtmlTargetElement("mdl-badge")] 
    public class BadgeTagHelper : BaseTagHelper
    {
        public int Value { get; set; }
        public string Href { get; set; }
        public bool NoBackground { get; set; }
        public bool Overlap { get; set; }
        public bool Icon { get; set; }
        
        public BadgeTagHelper ()
        {
            NoBackground = false;
            Overlap = false;
            Icon = false;
            Href = "";
        }

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