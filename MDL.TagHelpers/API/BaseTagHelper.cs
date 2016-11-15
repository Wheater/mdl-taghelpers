using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MDL.TagHelpers.API
{
    public abstract class BaseTagHelper : TagHelper
    {
        protected string[] Classes { get; set; }
        protected string TagName { get; set; }
        private bool GenerateUniqueId { get; set; }
        protected string Id { get; set; }
        protected IDictionary<object, object> Items;

        // Screen toggles
        public bool LargeScreenOnly { get; set; }
        public bool SmallScreenOnly { get; set; }

        public abstract void GenerateOutput(TagHelperOutput output, string content);

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = TagName;
            Items = context.Items;

            foreach (var cssClass in Classes)
            {
                output.AppendClass(cssClass);
            }

            if (LargeScreenOnly)
            {
                output.AppendClass("mdl-layout--large-screen-only");
            }

            if (SmallScreenOnly)
            {
                output.AppendClass("mdl-layout--small-screen-only");
            }

            if (GenerateUniqueId)
            {
                Id = output.SetId();
            }

            var content = await output.InnerContent();
            GenerateOutput(output, content);

            base.Process(context, output);
        }

        public override void Init(TagHelperContext context)
        {
            // Get the css classes
            var mdlAttributes = (MdlAttribute)this.GetType().GetTypeInfo().GetCustomAttribute(typeof(MdlAttribute));
            var cssAttributes = (CssAttribute)this.GetType().GetTypeInfo().GetCustomAttribute(typeof(CssAttribute));

            Classes = (cssAttributes != null) ? cssAttributes.Classes: new string[] { };
            TagName = (mdlAttributes != null) ? mdlAttributes.TagName: "";
            GenerateUniqueId = (mdlAttributes != null)? mdlAttributes.GenerateUniqueId : false;

            base.Init(context);
        }




        /*
         * 
         * Tags
         * 
         */
        public const string SNACKBAR = "mdl-snackbar";
        public const string LOADING = "mdl-loading";
        public const string H1 = "mdl-h1";
        public const string H2 = "mdl-h2";
        public const string H3 = "mdl-h3";
        public const string H4 = "mdl-h4";
        public const string HEADLINE = "mdl-headline";
        public const string TITLE = "mdl-title";
        public const string TOOLTIP = "mdl-tooltip";

        // layout
        public const string LAYOUT = "mdl-layout";
        public const string LAYOUT_HEADER = "mdl-layout-header";
        public const string LAYOUT_DRAWER = "mdl-layout-drawer";
        public const string LAYOUT_CONTENT = "mdl-layout-content";
        public const string LAYOUT_CONTENT_LINK = "mdl-layout-link";

        // Tab layout
        public const string TAB = "mdl-tab-layout";
        public const string TAB_BAR = "mdl-tab-layout-bar";
        public const string TAB_BAR_LINK = "mdl-tab-layout-link";
        public const string TAB_CONTENT = "mdl-tab-layout-content";
        public const string TAB_CONTENT_DEFAULT = "mdl-tab-layout-default-content";

        // Chips

        public const string CHIP = "mdl-chip";
        public const string CHIP_BUTTON = "mdl-chip-button";
        public const string CHIP_DELETABLE = "mdl-chip-button-deletable";
        public const string CHIP_CONTACT = "mdl-chip-contact";

    }
}
