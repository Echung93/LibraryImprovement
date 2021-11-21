using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Function
{
    DB db = new DB();
    public Function()
    {

    }
    public bool loginManager(string input)
    {
        while (true)
        {
            if (input == "1234")
            {
                return false;
            }
            else
            {
                Console.Write("\r\n         관리자 비밀 번호를 다시 입력 하시오 : ");
                input = MenuControl.Get().ReadPassword();
            }
        }
    }

    public List<UserVO> loginUser(List<UserVO> userList)
    {
        Console.Clear();
        bool check = true;
        bool check1 = true;
        userList = db.userList1(userList);
        List<UserVO> loginUser = new List<UserVO>();
        ui.Get().printScreenEtc();
        string id;
        Console.Write("        회원 ID를 입력하세요(English and Number) : ");
        while (check)
        {
            int count = 0;
            id = MenuControl.Get().ReadString();

            if (id == "\0")
            {
                goto Exit;
            }

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].UserId == (id))
                {
                    Console.Write("\r\n        회원 비밀 번호를 입력하세요(English and Number) : ");
                    while (check1)
                    {
                        string pw = MenuControl.Get().ReadPassword();

                        if (pw == "\0")
                        {
                            goto Exit;
                        }

                        if (userList[i].UserPassword == (pw))
                        {
                            Console.Write("        로그인 성공");
                            loginUser.Add(userList[i]);
                            check = false;
                            check1 = false;

                        }

                        else
                        {
                            Console.Clear();
                            ui.Get().printScreenEtc();
                            Console.Write("        부정확한 비밀번호 입니다. 다시 입력하세요(English and Number) : ");
                            check = false;
                        }
                    }
                }

                else
                {
                    count++;
                }
            }

            if (count == userList.Count)
            {
                Console.Clear();
                ui.Get().printScreenEtc();
                Console.Write("        존재하지 않는 ID입니다. 다시 입력하세요(English and Number) : ");
            }

        }
    Exit:
        return loginUser;

    }
    public void register(List<UserVO> List)
    {
        bool check = true;
        Console.Clear();
        //List<BookVO> books = new List<BookVO>();
        //db.DB1(books);
        List<string> userList = db.userList(List);
        Console.Write("\r\n        회원 ID를 입력하세요(English and Number) : ");
        string UserId = MenuControl.Get().ReadEnglish();

        while (check)
        {
            int count = 0;

            if (UserId == "\0")
            {
                goto Exit;
            }

            else
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList.Contains(UserId.Replace(" ", "")))
                    {
                        Console.Write("\r\n        이미 존재하는 ID입니다. 회원 ID를 다시 입력하세요(English and Number) : ");
                        UserId = MenuControl.Get().ReadEnglish();
                        count++;
                        break;
                    }
                }

                if (count == 0)
                {
                    check = false;
                }
            }
        }

        Console.Write("\r\n        회원 비밀 번호를 입력하세요(English and Number) : ");
        string UserPassword = MenuControl.Get().ReadPassword();
        if (UserPassword == "\0")
        {
            goto Exit;
        }


        Console.Write("\r\n        회원 이름 입력(공백없이 2~5 글자의 한글) : ");
        string UserName = MenuControl.Get().ReadKorea();
        bool check2 = true;

        while (check2)
        {
            if (UserName == "\0")
            {
                goto Exit;
            }

            else if (UserName.Replace(" ", "").Length < 2 || UserName.Replace(" ", "").Length > 5)
            {
                Console.Write("\r\n        공백없이 2~5 글자의 한글을 입력해주세요. : ");
                UserName = MenuControl.Get().ReadKorea();
            }

            else
            {
                check2 = false;
            }

        }

        Console.Write($"\r\n        {UserName.Replace(" ", "")} 님의 나이 입력(1~100 사이 숫자만 입력) : ");
        bool check3 = true;
        string UserAge = MenuControl.Get().ReadNumber();
        while (check3)
        {
            if (UserAge == "\0")
            {
                goto Exit;
            }


            else if (int.Parse(UserAge) == 0 || int.Parse(UserAge) > 100 || UserAge == "\0")
            {
                Console.Write($"\r\n        1~100사이의 숫자만 입력해주세요.");
                UserAge = MenuControl.Get().ReadNumber();
            }

            else
            {
                check3 = false;
            }

        }

        Console.Write($"\r\n        {UserName.Replace(" ", "")} 님의 핸드폰 번호 입력('-' 제외하고 입력) : 010");
        string UserPhoneNumber = MenuControl.Get().ReadNumber();
        bool check4 = true;
        while (check4)
        {
            if (UserPhoneNumber == "\0")
            {
                goto Exit;
            }

            else if (UserPhoneNumber.Length == 8)
            {
                check4 = false;

            }

            else
            {
                Console.Write($"\r\n        8자리 숫자만 입력해주세요. : ");
                UserPhoneNumber = MenuControl.Get().ReadNumber();
            }

        }
        Console.Write($"\r\n        {UserName.Replace(" ", "")} 님의 회원 주소 입력 : ");
        string UserAddress = MenuControl.Get().ReadString();
        if (UserAddress == "\0")
        {
            goto Exit;
        }

        db.userSave(UserId, UserPassword, UserName, UserAge, UserPhoneNumber, UserAddress);
        Console.WriteLine($"\r\n        회원 가입 완료 ");
        Console.WriteLine($"\r\n        뒤로가려면 아무키나 누르세요. ");
        MenuControl.Get().ReadESC();

    Exit:
        check = false;

    }

    public void userDelete(List<UserVO> List)
    {
        bool check = true;
        Console.Clear();
        //List<BookVO> books = new List<BookVO>();
        //db.DB1(books);
        List<string> userList = db.userList(List);
        Console.Write("\r\n        회원 ID를 입력하세요(English and Number) : ");
        string userId = MenuControl.Get().ReadEnglish();

        while (check)
        {
            if (userList.Contains(userId))
            {
                db.userDelete(userId);
                Console.WriteLine("\r\n        회원 삭제 완료! ");
                check = false;

            }

            else
            {
                Console.Write("\r\n        존재하지 않는 회원입니다. 회원 ID를 정확히 입력하세요(English and Number) : ");
                userId = MenuControl.Get().ReadEnglish();
            }
        }

        Console.WriteLine($"\r\n        뒤로가려면 아무키나 누르세요. ");
        MenuControl.Get().ReadESC();
    }

    public void bookDelete(List<BookVO> List)
    {
        bool check = true;
        Console.Clear();
        //List<BookVO> books = new List<BookVO>();
        //db.DB1(books);
        List = db.bookList(List);
        Console.Write("\r\n        책IDNumber를 입력하세요(Number) : ");
        string bookIDNumber = MenuControl.Get().ReadString();
        if (bookIDNumber == "\0")
        {
            goto Exit;
        }
        while (check)
        {
            int count = 1;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].BookIDNumber == bookIDNumber)
                {
                    db.bookDelete(bookIDNumber);
                    Console.Write($"\r\n        책 이름 : {List[i].BookName}을 삭제하였습니다. "); 
                    check = false;
                    break;
                }

                else if (count == List.Count)
                {
                    Console.Write("\r\n        존재하지 않는 책IDNumber입니다. 책IDNumber를 정확히 입력하세요(Number) : ");
                    bookIDNumber = MenuControl.Get().ReadString();
                    if (bookIDNumber == "\0")
                    {
                        goto Exit;
                    }
                    count = 1;
                }
                count++;
            }
        }
        Console.WriteLine("\r\n        삭제 완료");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    Exit:
        ;

    }

    public void modifyBookInformation(List<BookVO> List)
    {
        bool check = true;
        Console.Clear();
        //List<BookVO> books = new List<BookVO>();
        //db.DB1(books);
        List = db.bookList(List);
        Console.Write("\r\n        변경하고자 하는 책IDNumber를 입력하세요(Number) : ");
        string bookIDNumber = MenuControl.Get().ReadNumber();
        while (check)
        {
            int count = 1;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].BookIDNumber == bookIDNumber)
                {
                    Console.Write("\r\n        변경하고자 하는 책의 수량을 입력하세요(Number) : ");
                    string bookQuantity = MenuControl.Get().ReadNumber();
                    db.bookUpdate(bookIDNumber,bookQuantity);
                    Console.Write($"\r\n        책 이름 : {List[i].BookName}을 수정하였습니다. ");
                    check = false;
                    break;
                }

                else if (count == List.Count)
                {
                    Console.Write("\r\n        존재하지 않는 책IDNumber입니다. 책IDNumber를 정확히 입력하세요(Number) : ");
                    bookIDNumber = MenuControl.Get().ReadString();
                    count = 1;
                }
                count++;
            }
        }
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();

    }

    public void modifyUserInformation(List<UserVO> currentUser)
    {
        Console.Write("        전화번호를 수정하려면 1번,주소를 수정하려면 2번 입력해주세요. : ");
        string input = MenuControl.Get().ReadNumber();
        if (input == "1")
        {
            Console.Write("\r\n        수정하려는 전화번호를 입력('-' 제외하고 입력) : ");
            string phoneNumber = MenuControl.Get().ReadNumber();
            db.userUpdate(currentUser[0].UserId, phoneNumber, null);
        }

        else if (input == "2")
        {
            Console.Write("\r\n        수정하려는 주소를 입력 : ");
            string address = MenuControl.Get().ReadString();
            db.userUpdate(currentUser[0].UserId, null, address);
        }

        else if (input == "\0")
        {
            goto Exit;
        }

        Console.WriteLine($"\r\n        수정을 완료하였습니다. ");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    Exit:
        ;

    }

    public void printBookList(List<BookVO> List)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.WriteLine("                             책 List ");
        foreach (BookVO bv in List)
        {
            Console.WriteLine(" ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine(" 책  ID 넘버 : " + bv.BookIDNumber);
            Console.WriteLine(" 책  이름 : " + bv.BookName);
            Console.WriteLine(" 책  저자 : " + bv.BookAuthor);
            Console.WriteLine(" 책  출판사 : " + bv.BookPublisher);
            Console.WriteLine(" 책  가격 : " + bv.BookPrice);
            Console.WriteLine(" 책  수량 : " + bv.BookQuantity);
            Console.WriteLine(" 책  출간일 : " + bv.BookPublicationDate);
            Console.WriteLine(" 책  ISBN : " + bv.BookISBN);
            Console.WriteLine(" 책  설명 : " + bv.BookDescription);
            Console.WriteLine("\r\n");
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine($"              등록된 총 책의 종류는 {List.Count}종류 입니다.    ");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    }

    public void printUserList(List<UserVO> List)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.WriteLine("                           회원 List ");
        foreach (UserVO uv in List)
        {
            Console.WriteLine(" ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine($" 회원 아이디 : " + uv.UserId);
            Console.WriteLine($" 회원 이름 : " + uv.UserName);
            Console.WriteLine($" {uv.UserName}님의 나이 : " + uv.UserAge);
            Console.WriteLine($" {uv.UserName}님의 핸드폰 번호 : " + uv.UserPhoneNumber);
            Console.WriteLine($" {uv.UserName}님의 주소 : " + uv.UserAddress);
            Console.WriteLine($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            Console.WriteLine($" {uv.UserName}님의 빌린 책 갯수 : " + uv.BorrowedBookCount);
            Console.WriteLine("\r\n");
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine($"              등록된 총 회원 수는 {List.Count}명 입니다.    ");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    }
    public void printUser(List<UserVO> user)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.WriteLine("                           회원 정보 ");
        foreach (UserVO uv in user)
        {
            Console.WriteLine(" ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine($" 회원 아이디 : " + uv.UserId);
            Console.WriteLine($" 회원 이름 : " + uv.UserName);
            Console.WriteLine($" {uv.UserName}님의 나이 : " + uv.UserAge);
            Console.WriteLine($" {uv.UserName}님의 핸드폰 번호 : " + uv.UserPhoneNumber);
            Console.WriteLine($" {uv.UserName}님의 주소 : " + uv.UserAddress);
            Console.WriteLine($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            Console.WriteLine($" {uv.UserName}님의 빌린 책 갯수 : " + uv.BorrowedBookCount);
            Console.WriteLine("\r\n");
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
    }

    public void addBook(List<BookVO> List)
    {
        bool check = true;
        List = db.bookList(List);
        while (check)
        {
            Console.Clear();
            ui.Get().printScreenEtc();
            Console.Write("\r\n        책 ID 숫자 입력(입력예시 : 1234) : ");
            string BookIDNumber = MenuControl.Get().ReadNumber();
            bool check1 = true;

            while (check1)
            {
                int count = 0;
                for (int i = 0; i < List.Count; i++)
                {
                    if (List[i].BookIDNumber == BookIDNumber)
                    {
                        count++;
                        Console.Write("\r\n        있는 책 ID입니다. 다시 책 ID 숫자를 입력(입력예시 : 1234) : ");
                        BookIDNumber = MenuControl.Get().ReadNumber();

                    }
                }

                if (BookIDNumber == "\0")
                {
                    goto Exit;
                }

                else if (List.Count == 0)
                {
                    check1 = false;
                }

                else if (BookIDNumber.Length != 4)
                {
                    Console.Write("\r\n        4자리의 책 ID 숫자를 다시 입력해주세요 (입력예시 : 1234) : ");
                    BookIDNumber = MenuControl.Get().ReadNumber();
                }

                else if (count == 0)
                {
                    check1 = false;
                }
            }

            Console.Write("\r\n        책 이름 입력 : ");
        check2:
            string BookName = MenuControl.Get().ReadString();
            for (int j = 0; j < List.Count; j++)
            {
                if (BookName == "\0")
                {
                    goto Exit;
                }

                else if (List[j].BookName == BookName)
                {
                    Console.Write("\r\n        있는 책입니다. 다시 책 이름을 입력 : ");
                    goto check2;
                }
            }

            Console.Write("\r\n        책 저자 입력 : ");
            string BookAuthor = MenuControl.Get().ReadLanguage();
            if (BookAuthor == "\0")
            {
                goto Exit;
            }

            Console.Write("\r\n        책 출판사 입력 : ");
            string BookPublisher = MenuControl.Get().ReadLanguage();
            if (BookPublisher == "\0")
            {
                goto Exit;
            }

            Console.Write("\r\n        책 가격 입력 : ");
            string BookPrice = MenuControl.Get().ReadNumber();
            if (BookPrice == "\0")
            {
                goto Exit;
            }

        
            Console.Write("\r\n        책 수량 입력(1 ~ 100) : ");
        check3:
            string BookQuantity = MenuControl.Get().ReadNumber();
            int quantity = int.Parse(BookQuantity);
            if (BookName == "\0")
            {
                goto Exit;
            }

            else if (1 > quantity || quantity > 100)
            {
                Console.Write("\r\n        책 수량을 1 ~ 100까지만 입력해주세요. : ");
                goto check3;
            }

            Console.Write("\r\n        책 설명 입력 :  ");
            string description = MenuControl.Get().ReadLanguage();
            if (description == "\0")
            {
                goto Exit;

            }
            db.bookSave(BookIDNumber, BookName, BookAuthor, BookPublisher, BookPrice, BookQuantity, "", "", description);
            Console.WriteLine($"\r\n        {BookName} 책 등록 완료!");
            Console.WriteLine("\r\n        뒤로가기를 원하시면 ESC를 눌러주세요.");
            string esc = MenuControl.Get().ReadESC();
            if (esc == "\0")
                break;
        Exit:
            break;
        }
    }
    public void addBookWithApi()
    {

    }
}

