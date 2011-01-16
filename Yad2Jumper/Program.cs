using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;


namespace Yad2Jumper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /**
            var cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;

            var request = (HttpWebRequest)WebRequest.Create("http://my.yad2.co.il/login.php");
            request.CookieContainer = cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.Write("Username=jenyasin@gmail.com&Password=whatever11");
            }

            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("windows-1255")))
            {
                var result = reader.ReadToEnd();
                MessageBox.Show(result);
            }
             */ 
        }
    }
}
