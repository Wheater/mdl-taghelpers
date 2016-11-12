using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;

namespace MDL.TagHelpers.API
{
    public abstract class BaseTagHelper : TagHelper
    {
        public string[] Classes { get; set; }
        public string TagName { get; set; }
        private bool GenerateUniqueId { get; set; }
        public string Id { get; set; }

        public abstract void GenerateOutput(TagHelperOutput output, string content);

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = TagName;
            
            foreach (var cssClass in Classes)
            {
                output.AppendClass(cssClass);
            }
            
            if(GenerateUniqueId)
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
            var cssAttributes = (MdlAttribute) this.GetType().GetTypeInfo().GetCustomAttribute(typeof(MdlAttribute));
            Classes = cssAttributes.Classes;
            TagName = cssAttributes.TagName;
            GenerateUniqueId = cssAttributes.GenerateUniqueId;

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
        
    }
}
