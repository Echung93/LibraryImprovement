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
            //List<BookVO> list = new List<BookVO>();
            //new DB(list);
        API api = new API();
        Console.Write("검색하실 책의 이름을 입력해주세요. : ");
        string input = Console.ReadLine();
        Console.Write("나타나실 책의 갯수를 입력해주세요. : ");
        string num = Console.ReadLine();
        api.searchBook(input, num);
            Console.ReadLine();
        }
    }
}
