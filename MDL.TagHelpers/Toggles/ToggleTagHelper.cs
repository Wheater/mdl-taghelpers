using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;
// using System.Web.Mvc;

using System;

namespace MDL.TagHelpers.Tooltips
{
    [HtmlTargetElement("mdl-toggle")] 
    public class ToggleTagHelper : TagHelper, HasRipple
    {
        public bool Ripple {get; set;}
        public string Text { get; set; }

        public ToggleTagHelper ()
        {
            Ripple = false;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            // var content = await output.Content();
            var id = output.Id();
            output.TagName = "label";
            output.PrependClass("mdl-checkbox");
            output.PrependClass("mdl-js-checkbox");
            output.Attributes.SetAttribute("for", id);

            // if(Ripple) {
            //     output.AppendClass("mdl-js-ripple-effect");  
            // }
            
            // output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-checkbox__input\"/>");
            // var textCtl = new TagBuilder("span");
            // textCtl.InnerHtml.Append(content);
            
            
            // output.Content.SetContent(textCtl.ToString());

            

        }
    }
}

/*
<label for="chkbox1" class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect">
  <input type="checkbox" id="chkbox1" class="mdl-checkbox__input">
  <span class="mdl-checkbox__label">Enable AutoSave</span>
</label>
*/