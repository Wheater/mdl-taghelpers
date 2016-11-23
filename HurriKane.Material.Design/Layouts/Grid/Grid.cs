using HurriKane.Material.Design.Api;
using HurriKane.Material.Design.Api.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace HurriKane.Material.Design.Layouts.Grid
{
    [RestrictChildren("grid-cell")]
    public class Grid : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-grid" };
    }

    public class GridCell : BaseTag
    {
        public const string ColumnSizeTemplate = "mdl-cell--{0}-col{1}";
        public const string ColumnOffsetTemplate = "mdl-cell--{0}-offset{1}";
        public const string ColumnOrderTemplate = "mdl-cell--order-{0}{1}";
        public const string ColumnHideTemplate = "mdl-cell--hide{0}";

        public int ColSize { get; set; } = -1;
        public int ColSizeDesktop { get; set; } = -1;
        public int ColSizeTablet { get; set; } = -1;
        public int ColSizePhone { get; set; } = -1;

        public int ColSizeOffset { get; set; } = -1;
        public int ColSizeOffsetDesktop { get; set; } = -1;
        public int ColSizeOffsetTablet { get; set; } = -1;
        public int ColSizeOffsetPhone { get; set; } = -1;

        public int ColOrder { get; set; } = -1;
        public int ColOrderDesktop { get; set; } = -1;
        public int ColOrderTablet { get; set; } = -1;
        public int ColOrderPhone { get; set; } = -1;

        public bool ColHide { get; set; } = false;
        public bool ColHideDesktop { get; set; } = false;
        public bool ColHideTablet { get; set; } = false;
        public bool ColHidePhone { get; set; } = false;

        public bool AlignTop { get; set; } = false; //with respecte to the parent
        public bool AlignMiddle { get; set; } = false;
        public bool AlignBottom { get; set; } = false;

        public bool NoSpacing { get; set; } = false;
        public bool Stretch { get; set; } = false;

        public override string[] CssClasses => new string[] { "mdl-cell" };

        public override string GenerateOutput(TagHelperOutput output, string content)
        {
            // col size
            if (ColSize.WithinRange()) { }
            output.AppendCssClass(String.Format(ColumnSizeTemplate, ColSize, String.Empty));
            if (ColSizeDesktop.WithinRange())
                output.AppendCssClass(String.Format(ColumnSizeTemplate, ColSizeDesktop, "-desktop"));
            if (ColSizeTablet.WithinRange())
                output.AppendCssClass(String.Format(ColumnSizeTemplate, ColSizeTablet, "-tablet"));
            if (ColSizePhone.WithinRange())
                output.AppendCssClass(String.Format(ColumnSizeTemplate, ColSizePhone, "-phone"));

            // offset
            if (ColSizeOffset.WithinRange())
                output.AppendCssClass(String.Format(ColumnOffsetTemplate, ColSizeOffset, String.Empty));
            if (ColSizeOffsetDesktop.WithinRange())
                output.AppendCssClass(String.Format(ColumnOffsetTemplate, ColSizeOffsetDesktop, "-desktop"));
            if (ColSizeOffsetTablet.WithinRange())
                output.AppendCssClass(String.Format(ColumnOffsetTemplate, ColSizeOffsetTablet, "-tablet"));
            if (ColSizeOffsetPhone.WithinRange())
                output.AppendCssClass(String.Format(ColumnOffsetTemplate, ColSizeOffsetPhone, "-phone"));

            // order
            if (ColOrder.WithinRange())
                output.AppendCssClass(String.Format(ColumnOrderTemplate, ColOrder, String.Empty));
            if (ColOrderDesktop.WithinRange())
                output.AppendCssClass(String.Format(ColumnOrderTemplate, ColOrderDesktop, "-desktop"));
            if (ColOrderTablet.WithinRange())
                output.AppendCssClass(String.Format(ColumnOrderTemplate, ColOrderTablet, "-tablet"));
            if (ColOrderPhone.WithinRange())
                output.AppendCssClass(String.Format(ColumnOrderTemplate, ColOrderPhone, "-phone"));

            // hide
            if (ColHide)
                output.AppendCssClass(String.Format(ColumnHideTemplate, String.Empty));
            if (ColHideDesktop)
                output.AppendCssClass(String.Format(ColumnHideTemplate, "-desktop"));
            if (ColHideTablet)
                output.AppendCssClass(String.Format(ColumnHideTemplate, "-tablet"));
            if (ColHidePhone)
                output.AppendCssClass(String.Format(ColumnHideTemplate, "-phone"));

            if (Stretch)
                output.AppendCssClass("mdl-cell--stretch");

            if (AlignTop)
                output.AppendCssClass("mdl-cell--top");
            if (AlignMiddle)
                output.AppendCssClass("mdl-cell--middle");
            if (AlignBottom)
                output.AppendCssClass("mdl-cell--bottom");

            return content;
        }
    }
}