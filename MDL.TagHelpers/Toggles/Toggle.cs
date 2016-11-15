using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;

using System;

namespace MDL.TagHelpers.Toggles
{
    [HtmlTargetElement("mdl-toggle-checkbox")] 
    [Mdl("label")]
    [Css("mdl-checkbox", "mdl-js-checkbox")]
    public class CheckboxTagHelper : BaseTagHelper
    {
        public bool Ripple {get; set;}

        public CheckboxTagHelper ()
        {
            Ripple = true;
        }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var id = TagHelperOutputExtensions.UniqueId();
            output.Attributes.SetAttribute("for", id);
            
            if(Ripple) {
                 output.AppendClass("mdl-js-ripple-effect");  
            }
            
            output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-checkbox__input\"/>");
            output.Content.AppendHtml($"<span class=\"mdl-checkbox__label\">{content}</span>");
        }

        
    }

    [HtmlTargetElement("mdl-toggle-radio")]
    [Mdl("label")]
    [Css("mdl-radio", "mdl-js-radio")]
    public class RadioTagHelper : BaseTagHelper
    {
        public bool Ripple { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }

        public RadioTagHelper()
        {
            Ripple = true;
            Checked = false;
        }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var id = TagHelperOutputExtensions.UniqueId();
            var checkedAttr = Checked ? "checked" : String.Empty;
            output.Attributes.SetAttribute("for", id);
            
            if (Ripple)
            {
                output.AppendClass("mdl-js-ripple-effect");
            }

            output.Content.AppendHtml($"<input type=\"radio\" id=\"{id}\" class=\"mdl-radio__button\" name=\"{Name}\" value=\"{Value}\" {checkedAttr}/>");
            output.Content.AppendHtml($"<span class=\"mdl-radio__label\">{content}</span>");
        }
    }


    [HtmlTargetElement("mdl-toggle-icon")]
    [Mdl("label")]
    [Css("mdl-icon-toggle", "mdl-js-icon-toggle")]
    public class IconToggleTagHelper : BaseTagHelper
    {
        public bool Ripple { get; set; }
        public bool Checked { get; set; }
        
        public IconToggleTagHelper()
        {
            Ripple = true;
            Checked = false;
        }

        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            var id = TagHelperOutputExtensions.UniqueId();
            var checkedAttr = Checked ? "checked" : String.Empty;
            output.Attributes.SetAttribute("for", id);
            
            if (Ripple)
            {
                output.AppendClass("mdl-js-ripple-effect");
            }

            output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-icon-toggle__input\" {checkedAttr}/>");
            output.Content.AppendHtml($"<i class=\"mdl-icon-toggle__label material-icons\">{content}</i>");
        }
    }
}