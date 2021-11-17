using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Function
{
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

    public void register(List<UserVO> List)
    {
        bool check = true;
        bool check1 = true;
        Console.Clear();
        DB db = new DB();
        //List<BookVO> books = new List<BookVO>();
        //db.DB1(books);
        List<string> userList = db.userList(List);
        Console.Write("\r\n        회원 ID를 입력하세요(English and Number) : ");
        string UserId = MenuControl.Get().ReadString();

        while (check)
        {
            int count = 0;

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList.Contains(UserId))
                {
                    Console.Write("\r\n        이미 존재하는 ID입니다. 회원 ID를 다시 입력하세요(English and Number) : ");
                    UserId = MenuControl.Get().ReadString();
                    count++;
                    break;
                }
            }

            if (count == 0)
            {
                check = false;
            }
        }
        Console.Write("\r\n        회원 비밀 번호를 입력하세요(English and Number) : ");
        string UserPassword = MenuControl.Get().ReadPassword();
        Console.Write("\r\n        회원 이름 입력(공백없이 2~5 글자의 한글) : ");
        string UserName = MenuControl.Get().ReadString();
        bool check2 = true;

        while (check2)
        {
            if (UserName.Length < 2 || UserName.Length > 5)
            {
                Console.Write("\r\n        공백없이 2~5 글자의 한글을 입력해주세요. : ");
                UserName = MenuControl.Get().ReadString();
            }

            else
            {
                check2 = false;
            }

        }
        Console.Write($"\r\n        {UserName} 님의 나이 입력(1~100 사이 숫자만 입력) : ");
        bool check3 = true;
        string UserAge = MenuControl.Get().ReadNumber();
        while (check3)
        {            
            if (int.Parse(UserAge) == 0 || int.Parse(UserAge) > 100 || UserAge == "\0")
            {
                Console.Write($"\r\n        1~100사이의 숫자만 입력해주세요.");
                UserAge = MenuControl.Get().ReadNumber();
            }

            else
            {
                check3 = false;
            }

        }
        Console.Write($"\r\n        {UserName} 님의 핸드폰 번호 입력('-' 제외하고 입력) : 010");
        string UserPhoneNumber = MenuControl.Get().ReadNumber();
        bool check4 = true;
        while (check4)
        {
            if (UserPhoneNumber.Length == 8)
            {
                check4 = false;
                
            }

            else
            {
                Console.Write($"\r\n        8자리 숫자만 입력해주세요. : ");
                UserPhoneNumber = MenuControl.Get().ReadNumber();
            }

        }
        Console.Write($"\r\n        {UserName} 님의 회원 주소 입력 : ");
        string UserAddress = MenuControl.Get().ReadString();
        db.userSave(UserId,UserPassword,UserName,UserAge,UserPhoneNumber,UserAddress);
        Console.Write($"\r\n        회원 가입 완료 ");
        Console.ReadLine();
    }
}

