using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;

namespace MDL.TagHelpers.Snackbars
{
    [HtmlTargetElement(SNACKBAR)]
    [Mdl("div", true)]
    [Css("mdl-snackbar", "mdl-js-snackbar")]
    public class Snackbar : BaseTagHelper
    {
        public string Text { get; set; }
        public string ActionText { get; set; }
        public string TriggerId { get; set; }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var buttonId = TagHelperOutputExtensions.UniqueId();

            if(String.IsNullOrEmpty(content))
            {
                content = "{}";
            }
            output.Content.SetHtmlContent(
                $@"<div class='mdl-snackbar__text'>{Text}</div>
                <button class='mdl-snackbar__action' type='button'>{ActionText}</button>
                <script>
                (function() {{
                    var snackbarContainer = document.querySelector('#{this.Id}');
                    var showSnackbarButton = document.querySelector('#{TriggerId}');
                        
                        showSnackbarButton.addEventListener('click', function() {{
                            var data = {content};
                            snackbarContainer.MaterialSnackbar.showSnackbar(data);
                        }});
                }}());
                </script>");
            
        }
    }
}
