using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace HurriKane.Material.Design.Api.Extensions
{
    public static class TagExtensions
    {
        public static void AppendCssClass(this TagHelperOutput output, params string[] cssClass)
        {
            var currentValue = output.Attributes.ContainsName("class")
                ? output.Attributes["class"].Value.ToString()
                : string.Empty;

            var finalCssClass = cssClass.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            finalCssClass.Insert(0, currentValue);

            output.Attributes.SetAttribute("class", string.Join(" ", finalCssClass).Trim(' '));
        }
    }
}