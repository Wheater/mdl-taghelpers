using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
using System.Threading.Tasks;
using System;

namespace MDL.TagHelpers.Typography
{
    [HtmlTargetElement(HEADLINE)] 
    [Mdl("h5", "mdl-typography--headline")]
    public class HeadlineTagHelper : BaseTagHelper
    {
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.SetContent(content);
        }
    }
}