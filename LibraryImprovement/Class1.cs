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
    const string NAVER_DISPLAY_STRING = "&display=";
    const string NAVER_ID = "4djOgPTvaUjxuEqSudHM";
    const string NAVER_SECRET = "bDuwCmqIPr";
    public const string NAVER_URL = "https://openapi.naver.com/v1/search/book_adv.xml?d_titl=";

    static void Main(string[] args)
    {
        new initialStart();
    }
}
