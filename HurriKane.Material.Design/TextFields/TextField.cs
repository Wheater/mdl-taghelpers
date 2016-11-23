using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.TextFields
{
    public class InputText : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-textfield", "mdl-js-textfield" };
        public bool Floating { get; set; }
        public bool IsInvalid { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Floating)
            {
                output.AppendCssClass("mdl-textfield--floating-label");
            }
            if (IsInvalid)
            {
                output.AppendCssClass("is-invalid");
            }
            var input = $"<input class='mdl-textfield__input' type='text' id='{Id}'>";
            var label = $"<label class='mdl-textfield__label' for='{Id}'>{content}</label>";
            return $"{input}{label}";
        }
    }

    public class InputNumeric : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-textfield", "mdl-js-textfield" };
        public bool IsInvalid { get; set; } = false;
        public string ErrorMessage { get; set; } = "Input is not a number!";
        public bool Floating { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Floating)
            {
                output.AppendCssClass("mdl-textfield--floating-label");
            }
            if (IsInvalid)
            {
                output.AppendCssClass("is-invalid");
            }

            var input = $"<input class='mdl-textfield__input' type='text'  pattern='-?[0-9]*(\\.[0-9]+)?' id='{Id}'>";
            var label = $"<label class='mdl-textfield__label' for='{Id}'>{content}</label>";
            var error = $"<span class='mdl-textfield__error'>{ErrorMessage}</span>";
            return $"{input}{label}{error}";
        }
    }

    public class InputMultiline : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-textfield", "mdl-js-textfield" };
        public bool IsInvalid { get; set; } = false;
        public int Rows { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (IsInvalid)
            {
                output.AppendCssClass("is-invalid");
            }

            var input = $"<textarea class='mdl-textfield__input' type='text' rows='{Rows}' id='{Id}'></textarea>";
            var label = $"<label class='mdl-textfield__label' for='{Id}'>{content}</label>";
            return $"{input}{label}";
        }
    }

    [RestrictChildren("icon")]
    public class InputExpandable : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-textfield", "mdl-js-textfield" };
        public bool IsInvalid { get; set; } = false;
        public bool Expandable { get; set; }
        public int Rows { get; set; }
        public string InputText { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (Expandable)
            {
                output.AppendCssClass("mdl-textfield--expandable");
            }
            if (IsInvalid)
            {
                output.AppendCssClass("is-invalid");
            }

            var button = $"<label class='mdl-button mdl-js-button mdl-button--icon' for='{Id}'>{content}</label>";
            var input = $"<input class='mdl-textfield__input' type='text' id='{Id}'>";
            var label = $"<label class='mdl-textfield__label' for='{Id}-expandable'>{InputText}</label>";
            var holder = $"<div class='mdl-textfield__expandable-holder'>{input}{label}</div>";

            return $"{button}{holder}";
        }
    }
}