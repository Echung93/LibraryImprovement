using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class DB
{

    public void DB1(List<BookVO> list)
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Library;Uid=root;Pwd=0000;");
        connection.Open();
        MySqlCommand command = new MySqlCommand("SELECT *FROM bookinformation WHERE bookIDNumber", connection);
        MySqlDataReader rdr = command.ExecuteReader();
        List<string> list1 = new List<string>();
        int count = 0 ;
         string a = rdr.ToString();
        Console.WriteLine(a);
        while (rdr.Read())
        {
            Console.WriteLine($"{rdr["bookIDNumber"]} {rdr["bookName"]} {rdr["bookAuthor"]} {rdr["bookPublisher"]} " +
                $"{rdr["bookPublicationDate"]} {rdr["bookQuantity"]} {rdr["bookISBN"]} {rdr["bookDescription"]}");
            list1.Add(rdr["bookIDNumber"].ToString());
        }

        foreach (var i in list1)
        {
            Console.WriteLine(i);
        }
        //  Console.Write("bookIDNumber을 입력하세요(숫자만 4자리) : ");
        //for (int i = 0; i < command.Tables[0].Rosw.Count; i++)
        //  {
        //      DataRow dr = ds.Tables[0].Rows[i];
        //      string[] tiems = dr.ItemTrray.Select(o)
        //  }
        string input = Console.ReadLine();
        while (true)
        { 
            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (rdr[i].ToString.BookIDNumber.Contains(input))
            //    {
            //        count++;
            //    }

            //}
            
            if (input.Length == 4 && count == 0)
        {
                break;
        }

        else 
        {
            Console.Write("잘못입력하였습니다. 숫자 4자리만 입력해주세요. : ");
            input = Console.ReadLine();
        }
        }

        Console.Write("책의 수량을 입력하세요. : ");
        string input1 = Console.ReadLine();


        string bookInformationString = $"VALUES('{input}', '{list[0].BookName}', '{list[0].BookAuthor}', '{list[0].BookPublisher}', '{list[0].BookPrice}', '{input1}', '{list[0].BookISBN}', '{list[0].BookPublicationDate}', '{list[0].BookDescription.Substring(0,20)}')";
        //string userInformationString = "VALUES('echung93', '1234', '이충', '29', '01052655534','구좌', '',3)";
        command = new MySqlCommand("INSERT INTO bookinformation (bookIDNumber,bookName,bookAuthor," +
            "bookPublisher,bookPrice,bookQuantity,bookISBN,bookPublicationDate,bookDescription)"
            + bookInformationString, connection);
        //MySqlCommand command = new MySqlCommand("INSERT INTO userinformation (userId,userPassword,userName," +
        //    "userAge,userPhoneNumber,userAddress,borrowedBookList,borrowedBookCount)"
        //    + userInformationString, connection);
        //MySqlCommand command = new MySqlCommand("SELECT *FROM bookinformation", connection);
        //MySqlCommand command = new MySqlCommand("DELETE FROM bookinformation WHERE bookIDNumber = " + Convert.ToInt32(wantedDeleteBookID), connection);
        //MySqlCommand command = new MySqlCommand("UPDATE bookinformation SET bookPrice = '" + modifitedPrice + "'" + " WHERE bookIDNumber = " + Convert.ToInt32(wantedModiftiedBookID), connection);

        command.ExecuteNonQuery();
        connection.Close();

    }

    public List<string> userList(List<UserVO> list)
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Library;Uid=root;Pwd=0000;");
        connection.Open();
        MySqlCommand command = new MySqlCommand("SELECT *FROM userinformation ", connection);
        MySqlDataReader rdr = command.ExecuteReader();
        List <string > userList = new List<string>();
        while (rdr.Read())
        {
            //Console.WriteLine($"{rdr["userId"]} {rdr["userPassword"]} {rdr["userName"]} {rdr["userPhoneNumber"]} " +
            //    $"{rdr["userAddress"]} {rdr["borrowedBookList"]} {rdr["borrowedBookCount"]}");
            userList.Add(rdr["userId"].ToString());
        }

        //foreach (var i in userList)
        //{
        //    Console.WriteLine(i);
        //}

        connection.Close();
        return userList;
    }

    public void userSave(string userID,string userPassword, string userName, string userAge, string userPhoneNumber,string userAddress)
    {

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Library;Uid=root;Pwd=0000;");
        connection.Open();
        string userInformationString = $"VALUES('{userID}', '{userPassword}', '{userName}', '{userAge}','010{userPhoneNumber}' ,'{userAddress}', '','')";
       //MySqlCommand command = new MySqlCommand("UPDATE userinformation, connection);
        //MySqlCommand command = new MySqlCommand("INSERT INTO userinformation (userID,userPassword,userName," +
        //    "userAge,userAddress,borrowedBookList,borrowedBookCount)"
        ////    + userInformationString, connection);
        //command.ExecuteNonQuery();
        connection.Close();
    }
}
