using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace Yad2Jumper
{
    class Yad2Utils
    {
        static private CookieContainer m_cookies { get; set; }
        private const string m_method = "POST";
        private const string m_contentType = "application/x-www-form-urlencoded";
        private const string m_userAgentString = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
       
        static public HttpWebRequest createHttpRequest(string uri, string referer = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = m_cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
            request.Referer = referer;
            return request;
        }
    }
}
