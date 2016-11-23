using HurriKane.Material.Design.Api;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HurriKane.Material.Design.Layouts.Footer
{
    [RestrictChildren("footer-left", "footer-right")]
    public class Footer : BaseTag
    {
        public override string TagName => "footer";
        public override string[] CssClasses => new string[] { "mdl-mini-footer" };
    }

    [RestrictChildren("footer-logo", "footer-link-list")]
    public class FooterLeft : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-mini-footer__left-section" };
    }

    [RestrictChildren("footer-social-button")]
    public class FooterRight : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-mini-footer__right-section" };
    }

    public class FooterSocialButton : BaseTag
    {
        public override string TagName => "button";
        public override string[] CssClasses => new string[] { "mdl-mini-footer__social-btn" };
    }

    [RestrictChildren("footer-link-list-item")]
    public class FooterLinkList : BaseTag
    {
        public override string TagName => "ul";
        public override string[] CssClasses => new string[] { "mdl-mini-footer__link-list" };
    }

    public class FooterLinkListItem : BaseTag
    {
        public override string TagName => "li";
        public override string[] CssClasses => new string[] { "mdl-mini-footer__link-list-item" };
    }

    public class FooterLogo : BaseTag
    {
        public override string[] CssClasses => new string[] { "mdl-logo" };
    }
}