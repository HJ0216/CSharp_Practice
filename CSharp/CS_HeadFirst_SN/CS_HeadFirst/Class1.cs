using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    internal class Class1
    {
        public void transactMoney()
        {
            Guy joe = new Guy()
            {
                Name = "Joe",
                Cash = 50,
            };
            Guy bob = new Guy()
            {
                Name = "Bob",
                Cash = 100,
            };

            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "")
                {
                    return;
                }
                if(int.TryParse(howMuch, out int money))
                {
                    Console.Write("Who Should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if(whichGuy == "Joe")
                    {
                        int amount = joe.GiveCash(money);
                        bob.ReceiveCash(amount);
                    }
                    else if(whichGuy == "Bob")
                    {
                        int amount = bob.GiveCash(money);
                        joe.ReceiveCash(amount);
                    }
                    else
                    {
                        Console.WriteLine("Please Enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount or a blank line to exit.");
                }
            }
        }


    }

    class Guy
    {
        public string Name;
        public int Cash;

        /// <summary>
        /// 해당하는 사람의 이름과 가진 돈을 콘솔에 출력
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }

        /// <summary>
        /// 돈을 줍니다
        /// 부족하면 메시지를 출력합니다
        /// </summary>
        /// <param name="amount">줄 돈의 금액</param>
        /// <returns>줄어든 돈의 금액</returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + Cash + " isn't a valid amount");
                return 0;
            }
            if(amount > Cash)
            {
                Console.WriteLine(Name + " says: I don't have enough cash to give you " + Cash);
                return 0;
            }

            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// 돈을 받습니다
        /// 유효하지 않으면 메시지를 출력합니다
        /// </summary>
        /// <param name="amount">줄 돈의 금액</param>
        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + Cash + " isn't an amount I'll Take");
            }
            else
            {
                Cash += amount;
            }
        }
    }
}
