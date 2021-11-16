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
        MySqlCommand command = new MySqlCommand("SELECT *FROM bookinformation WHERE bookIDNumber", connection);

        MySqlDataReader rdr = command.ExecuteReader();
        int count = 0 ;
        //while(rdr.Read())
        //  { 
        //      Console.WriteLine($"{rdr["bookIDNumber"]} {rdr["bookName"]} {rdr["bookAuthor"]} {rdr["bookPublisher"]} " +
        //          $"{rdr["bookPublicationDate"]} {rdr["bookQuantity"]} {rdr["bookISBN"]} {rdr["bookDescription"]}");
        //string asd = rdr["bookPublicationDate"].ToString;
      //  }
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

}
