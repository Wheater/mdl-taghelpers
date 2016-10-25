using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-h4")] 
    public class H4TagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h4";
            var content = await output.InnerContent();

            output.AppendClass("mdl-typography--display-1");
            output.Content.SetContent(content);
        }
    }
}