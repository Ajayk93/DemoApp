using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.CustomHTMLHelper
{
    public static class CustomHelper
    {
        public static MvcHtmlString GetLabel(this HtmlHelper obj, string content)
        {
            var label = "<label style='color: red'>"+ content + "</label>";
            return new MvcHtmlString(label);
        }
    }
}