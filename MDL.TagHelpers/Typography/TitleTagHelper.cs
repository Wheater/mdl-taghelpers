using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement("mdl-title")] 
    public class TitleTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h6";
            var content = await output.InnerContent();

            output.AppendClass("mdl-typography--title");
            output.Content.SetContent(content);
        }
    }
}