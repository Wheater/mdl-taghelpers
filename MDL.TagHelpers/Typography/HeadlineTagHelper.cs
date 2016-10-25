using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-headline")] 
    public class HeadlineTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h5";
            var content = await output.InnerContent();

            output.AppendClass("mdl-typography--headline");
            output.Content.SetContent(content);
        }
    }
}