using Microsoft.AspNetCore.Razor.TagHelpers;
using Saya.Mvc.Bootstrap.Enums.ColorStyles;
using Saya.Mvc.Bootstrap.Enums.Size;

namespace Saya.Mvc.Bootstrap.TagHelpers.Button
{

    [HtmlTargetElement("a", Attributes = "btn-style")]
    [HtmlTargetElement("button", Attributes = "btn-style")]
    [HtmlTargetElement("saya-button")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("btn-style")]
        public ButtonColorStyle BtnStyle { get; set; } = ButtonColorStyle.Primary;

        [HtmlAttributeName("class")]
        public string CssClass { get; set; }

        [HtmlAttributeName("outline")]
        public bool Outline { get; set; } = false;

        [HtmlAttributeName("size")]
        public BootstrapSize Size { get; set; } = BootstrapSize.Normal;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (context.TagName == "saya-button")
            {
                output.TagName = "button";
            }

            if (string.IsNullOrEmpty(CssClass))
                CssClass = "btn";
            else
                CssClass = "btn " + CssClass;

            var btn_style_class = GetButtonStyleClassName(BtnStyle, Outline);

            if (!string.IsNullOrEmpty(btn_style_class))
            {
                CssClass += $" {btn_style_class}";
            }

            if (Size == BootstrapSize.Large)
                CssClass += " btn-lg";
            else if (Size == BootstrapSize.Small)
                CssClass += " btn-sm";

            output.Attributes.Add("class", CssClass);
        }

        private string GetButtonStyleClassName(ButtonColorStyle colorStyle, bool outline)
        {
            var s_name = colorStyle switch
            {
                ButtonColorStyle.Primary => "primary",
                ButtonColorStyle.Secondary => "secondary",
                ButtonColorStyle.Success => "success",
                ButtonColorStyle.Danger => "danger",
                ButtonColorStyle.Warning => "warning",
                ButtonColorStyle.Info => "info",
                ButtonColorStyle.Light => "light",
                ButtonColorStyle.Dark => "dark",
                ButtonColorStyle.Link => "link",
                _ => string.Empty
            };

            if (string.IsNullOrEmpty(s_name))
                return string.Empty;
            if (outline)
                return $"btn-outline-{s_name}";
            else
                return $"btn-{s_name}";
        }
    }
}
