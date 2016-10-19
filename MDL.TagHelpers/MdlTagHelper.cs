using Microsoft.AspNetCore.Razor.TagHelpers;


namespace MDL.TagHelpers 
{
    [HtmlTargetElement("mdl-script")] 
    public class MdlTagHelper : TagHelper
    {
        public bool Async { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "script";
            output.Attributes.SetAttribute("src", "https://code.getmdl.io/1.2.1/material.min.js");
        }
    }
}