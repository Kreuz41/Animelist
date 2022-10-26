using Animelist.Models.HtmlParsers.Interfaces;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Animelist.Models.HtmlParsers.Classes
{
    internal class HtmlLoader
    {
        readonly HttpClient client; // То что парсим
        readonly string url; // Ссылка

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Prefix}/";
        }
        /*
         * Собирает ссылку относительно страницы
         * 
         * Ну там когда страниц 1-987
         */
        public async Task<string> GetSourceByPageId(int id)
        {
            string currentUrl = url.Replace("{CurrentId}", id.ToString());
            HttpResponseMessage response = await client.GetAsync(currentUrl);
            string source = null;

            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
