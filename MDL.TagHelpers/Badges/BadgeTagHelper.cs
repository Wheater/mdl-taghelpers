using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System;

namespace MDL.TagHelpers.Badges
{
    [HtmlTargetElement("mdl-badge")] 
    public class BadgeTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public int Value { get; set; }
        
        [HtmlAttributeName("no-background")]
        public bool HasNoBackground { get; set; }

        [HtmlAttributeName("overlap")]
        public bool HasOverlap { get; set; }

        [HtmlAttributeName("icon")]
        public bool IsIcon { get; set; }

        [HtmlAttributeName("href")]
        public string Href { get; set; }

        public BadgeTagHelper ()
        {
            HasNoBackground = false;
            HasOverlap = false;
            IsIcon = false;
            Href = "";
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            // Switch the tag if they have an Icon, Link or Other. 
            if(String.IsNullOrEmpty(Href)) {
                if(IsIcon) {
                    output.TagName = "div";
                } else {
                    output.TagName = "span";
                }
            } else {
                output.TagName = "a";
                output.Attributes.SetAttribute("href", Href);

            }

            if(IsIcon) {
                output.AddMaterialIconClass();
            }

            if(HasNoBackground) {
                output.AppendClass("mdl-badge--no-background");
            }

            if(HasOverlap) {
                output.AppendClass("mdl-badge--overlap");
            }
            
            output.AppendClass("mdl-badge");
            output.Attributes.SetAttribute("data-badge", Value);
            output.Content.SetContent(content.GetContent());
        }
    }
}