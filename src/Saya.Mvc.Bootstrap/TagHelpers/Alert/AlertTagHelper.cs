using Microsoft.AspNetCore.Razor.TagHelpers;
using Saya.Mvc.Bootstrap.Enums.ColorStyles;

namespace Saya.Mvc.Bootstrap.TagHelpers.Alert
{
    [HtmlTargetElement("saya-alert")]
    [HtmlTargetElement("div", Attributes = "alert-style")]
    public class AlertTagHelper : TagHelper
    {

        [HtmlAttributeName("alert-style")]
        public BootstrapColorStyle AlertStyle { get; set; } = BootstrapColorStyle.Primary;

        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        [HtmlAttributeName("dismissible")]
        public bool Dismissible { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.TagName == "saya-alert")
                output.TagName = "div";

            string css_class_name = "alert ";

            css_class_name += GetAlertStyleClassName(AlertStyle);
            
            if(Dismissible)
            {
                css_class_name += " alert-dismissible fade show";
                output.PreContent.SetHtmlContent("<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>");
            }

            if (!string.IsNullOrEmpty(CssClass))
            {
                css_class_name += " " + CssClass;
            }

            output.Attributes.Add("class", css_class_name);
            output.Attributes.Add("role", "alert");

            output.TagMode = TagMode.StartTagAndEndTag;
        }

        private string GetAlertStyleClassName(BootstrapColorStyle colorStyle)
        {
            var s_name = colorStyle switch
            {
                BootstrapColorStyle.Primary => "primary",
                BootstrapColorStyle.Secondary => "secondary",
                BootstrapColorStyle.Success => "success",
                BootstrapColorStyle.Danger => "danger",
                BootstrapColorStyle.Warning => "warning",
                BootstrapColorStyle.Info => "info",
                BootstrapColorStyle.Light => "light",
                BootstrapColorStyle.Dark => "dark",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(s_name))
                return string.Empty;

            return $"alert-{s_name}";
        }
    }
}
