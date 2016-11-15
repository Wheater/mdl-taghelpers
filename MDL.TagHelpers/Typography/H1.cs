using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;
using System;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement(H1)] 
    [Mdl("h1")]
    [Css("mdl-typography--display-4")]
    public class H1 : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetContent(content);
        }
    }
}