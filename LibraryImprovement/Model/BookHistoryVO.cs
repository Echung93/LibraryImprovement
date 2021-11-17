using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BookHistoryVO
{
    private string userName;
    private string bookName;
    private string borrowTime;
    private string returnTime;

    public BookHistoryVO()
    {
    }

    public BookHistoryVO(string userName, string bookName)
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
    public string BorrowTime
    {
        get { return borrowTime; }
        set { borrowTime = value; }

    }
    public string ReturnTime
    {
        get { return returnTime; }
        set { returnTime = value; }
    }
}
