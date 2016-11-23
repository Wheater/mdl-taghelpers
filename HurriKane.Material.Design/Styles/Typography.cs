using HurriKane.Material.Design.Api;

namespace HurriKane.Material.Design.Styles
{
    public class H1 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--display-4" };
        public override string TagName => "h1";
    }

    public class H2 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--display-3" };
        public override string TagName => "h2";
    }

    public class H3 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--display-2" };
        public override string TagName => "h3";
    }

    public class H4 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--display-1" };
        public override string TagName => "h4";
    }

    public class H5 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--headline" };
        public override string TagName => "h5";
    }

    public class H6 : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-typography--title" };
        public override string TagName => "h6";
    }
}