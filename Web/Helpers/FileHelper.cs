using ApplicationCore.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TorrentsWebApp.Helpers
{
    public static class FileHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, File[] items)
        {
            string result = "<details> <ul>";
            foreach (var item in items)
            {
                result += $"<li>{item.Name + " Размер " + int.Parse(item.Size)/1024 + " Kb" }</li>";
            }
            result += "</ul></details>";
            return new HtmlString(result);
        }
    }
}

