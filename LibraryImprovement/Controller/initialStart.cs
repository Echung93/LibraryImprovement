using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class initialStart
{
    public initialStart()
    {
        bool check = true;
        Start:
        while (check)
        {
            Console.Clear();
            ui.Get().mainMenu();
            List<UserVO> userList = new List<UserVO>();
            Function function = new Function();
            string input = MenuControl.Get().ReadNumber();
            switch (input)
            {
                case "1":
                    {
                        ui.Get().printScreen1();
                        goto Start;
                    }

                case "2":                   
                    {                        
                        function.register(userList);
                        goto Start;
                    }

                case "3":
                    {                        
                        ui.Get().managerPage();
                        break;
                    }

                case "4":
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

    public void searchBook(string input)
    {
        Console.Clear();
        ui.Get().printScreen1_1();
        switch (input)
        {
            case "1":
                {
                    Console.ReadLine();
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
        }
        


    }
}

