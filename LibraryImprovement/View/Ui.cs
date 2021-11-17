using System;
using System.Collections.Generic;
public class ui
{
    private static ui instance = null;

    public static ui Get()
    {
        if (instance == null)
            instance = new ui();

        return instance;
    }

    public void mainMenu()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶      로 그 인     ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶    회 원 가 입    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶    관리자  모드   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶       종  료      ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("                  원하시는 메뉴의 숫자(1~4)를 입력해주세요. : ");
    }
    public void printScreen1()
    {
        bool check = true;
        while (check)
        {
            Console.Clear();
            Console.WriteLine("       ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
            Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
            Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
            Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
            Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶      책  검색     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶      책  대출     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶      책  반납     ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶     책  리스트    ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶   나의 회원 정보  ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶ 처음 메뉴로  가기 ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("                             ▶       종  료      ◀                         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.Write("                  원하시는 메뉴의 숫자(1~7)를 입력해주세요. : ");
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
                        break;
                    }

                case "3":
                    {
                        break;
                    }

                case "4":
                    {
                        break;
                    }

                case "5":
                    {
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
                        Console.Write("                  1~4번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    }
    public void printScreen1_1()
    {
        bool check = true;
        Console.Clear();
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ------------------------   책 검색 메뉴   ------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 책  이름으로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 책  저자명로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 책  출판사로 검색 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 메뉴로  돌아 가기 ◀                         ");
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
                        break;
                    }

                case "2":
                    {
                        break;
                    }

                case "3":
                    {
                        break;
                    }

                case "4":
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
                        Console.Write("                  1~4번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    }

    public void printScreen1_1_1()
    {
        bool check = true;
        while (check)
        {
            Console.WriteLine("       ------------------------------------------------------------------    ");
            Console.WriteLine("\r\n");
            Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
            Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
            Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
            Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
            Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
            Console.WriteLine("\r\n");
            Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
            Console.Write("        검색하실/대여하실 책의 이름 정보 검색 : ");

        }
    }

    public void printScreen1_1_2()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("        검색하실 책의 저자 이름 정보 검색 : ");
    }

    public void printScreen1_1_3()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("        검색하실 책의 출판사 이름 정보 검색 : ");
    }

    public void printScreen1_2()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("        검색하실/대여하실 책의 이름 정보 검색 :                                  ");
    }

    public void printScreen1_3()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("        {0}님의 대출 책 목록                                                 ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                                                      ");
        Console.WriteLine("\r\n");
        Console.Write("        반납할 책의 숫자를 입력해주세요 :                         ");

    }

    public void printScreen1_4()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                                  등록 책 LIST                               ");
        Console.WriteLine("\r\n");


    }

    public void printScreen1_5()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                                  등록 책 LIST                               ");



    }

    public void printScreenEtc()
    {
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
    }

    public void managerPage()
    {
        Console.Clear();
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("         관리자 비밀 번호를 입력 하시오 : ");
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
        bool check = true;
        Console.Clear();
        
        Console.WriteLine("       ------------------------------------------------------------------    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("          ■        ■   ■■■     ■■■     ■■   ■■■   ■    ■      ");
        Console.WriteLine("          ■        ■   ■   ■    ■   ■   ■  ■  ■   ■   ■  ■       ");
        Console.WriteLine("          ■        ■   ■■■■   ■■■    ■■■  ■■■      ■         ");
        Console.WriteLine("          ■        ■   ■    ■   ■   ■   ■  ■  ■   ■     ■         ");
        Console.WriteLine("          ■■■■  ■   ■■■■   ■    ■  ■  ■  ■    ■    ■         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ---------------------------------------------- 뒤로가기 : ESC ----    ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("       ------------------------    관리자 메뉴    -----------------------");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶    회원  리스트   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶     책  리스트    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶     회원  검색    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶     회원  삭제    ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶   책  정보 수정   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶   신규 책  등록   ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶      책  삭제     ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 책 대여/반납 기록 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("                             ▶ 메뉴로  돌아 가기 ◀                         ");
        Console.WriteLine("\r\n");
        Console.WriteLine("\r\n");
        Console.Write("                  원하시는 메뉴의 숫자(1~9)를 입력해주세요. : ");
        while (check)
        {
            string input = MenuControl.Get().ReadNumber();
            
            switch(input)
            {
                case "1":
                    {
                        break;
                    }

                case "2":
                    {
                        break;
                    }

                case "3":
                    {
                        break;
                    }

                case "4":
                    {
                        break;
                    }

                case "5":
                    {
                        break;
                    }

                case "6":
                    {
                        break;
                    }

                case "7":
                    {
                        break;
                    }

                case "8":
                    {
                        break;
                    }

                case "9":
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
                        Console.Write("                  1~9번의 숫자를 입력해주세요.");
                        break;
                    }
            }
        }
    }

    public void printUserList()
    {
        //foreach (UserVO uv in userList)
        //{
        //    Console.WriteLine("       ------------------------------------------------------------------    ");
        //    Console.WriteLine("\r\n");
        //    Console.WriteLine("        회원 이름 : " + uv.UserName);
        //    Console.WriteLine("        회원 나이 : " + uv.UserAge);
        //    Console.WriteLine("        회원 휴대폰 번호 : " + uv.UserPhoneNumber);
        //    Console.WriteLine("        회원 주소 : " + uv.UserAddress);
        //    Console.WriteLine("        대출한 권 수 : " + uv.BorrowedBookCount);
        //    Console.WriteLine("\r\n");
        //}
        //Console.WriteLine("       ------------------------------------------------------------------    ");
        //Console.WriteLine($"                등록된 총 회원 수는 : {userList.Count} 명 입니다");
        //Console.WriteLine("\r\n        뒤로가기를 원하시면 ESC를 눌러주세요.");
    }

    public void printBookList()
    {
        //    foreach (BookVO bv in bookList)
        //    {
        //        Console.WriteLine("       ------------------------------------------------------------------    ");
        //        Console.WriteLine("\r\n");
        //        Console.WriteLine("        책  ID 넘버 : " + bv.BookIDNumber);
        //        Console.WriteLine("        책  이름 : " + bv.BookName);
        //        Console.WriteLine("        책  출판사 : " + bv.BookPublisher);
        //        Console.WriteLine("        책  가격 : " + bv.BookPrice);
        //        Console.WriteLine("        책  수량 : " + bv.BookQuantity);
        //        Console.WriteLine("\r\n");
        //    }
        //    Console.WriteLine("       ------------------------------------------------------------------    ");
        //    Console.WriteLine($"                등록된 총 책의 권 수는 : {bookList.Count} 개 입니다");
        //    Console.WriteLine("\r\n        뒤로가기를 원하시면 ESC를 눌러주세요.");
    }

}
