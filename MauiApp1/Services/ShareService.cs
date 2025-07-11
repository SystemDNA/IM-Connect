using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class ShareService
    {
        public async Task ShareText(string text, string title)
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = title
            });
        }
        public static string StripHtmlTags(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
