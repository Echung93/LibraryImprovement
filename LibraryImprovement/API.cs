using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
class API
{
    const string NAVER_DISPLAY_STRING = "&display=";
    const string NAVER_ID = "4djOgPTvaUjxuEqSudHM";
    const string NAVER_SECRET = "bDuwCmqIPr";
    public const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml?d_titl=";

    public void searchBook(string input, string s)
    {
        string a = "1";
        int count = 0;
        int check = 0;
        while (true)
        {
            Console.Clear();
            WebRequest request;
            WebResponse response;
            Stream stream;
            XmlNode firstNode;
            XmlNode secondNode;
            XmlDocument xmlDocument = new XmlDocument();
            XmlNodeList xmlNodeList;
            List<BookVO> list = new List<BookVO>();


            string url = NAVER_URL + input + NAVER_DISPLAY_STRING + s + "&start=" + a;
            request = (HttpWebRequest)WebRequest.Create(url);

            request.Headers.Add("X-Naver-Client-Id", NAVER_ID);
            request.Headers.Add("X-Naver-Client-Secret", NAVER_SECRET);           //api 접근

            response = request.GetResponse();
            stream = response.GetResponseStream();
            xmlDocument.Load(stream);

            firstNode = xmlDocument.SelectSingleNode("rss");
            secondNode = firstNode.SelectSingleNode("channel");

            xmlNodeList = secondNode.SelectNodes("item");

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
                //Console.WriteLine(xmlNode.SelectSingleNode("title").InnerText);  //책 출력.
            }
            foreach (BookVO bv in list)
            {
                Console.WriteLine("\r\n");
                Console.WriteLine(bv.BookName);
                Console.WriteLine(bv.BookAuthor);
                Console.WriteLine(bv.BookPrice);
                Console.WriteLine(bv.BookPublisher);
                Console.WriteLine(bv.BookPublicationDate);
                Console.WriteLine(bv.BookQuantity);
                Console.WriteLine(bv.BookISBN);
                Console.WriteLine(bv.BookDescription);
                Console.WriteLine("\r\n");

            }

            //new DB(list);
            if (check == 1)
            {
                Console.WriteLine("처음 페이지 입니다.");
                check = 0;
            }

            else if (check == 2)
            {
                Console.WriteLine("마지막 페이지 입니다.");
                check = 0;
            }

            else
            {
                Console.WriteLine($"{count + 1}번 페이지 입니다.");
            }

            ConsoleKeyInfo key;
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.RightArrow)      //esc 누를 경우 null 반환
            {
                if (list.Count < int.Parse(s))
                {
                    check = 2;
                }

                else
                {
                    count++;
                    a = "1";
                    int b = int.Parse(a) + int.Parse(s) * (count);
                    a = b.ToString();
                }
            }

            else if (key.Key == ConsoleKey.LeftArrow)
            {
                if (count == 0)
                {
                    check = 1;
                }

                else 
                { 
                count--;
                a = "1";
                int b = int.Parse(a) + int.Parse(s) * (count);
                a = b.ToString();
                }
            }


            //int num = int.Parse(Console.ReadLine());
            //if (num == 1)
            //{
            //    a = "1";
            //}

                //else
                //{
                //    a = "1";
                //    int b = int.Parse(a) + int.Parse(s) * (num - 1);
                //    a = b.ToString();
                //}
        }
    }
}
