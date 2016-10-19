using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MDL.TagHelpers.API
{
    public static class TagHelperOutputExtensions
    {
        public static void AppendClass(this TagHelperOutput output, string cssClass) {
            string classValue;
            if (output.Attributes.ContainsName("class"))
            {
                classValue = string.Format("{1} {0}", output.Attributes["class"].Value, cssClass);
            }
            else
            {
                classValue = cssClass;
            }

            output.Attributes.SetAttribute("class", classValue);
        }
    }
}
