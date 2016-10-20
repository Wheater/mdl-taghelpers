using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
namespace MDL.TagHelpers.API
{
    public static class TagHelperOutputExtensions
    {
        public static void PrependClass(this TagHelperOutput output, string cssClass) {
            string classValue;
            if (output.Attributes.ContainsName("class"))
            {
                classValue = string.Format("{0} {1}", output.Attributes["class"].Value, cssClass);
            }
            else
            {
                classValue = cssClass;
            }

            output.Attributes.SetAttribute("class", classValue);
        }

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

        public static void AddMaterialIconClass(this TagHelperOutput output) {
            output.AppendClass("material-icons");
        }

        public static string Id(this TagHelperOutput output)
        {
            if (output.Attributes.ContainsName("id"))
            {
                return output.Attributes["id"].Value.ToString();
            }

            var id = UniqueId();
            output.Attributes.SetAttribute("id",id);
            return id;
        }

        public static string UniqueId()
        {
            return "md-" + Guid.NewGuid().ToString("N");
        } 

        // public static string Content(this TagHelperOutput output) {
        //     return output.Content.IsModified ? output.Content.GetContent() :
        //         (await output.GetChildContentAsync()).GetContent();

        // }
    }
}
