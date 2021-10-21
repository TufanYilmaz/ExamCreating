using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebCrowlerHelper
{
    public class WebCrowlerClient
    {
        public static WebCrowlerClient instance { get; private set; } = new WebCrowlerClient();
        WebCrowlerClient()
        {

        }
        public async Task<string> FullWebPageContent(string URL)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(URL);
            return result;
        }
        private static HtmlDocument GetHtmlDocument(string htmlContent)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);
            return htmlDocument;
        }
        public IEnumerable<HtmlNode> GetDivsByCssClasses(string htmlContent, string classNames)//post-listing-component__wrapper
        {
            HtmlDocument htmlDocument = GetHtmlDocument(htmlContent);
            var divs = htmlDocument.DocumentNode
                .Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals(classNames));
            return divs;
        }

       

        public HtmlNode GetDivsContains(IEnumerable<HtmlNode> divs, string classNames) //title-bar-component title-bar-component--undefined
        {
            return divs?.FirstOrDefault(n => n.SelectSingleNode($"div[@class='{classNames}']") != null) ?? null;
        }
        //post-listing-list-item__link
        //post-listing-list-item__title
        public Dictionary<string, string> GetUrlsFromHtmlNode(HtmlNode htmlNode, string urlLinkCssClass, string baseUrl = "")
        {
            var links = htmlNode
                .Descendants("a")
                .Where(n => (!string.IsNullOrEmpty(urlLinkCssClass) && n.Attributes["class"].Value == urlLinkCssClass))
                .Select(n => new KeyValuePair<string, string>( n.Descendants("h5").FirstOrDefault().InnerText, baseUrl + n.Attributes["href"].Value))
                .ToDictionary(k => k.Key, v => v.Value);
            return links;
        }
        
        public string GetWiredStroyContentFromUrl(string URL)
        {
            var divPContent = GetHtmlDocument(FullWebPageContent(URL).Result).DocumentNode.SelectNodes("//div[@class='body__inner-container']/p")
                .Select(t=>t.InnerText);
            
            return string.Join("\r\n",divPContent);
        }

        #region ClientSpecific
        public Dictionary<string, string> GetWiredLastFiveMostRecent()
        {
            var pagecontent = FullWebPageContent("https://www.wired.com");
            var divs = GetDivsByCssClasses(pagecontent.Result, "post-listing-component__wrapper");
            var mostRecentsDiv = GetDivsContains(divs, "title-bar-component title-bar-component--undefined");
            var getUrlsFromHtmlNode = GetUrlsFromHtmlNode(mostRecentsDiv, "post-listing-list-item__link", "https://www.wired.com");
            return getUrlsFromHtmlNode;
        }
        #endregion
    }
}
