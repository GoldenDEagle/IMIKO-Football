using System.Xml.Linq;
using System;
using UnityEngine;
using UnityEngine.Networking;
using HtmlAgilityPack;

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
            _data = doc.ParsedText;
            Debug.Log(_data);
        }

        private void ParseData(string data)
        {

        }


    }
}
