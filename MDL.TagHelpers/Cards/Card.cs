using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDL.TagHelpers.API;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.Cards
{
    [HtmlTargetElement(CARD)]
    [Mdl("div")]
    [Css("mdl-card")]
    //[RestrictChildren()]
    public class Card : BaseTagHelper
    {
        public int ShadowDepth { get; set; } = 2;
        public string Title { get; set; }
        public string SupportingText { get; set; }
        public override void GenerateOutput(TagHelperOutput output, string content)
        {
            // Add checks
            output.AppendClass($"mdl-shadow--{ShadowDepth}dp");
            var title = $"<div class='mdl-card__title'><h2 class='mdl-card__title-text'>{Title}</h2></div>";
            var supportingText = $"<div class='mdl-card__supporting-text'>{SupportingText}</div>";

            /*
             * 
             * <div class="mdl-card__actions mdl-card--border">
    <a class="mdl-button mdl-button--colored mdl-js-button mdl-js-ripple-effect">
      Get Started
    </a>
  </div>
  <div class="mdl-card__menu">
    <button class="mdl-button mdl-button--icon mdl-js-button mdl-js-ripple-effect">
      <i class="material-icons">share</i>
    </button>
  </div>
             * 
             */

            output.Content.SetHtmlContent($"{title}");
        }
    }
}
