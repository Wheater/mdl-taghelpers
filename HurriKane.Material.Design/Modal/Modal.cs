using HurriKane.Material.Design.Api;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace HurriKane.Material.Design.Modal
{
    public class Modal : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-modal" };
        public string CloseButtonText { get; set; }

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            var id = output.Attributes["id"]?.Value as HtmlString;

            if (String.IsNullOrEmpty(id.Value))
            {
                throw new MissingFieldException("The ID field is missing");
            }

            return $"<div class='close-{id}'><button class='mdl-button mdl-js-button mdl-button--fab'><i class='material-icons'>close</i></button></div><div class='modal-content'>{content}</div>";
        }
    }
}