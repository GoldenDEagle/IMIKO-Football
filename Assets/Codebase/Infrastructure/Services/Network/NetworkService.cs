using System.Xml.Linq;
using System;
using UnityEngine;
using UnityEngine.Networking;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Assets.Codebase.Infrastructure.Services.Network
{
    public class NetworkService : INetworkService
    {
        private string _url = "https://aviabaffishpic.com/politic";
        private string _data;

        private UnityWebRequest _request;

        public string GetPolicy()
        {
            return _data;
        }

        //public void UpdatePolicy()
        //{
        //    if (_request != null) return;

        //    _request = UnityWebRequest.Get(_url);
        //    _request.SendWebRequest().completed += OnDataLoaded;
        //}

        //private void OnDataLoaded(AsyncOperation operation)
        //{
        //    if (operation.isDone)
        //    {
        //        _data = _request.downloadHandler.text;
        //        Debug.Log(_data);
        //        //ParseData(_data);
        //    }
        //}

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
            Debug.Log(_data);
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
                //if (linebreaks.Contains(node.Name.ToLowerInvariant()))
                //    texts.Append("\n");
            }

            return texts.ToString();
        }
    }
}
