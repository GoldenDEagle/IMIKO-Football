using HtmlAgilityPack;
using System;
using System.Linq;
using System.Text;

namespace Assets.Codebase.Infrastructure.Services.Network
{
    public class NetworkService : INetworkService
    {
        private string _url = "https://aviabaffishpic.com/politic";
        private string _data;

        public string GetPolicy()
        {
            return _data;
        }

        public void UpdatePolicy()
        {
            var web = new HtmlWeb();
            var doc = web.Load(_url);
            var html = doc.Text;

            ParseData(html);
        }

        private void ParseData(string html)
        {
            _data = GetTextFromHtml(html);
        }



        private static string GetTextFromHtml(string html)
        {
            if (string.IsNullOrEmpty(html))
                return "";
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            return GetTextFromNodes(htmlDoc.DocumentNode.ChildNodes);
        }

        private static string GetTextFromNodes(HtmlNodeCollection nodes, int indent = 0)
        {
            StringBuilder texts = new StringBuilder();
            string[] linebreaks = { "p", "br", "table", "th", "tr" };
            string[] indentTag = { "ul", "li" };
            foreach (var node in nodes)
            {
                if (node.Name.ToLowerInvariant() == "title")
                    continue;
                if (node.Name.ToLowerInvariant() == "style")
                    continue;
                if (node.HasChildNodes)
                {
                    if (indentTag.Contains(node.Name.ToLowerInvariant()))
                        texts.Append(GetTextFromNodes(node.ChildNodes, indent + 1));
                    else
                        texts.Append(GetTextFromNodes(node.ChildNodes, indent));
                }
                else
                {
                    var innerText = node.InnerText;
                    if (!string.IsNullOrWhiteSpace(innerText))
                    {
                        texts.Append(new String(' ', indent) + node.InnerText);
                    }
                }

                if (node.Name.ToLowerInvariant() == "a")
                    texts.Append("\n" + node.Attributes["href"].Value + "\n");
            }

            return texts.ToString();
        }
    }
}
