using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Tables
{
    public class Table : BaseTag
    {
        public override string TagName => "table";
        public override string[] CssClasses => new string[] { "mdl-data-table", "mdl-js-data-table" };

        public bool HasShadow { get; set; } = true;
        public bool IsSelectable { get; set; } = true;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (HasShadow)
                output.AppendCssClass("mdl-shadow--2dp");
            if (IsSelectable)
                output.AppendCssClass("mdl-data-table--selectable");
            return content;
        }
    }

    [HtmlTargetElement("th")]
    public class TableHeaderCell : BaseTag
    {
        public override string TagName => "th";

        public bool IsNonNumeric { get; set; } = false;
        public bool Asc { get; set; } = false;
        public bool Desc { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (IsNonNumeric)
                output.AppendCssClass("mdl-data-table__cell--non-numeric");
            if (Asc)
                output.AppendCssClass("mdl-data-table__header--sorted-ascending");
            if (Desc)
                output.AppendCssClass("mdl-data-table__header--sorted-descending");
            return content;
        }
    }

    [HtmlTargetElement("td")]
    public class TableDefinition : BaseTag
    {
        public override string TagName => "td";

        public bool IsNonNumeric { get; set; } = false;

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            if (IsNonNumeric)
                output.AppendCssClass("mdl-data-table__cell--non-numeric");
            return content;
        }
    }
}