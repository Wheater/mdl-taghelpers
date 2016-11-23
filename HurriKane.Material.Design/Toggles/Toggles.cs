using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Toggles
{
    public class Checkbox : BaseTag
    {
        public override string TagName => "label";
        public override string[] CssClasses => new string[] { "mdl-checkbox", "mdl-js-checkbox" };
        public bool Ripple { get; set; }
        public bool Checked { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            var checkedOrNot = Checked ? "checked" : "";

            output.Attributes.Add("for", Id);
            return $"<input type='checkbox' id='{Id}' class='mdl-checkbox__input'><span class='mdl-checkbox__label'>{content}</span>";
        }
    }

    public class CheckboxIcon : Checkbox
    {
        public override string[] CssClasses => new string[] { "mdl-icon-toggle", "mdl-js-icon-toggle" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            var checkedOrNot = Checked ? "checked" : "";

            output.Attributes.Add("for", Id);
            return $"<input type='checkbox' id='{Id}' class='mdl-icon-toggle__input'><i class='mdl-icon-toggle__label material-icons'>{content}</i>";
        }
    }

    public class Radio : BaseTag
    {
        public override string TagName => "label";
        public override string[] CssClasses => new string[] { "mdl-radio", "mdl-js-radio" };
        public bool Ripple { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            output.Attributes.Add("for", Id);

            var checkedOrNot = Checked ? "checked" : "";
            return $"<input type='radio' id='{Id}' class='mdl-radio__button' name='{Name}' value='{Value}' {checkedOrNot}><span class='mdl-radio__label'>{content}</span>";
        }
    }

    public class Switch : Checkbox
    {
        public override string[] CssClasses => new string[] { "mdl-switch", "mdl-js-switch" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Ripple)
                output.AppendCssClass("mdl-js-ripple-effect");

            output.Attributes.Add("for", Id);

            var checkedOrNot = Checked ? "checked" : "";
            return $"<input type='checkbox' id='{Id}' class='mdl-switch__input'><span class='mdl-switch__label'>{content}</span>";
        }
    }
}