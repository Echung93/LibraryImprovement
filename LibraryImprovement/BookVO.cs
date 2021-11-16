using System;
public class BookVO
{
    private string bookIDNumber;
    private string bookName;
    private string bookAuthor;
    private string bookPrice;
    private string bookPublisher;
    private string bookPublicationDate;
    private int bookQuantity;
    private string bookISBN;
    private string bookDescription;


    //public BookVO()
    //{

    //}

    public BookVO(string bookIDNumber, string bookName, string bookPublisher, string bookAuthor, string bookPrice, /*int bookQuantity,*/
        string bookPublicationDate, string bookISBN, string bookDescription)
    {
        this.bookIDNumber = bookIDNumber;
        this.bookName = bookName;
        this.bookPublisher = bookPublisher;
        this.bookAuthor = bookAuthor;
        this.bookPrice = bookPrice;
        //this.bookQuantity = bookQuantity;
        this.bookPublicationDate = bookPublicationDate;
        this.bookISBN = bookISBN;
        this.bookDescription = bookDescription;

    }

    public string BookIDNumber
    {
        get { return bookIDNumber; }
        set { bookIDNumber = value; }
    }

    public string BookName
    {
        get { return bookName; }
        set { bookName = value; }
    }

    public string BookPublisher
    {
        get { return bookPublisher; }
        set { bookPublisher = value; }
    }
    public string BookAuthor
    {
        get { return bookAuthor; }
        set { bookAuthor = value; }
    }

    public string BookPrice
    {
        get { return bookPrice; }
        set { bookPrice = value; }
    }


    public int BookQuantity
    {
        get { return bookQuantity; }
        set { bookQuantity = value; }
    }

    public string BookPublicationDate
    {
        get { return bookPublicationDate; }
        set { bookPublicationDate = value; }
    }

    public string BookISBN
    {
        get { return bookISBN; ; }
        set { bookISBN = value; }
    }

    public string BookDescription
    {
        get { return bookDescription; }
        set { bookDescription = value; }
    }

}

