using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-h2")] 
    public class H2TagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h2";
            var content = await output.InnerContent();

            output.AppendClass("mdl-typography--display-3");
            output.Content.SetContent(content);
        }
    }
}