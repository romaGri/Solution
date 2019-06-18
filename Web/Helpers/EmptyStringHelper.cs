using Microsoft.AspNetCore.Mvc.Rendering;



namespace TorrentsWebApp.Helpers
{
    public static class EmptyStringHelper
    {
        public static string SourceStr (this IHtmlHelper html, string source, string defValue = "")
        {
            return source ?? defValue;
        }
    }
}
