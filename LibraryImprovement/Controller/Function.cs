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
        string userName = "관리자";
        string action = "로그인";
        while (true)
        {
            if (input == "1234")
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                db.logSave(userName, null, time, action);
                return false;
            }

            else
            {
                Console.Write("\r\n 관리자 비밀 번호를 다시 입력 하시오 : ");
                input = MenuControl.Get().ReadPassword();
            }
        }
    }

    public List<UserVO> loginUser(List<UserVO> userList)
    {
        string action = "로그인";
        Console.Clear();
        bool check = true;
        bool check1 = true;
        userList = db.userList(userList);
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
                            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                            db.logSave(userList[i].UserName, null, time, action);
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
    public void register(List<UserVO> userList)
    {
        userList = db.userList(userList);
        string action = "회원가입";
        bool check = true;
        Console.Clear();
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
                    if (userList[i].UserId == UserId.Replace(" ", ""))
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
        string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        db.logSave(UserName, null, time, action);
        Console.WriteLine($"\r\n        회원 가입 완료 ");
        Console.WriteLine($"\r\n        뒤로가려면 아무키나 누르세요. ");
        MenuControl.Get().ReadESC();

    Exit:
        check = false;

    }

    public void userDelete(List<UserVO> List)
    {
        string userName = "관리자";
        string action = "삭제";
        int count = 0;
        int count1 = 0;
        Console.Clear();
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
        Console.Write("\r\n        삭제하고 싶은 회원 ID를 입력하세요(English and Number) : ");
    Check:
        
        string userId = MenuControl.Get().ReadEnglish();

        if (userId == "\0")
        {
            goto Exit;
        }

        foreach (UserVO uv in List)
        {
            if (int.Parse(uv.BorrowedBookCount) != 0 && uv.UserId == userId)
            {                
                count1++;
            }

            else if (uv.UserId == userId )
            {
                db.userDelete(userId);
                Console.WriteLine("\r\n        회원 삭제 완료! ");
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string user = "유저 : " + uv.UserName;
                db.logSave(userName, user, time, action);
                count++;
                Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
                MenuControl.Get().ReadESC();
                goto Exit;
            }
        }

        if (count1 != 0)
        {
            Console.Write("\r\n        회원이 반납해야될 책이 있습니다. 반납 후 시도해주세요. ");
            Console.Write("\r\n        삭제하고 싶은 회원 ID를 입력하세요(English and Number) : ");
            goto Check;
        }

        else if (count == 0)
        {
            Console.Write("\r\n        존재하지 않는 회원입니다. 회원 ID를 정확히 입력하세요(English and Number) : ");
            goto Check;
        }


    Exit:
        ;
        
    }

    public void bookDelete(List<BookVO> List)
    {
        string userName = "관리자";
        string action = "삭제";
        bool check = true;
        Console.Clear();
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.WriteLine("                             책 List ");
        List = db.bookList(List);
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
        Console.WriteLine($"           등록된 총 책의 종류는 {List.Count}종류 입니다.    ");
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
                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    string bookname = "책 이름 : " + List[i].BookName;
                    db.logSave(userName, bookname, time, action);
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
        string user = "관리자";
        bool check = true;
        List = db.bookList(List);
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
        Console.WriteLine($"           등록된 총 책의 종류는 {List.Count}종류 입니다.    ");
        Console.Write("\r\n        변경하고자 하는 책IDNumber를 입력하세요(Number) : ");
        string bookIDNumber = MenuControl.Get().ReadNumber();

        while (check)
        {
            int count = 1;
            for (int i = 0; i < List.Count; i++)
            {
                if (bookIDNumber == "\0")
                {
                    goto Exit;
                }

                else if (List[i].BookIDNumber == bookIDNumber)
                {
                    Console.Write("\r\n        변경하고자 하는 책의 수량을 입력하세요(Number) : ");
                    string bookQuantity = MenuControl.Get().ReadNumber();
                    if (bookQuantity == "\0")
                    {
                        goto Exit;
                    }
                    db.bookUpdate(bookIDNumber, bookQuantity);
                    string bookName = "책 : " + List[i].BookName;
                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    string action = "책의 갯수를 수정";
                    db.logSave(user, bookName, time, action);
                    Console.Write($"\r\n        책 이름 : {List[i].BookName}의 갯수를 수정하였습니다. ");
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
    Exit:
        ;

    }

    public void modifyUserInformation(List<UserVO> currentUser)
    {
        Console.Write(" 전화번호를 수정하려면 1번,주소를 수정하려면 2번 입력해주세요. : ");
        string input = MenuControl.Get().ReadNumber();
        if (input == "1")
        {
            Console.Write("\r\n 수정하려는 전화번호를 입력('-' 제외하고 입력) : 010");

        Start:
            string phoneNumber = MenuControl.Get().ReadNumber();
            if (phoneNumber.Length == 8)
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string action = "전화번호를 수정";
                db.logSave(currentUser[0].UserName, null, time, action);
                db.userUpdate(currentUser[0].UserId, phoneNumber, null);
            }

            else
            {
                Console.Write("\r\n 수정하려는 전화번호 8자리를 다시 입력해주세요.('-' 제외하고 입력) : 010");
                goto Start;
            }
        }

        else if (input == "2")
        {
            Console.Write("\r\n 수정하려는 주소를 입력 : ");
            string address = MenuControl.Get().ReadString();
            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string action = "주소를 수정";
            db.logSave(currentUser[0].UserName, null, time, action);
            db.userUpdate(currentUser[0].UserId, null, address);
        }

        else if (input == "\0")
        {
            goto Exit;
        }

        Console.WriteLine($"\r\n 수정을 완료하였습니다. ");
        Console.WriteLine($"\r\n 뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    Exit:
        ;

    }

    public void printBookList(List<BookVO> List)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        List = db.bookList(List);
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
        Console.WriteLine($"           등록된 총 책의 종류는 {List.Count}종류 입니다.    ");
        Console.WriteLine($"\r\n           뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    }

    public void administratorPrintBookList(List<BookVO> bookList)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        bookList = db.bookList(bookList);
        Console.WriteLine("                             책 List ");

        foreach (BookVO bv in bookList)
        {
            Console.WriteLine(" ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine(" 책  ID 넘버 : " + bv.BookIDNumber);
            Console.WriteLine(" 책  이름 : " + bv.BookName);
            Console.WriteLine(" 책  저자 : " + bv.BookAuthor);
            Console.WriteLine(" 책  출판사 : " + bv.BookPublisher);
            Console.WriteLine(" 책  가격 : " + bv.BookPrice);
            Console.WriteLine(" 책  수량 : " + bv.BookQuantity);
            Console.WriteLine(" 책  총 수량 : " + bv.BookTotalQuantity);
            Console.WriteLine(" 책  출간일 : " + bv.BookPublicationDate);
            Console.WriteLine(" 책  ISBN : " + bv.BookISBN);
            Console.WriteLine(" 책  설명 : " + bv.BookDescription);
            Console.WriteLine("\r\n");
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine($"           등록된 총 책의 종류는 {bookList.Count}종류 입니다.    ");
        Console.WriteLine($"\r\n           뒤로가려면 ESC를 누르세요. ");
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
            if (uv.BorrowedBookCount == "0")
            {
                Console.WriteLine($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            }
            else
            {
                Console.Write($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            }
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
            if (uv.BorrowedBookCount == "0")
            {
                Console.WriteLine($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            }
            else
            {
                Console.Write($" {uv.UserName}님의 빌린 책 이름 : " + uv.BorrowedBookList);
            }
            Console.WriteLine($" {uv.UserName}님의 빌린 책 갯수 : " + uv.BorrowedBookCount);
            Console.WriteLine("\r\n");
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
    }

    public void addBook(List<BookVO> List)
    {
        string userName = "관리자";
        string action = "추가";
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
            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string bookName = "책이름 : " + BookName;
            db.logSave(userName, bookName, time, action);
            Console.WriteLine("\r\n        뒤로가기를 원하시면 ESC를 눌러주세요.");
            string esc = MenuControl.Get().ReadESC();
            if (esc == "\0")
                break;
            Exit:
            break;
        }
    }
    public void addBookWithApi(List<BookVO> bookList)
    {
        string userName = "관리자";
        string action = "추가";
        List<BookVO> dbBookList = new List<BookVO>();
        dbBookList = db.bookList(bookList);
        bool check1 = true;
        Console.Write(" 등록하고자하는 책의 ISBN번호 앞10자리를 입력해주세요. : ");
        string isbn = MenuControl.Get().ReadNumber();
        int count = 0;
        while (check1)
        {
            foreach (BookVO bv in dbBookList)
            {
                if (bv.BookISBN.Contains(isbn))
                {
                    count++;
                }
            }


            if (isbn.Length != 10)
            {
                Console.Write("\r\n 등록하고자하는 책의 ISBN번호 앞10자리를 제대로 입력해주세요. : ");
                isbn = MenuControl.Get().ReadNumber();
            }

            else if (count == 0)
            {
                foreach (BookVO bv in bookList)
                {
                    if (bv.BookISBN.Contains(isbn))
                    {
                        int count1 = 0;
                        Console.Write("\r\n 등록하고자하는 책 ID 숫자 입력(입력예시 : 1234) : ");
                        string IDnumber = MenuControl.Get().ReadNumber();

                        if (IDnumber == "\0")
                        {
                            goto Exit;
                        }

                    Check:
                        for (int i = 0; i < dbBookList.Count; i++)
                        {
                            if (dbBookList[i].BookIDNumber == IDnumber)
                            {
                                count++;
                                Console.Write("\r\n 있는 책 ID입니다. 다시 책 ID 숫자를 입력(입력예시 : 1234) : ");
                                IDnumber = MenuControl.Get().ReadNumber();
                            }
                        }

                        if (count1 == 0)
                        {
                            if (IDnumber.Length != 4)
                            {
                                Console.Write("\r\n        4자리의 책 ID 숫자를 다시 입력해주세요 (입력예시 : 1234) : ");
                                IDnumber = MenuControl.Get().ReadNumber();
                                goto Check;
                            }
                        }

                        Console.Write("\r\n 등록하고자하는 책 수량을 입력해주세요.(1 ~ 100) : ");
                    Check2:
                        string quantity = MenuControl.Get().ReadNumber();
                        if (int.Parse(quantity) < 1 || int.Parse(quantity) > 100)
                        {
                            Console.Write("\r\n 등록하고자하는 책 수량을 다시 입력해주세요.(1 ~ 100) : ");
                            goto Check2;
                        }

                        db.bookSave(IDnumber, bv.BookName, bv.BookAuthor, bv.BookPublisher, bv.BookPrice, quantity, bv.BookPublicationDate, bv.BookISBN, bv.BookDescription);
                        Console.Write($"\r\n 책 이름 : {bv.BookName}을 등록하였습니다. ");
                        Console.WriteLine("\r\n        뒤로가기를 원하시면 ESC를 눌러주세요.");
                        string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                        string bookName = "책이름 : " + bv.BookName;
                        db.logSave(userName, bookName, time, action);
                        string esc = MenuControl.Get().ReadESC();
                        if (esc == "\0")
                            goto Exit;
                    }
                }
            }

            else
            {
                Console.Write("\r\n 등록하고자하는 책이 존재합니다.등록하고자하는 책의 ISBN번호를 다시 입력해주세요. : ");
                isbn = MenuControl.Get().ReadNumber();
            }
        }
    Exit:
        ;
    }

    public List<BookVO> searchBook(List<BookVO> bookList, string input, string input1)
    {
        bookList = db.bookList(bookList);
        List<BookVO> searchList = new List<BookVO>();
        Console.WriteLine("\r\n                             책 List ");
        if (input == "1")
        {
            foreach (BookVO bv in bookList)
            {
                if (bv.BookName.Contains(input1))
                {
                    BookVO bookVO = new BookVO();
                    Console.WriteLine(" ------------------------------------------------------------------    ");
                    Console.WriteLine("\r\n");
                    Console.WriteLine(" 책  ID 넘버 : " + bv.BookIDNumber);
                    bookVO.BookIDNumber = bv.BookIDNumber;
                    Console.WriteLine(" 책  이름 : " + bv.BookName);
                    bookVO.BookName = bv.BookName;
                    Console.WriteLine(" 책  저자 : " + bv.BookAuthor);
                    bookVO.BookAuthor = bv.BookAuthor;
                    Console.WriteLine(" 책  출판사 : " + bv.BookPublisher);
                    bookVO.BookPublisher = bv.BookPublisher;
                    Console.WriteLine(" 책  가격 : " + bv.BookPrice);
                    bookVO.BookPrice = bv.BookPrice;
                    Console.WriteLine(" 책  수량 : " + bv.BookQuantity);
                    bookVO.BookQuantity = bv.BookQuantity;
                    Console.WriteLine(" 책  출간일 : " + bv.BookPublicationDate);
                    bookVO.BookPublicationDate = bv.BookPublicationDate;
                    Console.WriteLine(" 책  ISBN : " + bv.BookISBN);
                    bookVO.BookISBN = bv.BookISBN;
                    Console.WriteLine(" 책  설명 : " + bv.BookDescription);
                    bookVO.BookDescription = bv.BookDescription;
                    Console.WriteLine("\r\n");
                    searchList.Add(bookVO);
                }
            }
        }

        else if (input == "2")
        {
            foreach (BookVO bv in bookList)
            {
                if (bv.BookAuthor.Contains(input1))
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
            }
        }

        else if (input == "3")
        {
            foreach (BookVO bv in bookList)
            {
                if (bv.BookPublisher.Contains(input1))
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
            }
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        return searchList;
    }

    public void searchUser(List<UserVO> userList)
    {
        int count = 0;
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.Write(" 검색하실 사용자 이름 검색 : ");
    Check:
        string input = MenuControl.Get().ReadLanguage();
        if (input == "\0")
        {
            goto Exit;
        }
        foreach (UserVO uv in userList)
        {
            if (uv.UserName.Contains(input))
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
                count++;
            }
        }
        if (count == 0)
        {
            Console.Write("\r\n 존재하지 않는 사용자입니다. 사용자 이름을 다시 입력해주세요. : ");
            goto Check;
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    Exit:
        ;
    }
    public void borrowBooks(List<BookVO> bookList, List<UserVO> currentUser)
    {
        string action = "대출";
        Console.Clear();
        ui.Get().printScreen1_1_1();
    Check:
        string input = MenuControl.Get().ReadString();
        if (input == "\0")
        {
            goto Exit;
        }

        bookList = searchBook(bookList, "1", input);

        if (bookList.Count == 0)
        {
            Console.Write("\r\n 검색 하신 책이 존재하지 않습니다. 책 이름을 다시 입력해주세요. : ");
            goto Check;
        }

        Console.Write("\r\n 대출 하시려는 책의 ID넘버를 입력하세요(ex.1234) : ID");
    Check1:
        string num = MenuControl.Get().ReadNumber();
        if (num == "\0")
        {
            goto Exit;
        }

        else if (num.Length == 4)
        {
            int count = 0;
            foreach (BookVO bv in bookList)
            {
                if (bv.BookIDNumber == num)
                {
                    Console.Write($"\r\n 책 이름 : {bv.BookName}을 대출하였습니다. ");
                    currentUser[0].BorrowedBookList += bv.BookName.Substring(0, 39) + "\n";
                    currentUser[0].BorrowedBookCount = (int.Parse(currentUser[0].BorrowedBookCount) + 1).ToString();
                    db.currentUserSave(currentUser[0].UserId, currentUser[0].BorrowedBookList, currentUser[0].BorrowedBookCount);
                    string bookQuantity = (int.Parse(bv.BookQuantity) - 1).ToString();
                    db.borrowedBook(bv.BookIDNumber, bookQuantity);
                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    db.logSave(currentUser[0].UserName, bv.BookName, time, action);
                    Console.WriteLine("\r\n 뒤로가기를 원하시면 ESC를 눌러주세요.");

                    string esc = MenuControl.Get().ReadESC();
                    if (esc == "\0")
                        goto Exit;
                }
            }

            if (count == 0)
            {
                Console.Write("\r\n 존재하지 않는 ID 넘버 입니다. 대출 하시려는 책의 ID넘버 4자리를 다시 입력하세요(ex.1234) : ID");
                goto Check1;
            }
        }

        else
        {
            Console.Write("\r\n 대출 하시려는 책의 ID넘버 4자리를 다시 입력하세요(ex.1234) : ID");
            goto Check1;
        }
    Exit:
        ;
    }

    public void returnBookList(List<BookVO> bookList, List<UserVO> currentUser)
    {
        string action = "반납";
        Console.Clear();
        ui.Get().printScreenEtc();
        bookList = db.bookList(bookList);
        string borrowedBook = null;
        if (int.Parse(currentUser[0].BorrowedBookCount) == 0)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("        {0}님의 대출 책 목록                                                 ", currentUser[0].UserName);
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.WriteLine("        반납할 책이 없습니다 ");
            Console.WriteLine("        뒤로가려면 ESC를 눌러주세요. ");
            string input1 = MenuControl.Get().ReadESC();
            if (input1 == "\0")
            {
                goto Exit;
            }
        }

        else
        {
            int count = 0;
            string[] split = currentUser[0].BorrowedBookList.Split('\n');
            Console.WriteLine("\r\n");
            Console.WriteLine("        {0}님의 대출 책 목록                                                 ", currentUser[0].UserName);
            Console.WriteLine("\r\n");
            for (int n = 0; n < split.Length - 1; n++)
            {
                Console.WriteLine($"        {count} {split[n]}                                            ");
                count++;
            }
            Console.WriteLine("\r\n");
            Console.Write("        반납할 책의 숫자를 입력해주세요 : ");
            Check :
            string input = MenuControl.Get().ReadNumber();
           
            if (input == "\0")
            {
                goto Exit;
            }
            int num = int.Parse(input);
            
            if (num < split.Length - 1)
            {
                for (int i = 0; i < split.Length - 1; i++)
                {
                    if (i != num)
                    {
                        borrowedBook += split[i] + "\n";
                    }
                }
                currentUser[0].BorrowedBookCount = (int.Parse(currentUser[0].BorrowedBookCount) - 1).ToString();
                db.currentUserSave(currentUser[0].UserId, borrowedBook, currentUser[0].BorrowedBookCount);
                Console.Write($"\r\n        책 이름 : {split[num]}을 반납하였습니다. ");
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                foreach (BookVO bv in bookList)
                {
                    if (bv.BookName.Contains(split[num]))
                    {
                        string bookQuantity = (int.Parse(bv.BookQuantity) + 1).ToString();
                        db.borrowedBook(bv.BookIDNumber, bookQuantity);
                    }
                }
                db.logSave(currentUser[0].UserName, split[num], time, action);
                Console.WriteLine("\r\n        뒤로가려면 ESC를 눌러주세요. ");
                string input1 = MenuControl.Get().ReadESC();
                if (input1 == "\0")
                {
                    goto Exit;
                }

            }

            else
            {
                Console.Write($"\r\n        숫자를 정확히 입력해주세요. : ");
                goto Check;
            }
        }
    Exit:
        ;
    }

    public void printlog(List<LogHistoryVO> List)
    {
        Console.Clear();
        ui.Get().printScreenEtc();
        Console.WriteLine("                          Log List ");
        foreach (LogHistoryVO lv in List)
        {
            if (lv.BookName.Length == 0)
            {
                Console.WriteLine($"\r\n {lv.UserName} 님이 {lv.Time}에 {lv.Action}하였습니다. ");
            }

            else
            {
                Console.WriteLine($"\r\n {lv.UserName} 님이 {lv.BookName}을(를) {lv.Time}에 {lv.Action}하였습니다. ");
            }
        }
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine($"\r\n        뒤로가려면 ESC를 누르세요. ");
        MenuControl.Get().ReadESC();
    }
}


