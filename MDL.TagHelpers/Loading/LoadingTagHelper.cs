using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Loading
{
    [HtmlTargetElement(LOADING)]
    [Mdl("div", true, "mdl-progress", "mdl-js-progress")]
    public class LoadingTagHelper : BaseTagHelper
    {
        public bool Intermediate { get; set; }

        public LoadingTagHelper()
        {
            Intermediate = false;
        }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            output.Content.Reinitialize();

            if(Intermediate)
            {
                output.AppendClass("mdl-progress__indeterminate");
            }
            
            output.Content.SetContent("");

            output.PostElement.AppendHtml($"<script type='text/javascript'>document.querySelector('#{Id}').addEventListener('mdl-componentupgraded', function() {{"+
               content
                + "});</script>");
        }
    }
}