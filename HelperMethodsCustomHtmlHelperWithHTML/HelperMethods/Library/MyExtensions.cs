using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace HelperMethods.Library
{
    public static class MyExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", string typ = "button", string text = "")
        {
            string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button>", id, typ.ToString(), text);

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", ButtonType typ = ButtonType.button, string text = "")
        {
            string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button>", id, typ.ToString(), text);

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", string cssClass = "", ButtonType typ = ButtonType.button, string text = "")
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass(cssClass);
            tag.GenerateId(id);

            tag.Attributes.Add("type", typ.ToString());
            tag.Attributes.Add("name", id);

            tag.SetInnerText(text);

            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id = "", int borderSize = 3, string borderType = "solid", string text = "")
        {
            string html = string.Format("<p id='{0}' name='{0}' style='border-width:{1}px;border-style:{2}'>{3}</p>", id, borderSize, borderType, text);

            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id = "", int borderSize = 3, string borderType = "solid", Func<object, HelperResult> template = null)
        {
            string html = string.Format("<p id='{0}' name='{0}' style='border-width:{1}px;border-style:{2}'>{3}</p>", id, borderSize, borderType, template.Invoke(null));

            return MvcHtmlString.Create(html);
        }
    }

    public enum ButtonType
    {
        button = 0,
        submit = 1,
        reset = 2
    }
}