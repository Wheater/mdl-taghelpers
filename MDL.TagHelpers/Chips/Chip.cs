using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Chips
{
    [HtmlTargetElement(CHIP)]
    [Mdl("span", true)]
    [Css("mdl-chip")]
    public class Chip : BaseTagHelper
    {
        public bool IsDeletable { get; set; } = false;
        public bool IsButton { get; set; } = false;
        public bool IsContact { get; set; } = false;
        public bool IsDeletableContact { get; set; } = false;
        public string Src { get; set; }
        public string Href { get; set; } = "#";
        
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            if(IsDeletable)
            {
                output.AppendClass("mdl-chip--deletable");
                output.Content.SetHtmlContent($"<span class='mdl-chip__text'>{content}</span><button type='button' class='mdl-chip__action'><i class='material-icons'>cancel</i></button>");
            }
            else if(IsButton)
            {
                output.TagName = "button";
                output.Attributes.Add("type", "button");
                output.Content.SetHtmlContent($"<span class='mdl-chip__text'>{content}</span>");
            }
            else if (IsContact)
            {
                var letter = $"<span class='mdl-chip__contact mdl-color--teal mdl-color-text--white'>{content.First()}</span>";
                var text = $"<span class='mdl-chip__text'>{content}</span>";

                output.AppendClass("mdl-chip--contact");
                output.Content.SetHtmlContent($"{letter}{text}");
            }
            else if (IsDeletableContact)
            {
                var icon = $"<img class='mdl-chip__contact' src='" + Src + "'></img>";
                var text = $"<span class='mdl-chip__text'>{content}</span>";
                var cancel = $"<a href='{Href}' class='mdl-chip__action'><i class='material-icons'>cancel</i></a>";
                output.AppendClass("mdl-chip--contact mdl-chip--deletable");
                output.Content.SetHtmlContent($"{icon}{text}{cancel}");
            }
            else
            {
                // Just give a simple chip
                output.Content.SetHtmlContent($"<span class='mdl-chip__text'>{content}</span>");
            }
        }
    }
}

/*
 * <!-- Deletable Contact Chip -->
<span class="mdl-chip mdl-chip--contact mdl-chip--deletable">
    <img class="mdl-chip__contact" src="/templates/dashboard/images/user.jpg"></img>
    <span class="mdl-chip__text">Deletable Contact Chip</span>
    <a href="#" class="mdl-chip__action"><i class="material-icons">cancel</i></a>
</span>
 * 
 * 
 */
