using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-h3")] 
    public class H3TagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h3";
            var content = await output.InnerContent();

            output.AppendClass("mdl-typography--display-2");
            output.Content.SetContent(content);
        }
    }
}