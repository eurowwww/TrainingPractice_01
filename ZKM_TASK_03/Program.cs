using System;

namespace ZKM_TASK_03
{
    class Program
    {

        static void Main(string[] args)
        {
            string password = "qwerty";
            string password2;
            int popitki = 3;
            while (popitki > 0)
            {
                Console.WriteLine("Введите пароль "+popitki+" попытки");
                password2 = Console.ReadLine();
                if (password == password2)
                {
                    Console.WriteLine("Секретное сообщение: хихихих");
                    break;
                }
                else
                {
                    popitki--;
                    Console.WriteLine();
                }
          
            }
        }
    }
}
