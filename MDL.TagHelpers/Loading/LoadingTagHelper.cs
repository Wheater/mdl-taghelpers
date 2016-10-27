using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Loading
{
    [HtmlTargetElement("mdl-loading")]
    public class LoadingTagHelper : TagHelper
    {
        public bool Intermediate { get; set; }

        public LoadingTagHelper()
        {
            Intermediate = false;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();
            output.Content.Reinitialize();
            output.TagName = "div";

            output.AppendClass("mdl-progress");
            output.AppendClass("mdl-js-progress");

            if(Intermediate)
            {
                output.AppendClass("mdl-progress__indeterminate");

            }

            var id = output.SetId();
            output.Content.SetContent("");

            output.PostElement.AppendHtml($"<script type='text/javascript'>document.querySelector('#{id}').addEventListener('mdl-componentupgraded', function() {{"+
               content
                + "});</script>");
        }
    }
}

/*
 * 
 * <div id="p1" class="mdl-progress mdl-js-progress"></div>
<script>
  document.querySelector('#p1').addEventListener('mdl-componentupgraded', function() {
    this.MaterialProgress.setProgress(44);
  });
</script>
 * 
 */
