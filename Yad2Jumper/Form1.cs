using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;


namespace Yad2Jumper
{
    public partial class Form1 : Form
    {
        /* private members */
        private CookieContainer m_cookies;
        private const string m_method = "POST";
        private const string m_contentType = "application/x-www-form-urlencoded";
        private const string m_userAgentString = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
        private string[] m_staticPages = {
            //Houses
            "http://my.yad2.co.il/MyYad2/MyOrder/sales.php",
            "http://my.yad2.co.il/MyYad2/MyOrder/rent.php",
            //Cars
            "http://my.yad2.co.il/MyYad2/MyOrder/Car.php",
            "http://my.yad2.co.il/MyYad2/MyOrder/4X4.php",
            //Last
            "http://my.yad2.co.il"
        };

        private enum StaticPageEnum {
            ENUM_RENT = 0,
            ENUM_CAR
        };


        /* methods */
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }




        private void buttonConnect_Click(object sender, EventArgs e)
        {
            m_cookies = new CookieContainer();
            ServicePointManager.Expect100Continue = false;

            //This is the first time we generate a request
            var request = Yad2Utils.createHttpRequest("http://my.yad2.co.il/login.php");
  

            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                //writer.Write("Username=jenyasin@gmail.com&Password=whatever11");
                writer.Write("Username=" + textBoxUserName.Text + "&Password=" + textBoxPassword.Text);
            }

            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("windows-1255")))
            {
                var result = reader.ReadToEnd();
             //   TextWriter tw = new StreamWriter("../../data/yad2.txt");
               // tw.Write(result);
               // tw.Close();
               // MessageBox.Show("finished yad2.txt");
                //textBoxOut.Text = result;
            }

            for (int i = 0; i < m_staticPages.Count(); i++)
            {
                 HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();    

                /*
                request = (HttpWebRequest)WebRequest.Create(m_staticPages[i]);
                request.CookieContainer = m_cookies;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                    
                 */
                 request = Yad2Utils.createHttpRequest(m_staticPages[i]);
                var resultStream = request.GetResponse().GetResponseStream();
                var reader = new StreamReader(resultStream, System.Text.Encoding.GetEncoding("windows-1255"));
                
                //FIXME: need to adjust to every specific static page, this is for rent.php only
                doc.Load(resultStream); // The HtmlAgilityPack

                // doc.Load("../../data/doc.txt"); // The HtmlAgilityPack
                 doc.Save("../../data/doc.txt");

                 switch ((StaticPageEnum)i)
                 {
                     case StaticPageEnum.ENUM_RENT:
                         handleRentDoc(doc);
                         break;
                     case StaticPageEnum.ENUM_CAR:
                         handleCarDoc(doc);
                         break;
                     default:
                         MessageBox.Show("Unkown static page %d"); 
                         break;
                 }
                    //textBoxOut.Text = result;
            }
        }

        /***************/
        private void handleRentDoc(HtmlAgilityPack.HtmlDocument doc)
        {
            var trs = doc.DocumentNode.SelectNodes("//tr[@id='ActiveLink']");
            for (int idx = 0; idx < trs.Count; idx++)
            {
                var td_type = trs[idx].SelectSingleNode("td[1]");
                var td_addr = trs[idx].SelectSingleNode("td[5]");

                string id = td_type.Id.Substring(4); //Something like: Txt_<id_num>
                postsListBox.Items.Add(id + ": " + td_type.InnerText.Trim() +", " + td_addr.InnerText.Trim());

                //jump
                //string uri = "http://my.yad2.co.il/MyYad2/MyOrder/rentDetails.php?NadlanID=" + id + "&OrderTypeID=1&Up=u";
                string uri = "http://my.yad2.co.il/MyYad2/MyOrder/rentDetails.php?NadlanID=" + id;
                postsListBox.SetItemChecked(idx,doJump(uri));

            }
        }

        private void handleCarDoc(HtmlAgilityPack.HtmlDocument doc)
        {
            var trs = doc.DocumentNode.SelectNodes("//tr[@id='ActiveLink']");
            for (int idx = 0; idx < trs.Count; idx++)
            {
                var td_type = trs[idx].SelectSingleNode("td[1]");
                var td_year = trs[idx].SelectSingleNode("td[5]");

                string id = td_type.Id.Substring(4); //Something like: Txt_<id_num>
                postsListBox.Items.Add(id + ": " + td_type.InnerText.Trim() + ", " + td_year.InnerText.Trim());
                
                //jump
                //string uri = "http://my.yad2.co.il/MyYad2/MyOrder/CarDetails.php?CarID=" + id + "&OrderTypeID=1&Up=u";
                string uri = "http://my.yad2.co.il/MyYad2/MyOrder/CarDetails.php?CarID=" + id;
                postsListBox.SetItemChecked(idx, doJump(uri));
            }
        }

        private bool doJump(string uri)
        {
            var request = Yad2Utils.createHttpRequest(uri + "&OrderTypeID=1&Up=u", uri);

            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("windows-1255")))
            {
                var result = reader.ReadToEnd();
                if (result.Contains("מעדכן נתונים")) return true;
                else return false;
            }
        }
        /***************/
        private void buttonJump_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://my.yad2.co.il/MyYad2/MyOrder/OzeretDetails1.php?OzeretID=26584&Up=u");
            request.CookieContainer = m_cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            /*
            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.Write("?OzeretID=26584&Up=u");
                //writer.Write("Username=" + textBoxUserName.Text + "&Password=" + textBoxPassword.Text);
            }
             */
            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("windows-1255")))
            {
                var result = reader.ReadToEnd();
                TextWriter tw = new StreamWriter("../../data/jump.txt");
                tw.Write(result);
                tw.Close();
                MessageBox.Show("finished jump.txt");
                //textBoxOut.Text = result;
            }
            //<a onclick="location.href='/MyYad2/MyOrder/OzeretDetails1.php?OzeretID=26584&amp;Up=u'" style="cursor: hand"><img src="http://images.yad2.co.il/Pic/site_images/yad2/MyYad2/images/AkpazatModaa.gif" width="115" height="24" border="0" alt=""></a>
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://my.yad2.co.il/MyYad2/MyOrder/Ozeret1.php");
            request.CookieContainer = m_cookies;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            using (var responseStream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("windows-1255")))
            {
                var result = reader.ReadToEnd();
                TextWriter tw = new StreamWriter("../../data/Ozeret.txt");
                tw.Write(result);
                tw.Close();
                MessageBox.Show("finished Ozeret.txt");
                //textBoxOut.Text = result;
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                postsListBox.Items.Add("post number " + i);


            }
        }

        private void doJump()
        {

        }
    }
}
