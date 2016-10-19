using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-h1")] 
    public class H1TagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            var content = await output.GetChildContentAsync();

            output.AppendClass("mdl-typography--display-4");
            output.Content.SetContent(content.GetContent());
        }
    }
}