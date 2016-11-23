using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Api
{
    public abstract class BaseTag : TagHelper
    {
        public virtual string GenerateOutput(TagHelperOutput output, string content) => null;

        public virtual string TagName { get; } = "div";
        public virtual string[] CssClasses { get; } = new string[] { };
        public virtual bool IgnoreId { get; } = true;
        public virtual bool IgnoreNullContent { get; } = false;
        protected string Id { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var _content = output.Content.IsModified ? output.Content.GetContent() : (await output.GetChildContentAsync()).GetContent();

            output.TagName = TagName;

            Id = context.UniqueId;
            if (!IgnoreId)
                output.Attributes.SetAttribute("id", Id);

            if (CssClasses != null && CssClasses.Length > 0)
                output.AppendCssClass(CssClasses);

            var _modcontent = "";
            if (!IgnoreNullContent)
            {
                _modcontent = GenerateOutput(output, _content) ?? _content;
            }

            output.Content.SetHtmlContent(_modcontent);

            base.Process(context, output);
        }
    }
}