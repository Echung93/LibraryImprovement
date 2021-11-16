using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

class Class1
{
    static void Main(string[] args)
    {
        API api = new API();

        Console.Write("검색하실 책의 이름을 입력해주세요. : ");
        string input = Console.ReadLine();
        Console.Write("나타나실 책의 갯수를 입력해주세요. : ");
        string num = Console.ReadLine();
        api.searchBook(input, num);
        Console.ReadLine();
    }
}
