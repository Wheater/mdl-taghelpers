using Microsoft.AspNetCore.Razor.TagHelpers;
using MDL.TagHelpers.API;

using System;

namespace MDL.TagHelpers.Toggles
{
    [HtmlTargetElement("mdl-toggle-checkbox")] 
    public class CheckboxTagHelper : TagHelper, HasRipple
    {
        public bool Ripple {get; set;}

        public CheckboxTagHelper ()
        {
            Ripple = true;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();
            var id = TagHelperOutputExtensions.UniqueId();
            output.TagName = "label";
            output.Attributes.SetAttribute("for", id);

            output.AppendClass("mdl-checkbox");
            output.AppendClass("mdl-js-checkbox");
 
            if(Ripple) {
                 output.AppendClass("mdl-js-ripple-effect");  
            }
            
            output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-checkbox__input\"/>");
            output.Content.AppendHtml($"<span class=\"mdl-checkbox__label\">{content}</span>");
        }
    }

    [HtmlTargetElement("mdl-toggle-radio")]
    public class RadioTagHelper : TagHelper, HasRipple
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

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();
            var id = TagHelperOutputExtensions.UniqueId();
            var checkedAttr = Checked ? "checked" : String.Empty;
            output.TagName = "label";
            output.Attributes.SetAttribute("for", id);

            output.AppendClass("mdl-radio ");
            output.AppendClass("mdl-js-radio");

            if (Ripple)
            {
                output.AppendClass("mdl-js-ripple-effect");
            }

            output.Content.AppendHtml($"<input type=\"radio\" id=\"{id}\" class=\"mdl-radio__button\" name=\"{Name}\" value=\"{Value}\" {checkedAttr}/>");
            output.Content.AppendHtml($"<span class=\"mdl-radio__label\">{content}</span>");
        }
    }


    [HtmlTargetElement("mdl-toggle-icon")]
    public class IconToggleTagHelper : TagHelper, HasRipple
    {
        public bool Ripple { get; set; }
        public bool Checked { get; set; }

        public IconToggleTagHelper()
        {
            Ripple = true;
            Checked = false;
        }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.InnerContent();
            var id = TagHelperOutputExtensions.UniqueId();
            var checkedAttr = Checked ? "checked" : String.Empty;
            output.TagName = "label";
            output.Attributes.SetAttribute("for", id);

            output.AppendClass("mdl-icon-toggle");
            output.AppendClass("mdl-js-icon-toggle");

            if (Ripple)
            {
                output.AppendClass("mdl-js-ripple-effect");
            }

            output.Content.AppendHtml($"<input type=\"checkbox\" id=\"{id}\" class=\"mdl-icon-toggle__input\" {checkedAttr}/>");
            output.Content.AppendHtml($"<i class=\"mdl-icon-toggle__label material-icons\">{content}</i>");
        }
    }
}