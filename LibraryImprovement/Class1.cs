using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace apiTest
{
    class Class1
    {
        const string NAVER_DISPLAY_STRING = "&display=";
        const string NAVER_ID = "4djOgPTvaUjxuEqSudHM";
        const string NAVER_SECRET = "bDuwCmqIPr";
        public const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml?d_titl=";

        static void Main(string[] args)
        {
            WebRequest request;
            WebResponse response;
            Stream stream;
            XmlNode firstNode;
            XmlNode secondNode;
            XmlDocument xmlDocument = new XmlDocument();
            XmlNodeList xmlNodeList;
            List<BookVO> list = new List<BookVO>();
            string input = Console.ReadLine();

            string url = NAVER_URL + input + NAVER_DISPLAY_STRING + '1' + "&start=1";
            request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
            request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

            response = request.GetResponse();
            stream = response.GetResponseStream();
            xmlDocument.Load(stream);

            firstNode = xmlDocument.SelectSingleNode("rss");
            secondNode = firstNode.SelectSingleNode("channel");

            xmlNodeList = secondNode.SelectNodes("item");
            int a = 10;

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                list.Add(new BookVO(xmlNode.SelectSingleNode("title").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("title").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("publisher").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("author").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("price").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("pubdate").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("isbn").InnerText.Replace("<b>", "").Replace("</b>", "")
                   , xmlNode.SelectSingleNode("description").InnerText.Replace("<b>", "").Replace("</b>", "")
                   ));
                Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);  //책 출력.
            }
            foreach (BookVO bv in list)
            {
                Console.WriteLine(bv.BookIDNumber);
                Console.WriteLine(bv.BookName);
                Console.WriteLine(bv.BookAuthor);
                Console.WriteLine(bv.BookPrice);
                Console.WriteLine(bv.BookPublisher);
                Console.WriteLine(bv.BookPublicationDate);
                Console.WriteLine(bv.BookQuantity);
                Console.WriteLine(bv.BookISBN);
                Console.WriteLine(bv.BookDescription);

            }

            new DB(list);
            Console.ReadLine();
        }
    }
}
