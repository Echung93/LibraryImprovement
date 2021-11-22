using System;
using System.Collections.Generic;
public class ui
{
    private static ui instance = null;
    Function function = new Function();
    API api = new API();
    DB db = new DB();
    List<UserVO> userList = new List<UserVO>();
    List<BookVO> bookList = new List<BookVO>();
    List<LogHistoryVO> logList = new List<LogHistoryVO>();
    List<BookVO> currentUser = new List<BookVO>();

    public static ui Get()
    {
        if (instance == null)
            instance = new ui();

        return instance;
    }

    public void mainMenu()
    {
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶      로 그 인     ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶    회 원 가 입    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶    관리자  모드   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶       종  료      ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("              원하시는 메뉴의 숫자(1~4)를 입력해주세요. : ");
    }
    public void printScreen1()
    {
        bool check = true;
        List<UserVO> currentUser = new List<UserVO>();        
        currentUser = function.loginUser(userList);
        bookList = db.bookList(bookList);
        if (currentUser.Count == 0)
        {
            check = false;
        }

        while (check)
        {            
            Console.Clear();
            Console.WriteLine(" ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
            Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
            Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
            Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
            Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
            Console.WriteLine("\r\n");
            Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶      책  검색     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶      책  대출     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶      책  반납     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶     책  리스트    ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶   나의 회원 정보  ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶ 처음 메뉴로  가기 ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                       ▶       종  료      ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.Write("              원하시는 메뉴의 숫자(1~7)를 입력해주세요. : ");
            string input = MenuControl.Get().ReadNumber();

            switch (input)
            {
                case "1":
                    {
                        ui.Get().printScreen1_1();
                        break;
                    }

                case "2":
                    {
                        function.borrowBooks(bookList, currentUser) ;
                        break;
                    }

                case "3":
                    {
                        currentUser = db.currentUser(currentUser);
                        function.returnBookList(bookList, currentUser);
                        break;
                    }

                case "4":
                    {
                        function.printBookList(bookList);
                        break;
                    }

                case "5":
                    {
                        currentUser = db.currentUser(currentUser);
                        function.printUser(currentUser);
                        function.modifyUserInformation(currentUser);
                        break;
                    }

                case "6":
                    {
                        check = false;
                        break;
                    }

                case "7":
                    {
                        Environment.Exit(7);
                        break;
                    }

                case "\0":
                    {
                        check = false;
                        break;
                    }

                default:
                    {
                        Console.WriteLine("\r\n");
                        Console.Write("                1~7번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    }
    public void printScreen1_1()
    {
        bool check = true;
        Console.Clear();
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ------------------------   책 검색 메뉴   ------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 책  이름으로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 책  저자명로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 책  출판사로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 메뉴로  돌아 가기 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("                  원하시는 메뉴의 숫자(1~4)를 입력해주세요. : ");
        while (check)
        {

            string input = MenuControl.Get().ReadNumber();
            switch (input)
            {
                case "1":
                    {
                        ui.Get().printScreen1_1_1();
                        string input1 = MenuControl.Get().ReadString();
                        function.searchBook(bookList, input, input1);
                        Console.WriteLine($"\r\n 뒤로가려면 ESC를 누르세요. ");
                        MenuControl.Get().ReadESC();
                        goto Exit;
                    }

                case "2":
                    {
                        ui.Get().printScreen1_1_2();
                        string input1 = MenuControl.Get().ReadString();
                        function.searchBook(bookList, input, input1);
                        Console.WriteLine($"\r\n 뒤로가려면 ESC를 누르세요. ");
                        MenuControl.Get().ReadESC();
                        goto Exit;
                    }

                case "3":
                    {
                        ui.Get().printScreen1_1_3();
                        string input1 = MenuControl.Get().ReadString();
                        function.searchBook(bookList, input, input1);
                        Console.WriteLine($"\r\n 뒤로가려면 ESC를 누르세요. ");
                        MenuControl.Get().ReadESC();
                        goto Exit;
                    }

                case "4":
                    {
                        goto Exit;
                    }

                case "\0":
                    {
                        goto Exit;
                    }

                default:
                    {
                        Console.WriteLine("\r\n");
                        Console.Write("                  1~4번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    Exit:
        ;
    }

    public void printScreen1_1_1()
    {
        Console.Clear();
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write(" 검색하실/대여하실 책의 이름 정보 검색 : ");

    }

    public void printScreen1_1_2()
    {
        Console.Clear();
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write(" 검색하실 책의 저자 이름 정보 검색 : ");
    }

    public void printScreen1_1_3()
    {
        Console.Clear();
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write(" 검색하실 책의 출판사 이름 정보 검색 : ");
    }
    public void printScreenEtc()
    {
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
    }

    public void managerPage()
    {
        Console.Clear();
        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write(" 관리자 비밀 번호를 입력 하시오 : ");
        string input = MenuControl.Get().ReadPassword();

        if (input == "\0")
        {

        }

        else
        {
            new Function().loginManager(input);           
            ui.Get().printScreen3_1();
        }
    }

    public void printScreen3_1()
    {
    Start:
        bool check = true;
        Console.Clear();
        userList = db.userList(userList);
        bookList = db.bookList(bookList);
        logList = db.logList(logList);

        Console.WriteLine(" ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine(" ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine(" ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine(" ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine(" ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine(" ------------------------    관리자 메뉴    -----------------------");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶    회원  리스트   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶     책  리스트    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶     회원  검색    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶     회원  삭제    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶   책  정보 수정   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶   신규 책  등록   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶      책  삭제     ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 책 검색 in Naver  ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ Library Log 보기  ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                       ▶ 메뉴로  돌아 가기 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("               원하시는 메뉴의 숫자(1~10)를 입력해주세요. : ");
        while (check)
        {
            string input = MenuControl.Get().ReadNumber();

            switch (input)
            {
                case "1":
                    {                        
                        function.printUserList(userList);
                        goto Start;
                    }

                case "2":
                    {                        
                        function.administratorPrintBookList(bookList);
                        goto Start;
                    }

                case "3":
                    {
                        function.searchUser(userList);
                        goto Start;
                    }

                case "4":
                    {
                        function.userDelete(userList);
                        goto Start;
                    }

                case "5":
                    {
                        function.modifyBookInformation(bookList);
                        goto Start;
                    }

                case "6":
                    {
                        function.addBook(bookList);
                        goto Start;
                    }

                case "7":
                    {
                        function.bookDelete(bookList);
                        goto Start;
                    }

                case "8":
                    {
                        Console.Clear();
                        ui.Get().printScreenEtc();
                        Console.Write("\r\n 검색하실 책의 이름을 입력해주세요. : ");
                        string bookName = MenuControl.Get().ReadString();
                        if (bookName == "\0")
                        {
                            goto Start;
                        }
                        Console.Write("\r\n 나타나실 책의 갯수를 입력해주세요. : ");
                        string num = MenuControl.Get().ReadString();
                        if (num == "\0")
                        {
                            goto Start;
                        }
                        api.searchBook(bookName, num);
                        goto Start;
                    }

                case "9":
                    {
                        function.printlog(logList);
                        goto Start;
                    }

                case "10":
                    {
                        check = false;
                        break;
                    }

                case "\0":
                    {
                        check = false;
                        break;
                    }

                default:
                    {
                        Console.WriteLine("\r\n");
                        Console.Write("                  1~10번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    }   

}
