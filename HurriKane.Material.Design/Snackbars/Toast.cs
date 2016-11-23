using HurriKane.Material.Design.Api;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Snackbars
{
    public class Toast : BaseTag
    {
        public string Text { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            return $"<div class='mdl-snackbar__text'>{Text}</div><button type='button' class='mdl-snackbar__action'></button>";
        }
    }
}