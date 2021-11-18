using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class UserVO
{
    private string userId;
    private string userPassword;
    private string userName;
    private string userAge;
    private string userPhoneNumber;
    private string userAddress;
    private string borrowedBookList;
    private string borrowedBookCount;

    public UserVO()
    {

    }
    public UserVO(string userId, string userPassword, string userName, string userAge, string userPhoneNumber, string userAddress)
    {
        this.userId = userId;
        this.userPassword = userPassword;
        this.userName = userName;
        this.userAge = userAge;
        this.userPhoneNumber = userPhoneNumber;
        this.userAddress = userAddress;

    }
    public UserVO(string userId, string userPassword, string userName, string userAge, string userPhoneNumber, string userAddress, string borrowedBookList, string borrowedBookCount)
    {
        this.userId = userId;
        this.userPassword = userPassword;
        this.userName = userName;
        this.userAge = userAge;
        this.userPhoneNumber = userPhoneNumber;
        this.userAddress = userAddress;
        this.borrowedBookList = borrowedBookList;
        this.borrowedBookCount = borrowedBookCount;

    }
    public string UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public string UserPassword
    {
        get { return userPassword; }
        set { userPassword = value; }
    }

    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string UserAge
    {
        get { return userAge; }
        set { userAge = value; }
    }

    public string UserPhoneNumber
    {
        get { return userPhoneNumber; }
        set { userPhoneNumber = value; }
    }

    public string UserAddress
    {
        get { return userAddress; }
        set { userAddress = value; }
    }

    public string BorrowedBookList
    {
        get { return borrowedBookList; }
        set { borrowedBookList = value; }
    }

    public string BorrowedBookCount
    {
        get { return borrowedBookCount; }
        set { borrowedBookCount = value; }
    }
}
