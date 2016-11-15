using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement(H3)]
    [Mdl("h3")]
    [Css("mdl-typography--display-2")]
    public class H3 : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetContent(content);
        }
    }
}