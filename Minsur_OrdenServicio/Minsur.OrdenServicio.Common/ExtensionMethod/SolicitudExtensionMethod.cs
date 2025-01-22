using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web;

namespace Minsur.OrdenServicio.Common.ExtensionMethod
{
    public static class SolicitudExtensionMethod
    {
        public static string ToStringDateTimeNullFormat(this DateTime? value, string format)
        {
            if (value == null) { return string.Empty; }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            return string.Format("{0: " + format + "}", value);
        }

        public static string TextToHtml(this string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br/>");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }
    }
}
