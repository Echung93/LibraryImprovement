using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class DB
{

    public DB(List<BookVO> list)
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=Library;Uid=root;Pwd=0000;");
        connection.Open();
        Console.WriteLine(list[0].BookName);
        Console.Write("bookIDNumber을 입력하세요(숫자만 4자리) : ");
        string input = Console.ReadLine();
        Console.Write("책의 수량을 입력하세요. : ");
        string input1 = Console.ReadLine();


        string bookInformationString = "VALUES(input, 'list[0].BookName', 'list[0].BookAuthor', 'list[0].bookPublishe', 'list[0].bookPrice', input1, 'list[0].bookISBN', 'list[0].bookPublicationDate', 'list[0].bookDescription')";
        //string userInformationString = "VALUES('echung93', '1234', '이충', '29', '01052655534','구좌', '',3)";
        MySqlCommand command = new MySqlCommand("INSERT INTO bookinformation (bookIDNumber,bookName,bookAuthor," +
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

}
