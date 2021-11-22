using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LogHistoryVO
{
    private string userName;
    private string bookName;
    private string time;
    private string action;

    public LogHistoryVO()
    {
    }

    public LogHistoryVO(string userName, string bookName)
    {
        this.userName = userName;
        this.bookName = bookName;
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    public string BookName
    {
        get { return bookName; }
        set { bookName = value; }
    }

    public string Time
    {
        get { return time; }
        set { time = value; }           
    }
    public string Action
    {
        get { return action; }
        set { action = value; }
    }

}
