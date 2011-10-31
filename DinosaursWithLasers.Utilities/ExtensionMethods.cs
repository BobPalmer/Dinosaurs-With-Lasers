using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace DinosaursWithLasers.Utilities
{
    public static class ExtensionMethods
    {
        public static int ToInt(this int? src)
        {
            int r;
            int.TryParse(src.ToString(), out r);
            return r;
        }
    }

    public static class HtmlHelpers
    {
        public static string QuickList(this HtmlHelper helper, IList<string> listData )
        {
            var output = new StringBuilder();
            output.Append("<ul>");
            foreach (var v in listData)
            {
                output.Append(String.Format("<li>{0}</li>", v));
            }
            output.Append("</ul>");
            return output.ToString();
        }
    }
}
