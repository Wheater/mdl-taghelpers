using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement(H2)]
    [Mdl("h2")]
    [Css("mdl-typography--display-3")]
    public class H2 : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetContent(content);
        }
    }
}