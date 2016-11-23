using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Api
{
    public class StyleDependency : BaseTag
    {
        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            output.SuppressOutput();
            var fontRoboto = $"<link rel='stylesheet' href='http://fonts.googleapis.com/css?family=Roboto:300,400,500,700' type='text/css' />";
            var fontIcons = $"<link rel='stylesheet' href='https://fonts.googleapis.com/icon?family=Material+Icons' type='text/css' />";
            var materialDesignCss = $"<link rel='stylesheet' href='https://code.getmdl.io/1.2.1/material.red-blue.min.css' />";
            var modalAnimate = $" <link rel='stylesheet' href='//cdnjs.cloudflare.com/ajax/libs/animate.css/3.2.0/animate.min.css'>";

            output.PostContent.AppendHtml($"{fontIcons}{fontRoboto}{materialDesignCss}{modalAnimate}");
            return content;
        }
    }
}