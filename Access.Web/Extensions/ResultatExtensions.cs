using System.Text;
using System.Text.Encodings.Web;
using Access.AppCore.Models;

namespace Access.Web.Extensions
{
    public static class ResultatExtensions
    {
        public static string ToMessageString(this Resultat resultat)
        {
            var builder = new StringBuilder();
            foreach (var message in resultat.Messages)
            {
                builder.Append(HtmlEncoder.Default.Encode($"{message.Code}:{message.Contenu}"));
            }

            return builder.ToString();
        }
    }
}
