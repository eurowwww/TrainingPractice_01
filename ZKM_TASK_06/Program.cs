using System;

namespace ZKM_TASK_06
{
    class Program
    {
        static void Main(string[] args)
        {
            const string AddDossie = "1";
            const string DisplayDossie = "2";
            const string DeleteDossie = "3";
            const string SearchDossie = "4";
            const string ExitDossie = "5";

            bool Exit = true ;
            string[] expirience = new string[0];
            string[] fullname = new string[0];

            while(Exit)
            {
                Console.Clear();
                Console.WriteLine($"{AddDossie}--Добавить досье");
                Console.WriteLine($"{DisplayDossie}--Вывести досье");
                Console.WriteLine($"{DeleteDossie}--Удалить досье");
                Console.WriteLine($"{SearchDossie}--Поиск по фамилии");
                Console.WriteLine($"{ExitDossie}--Выход");
                switch(Console.ReadLine())
                {
                    case AddDossie:
                        Add(ref fullname, ref expirience);
                        break;

                    case DisplayDossie:
                        Display(expirience,fullname);
                        break;

                    case DeleteDossie:
                       Delete(ref fullname, ref expirience);
                        break;

                    case SearchDossie:
                        Search(fullname,expirience);
                        break;
                        
                    case ExitDossie:
                        Exit = false;
                        break;

                }

                Console.WriteLine("");
                Console.ReadKey();
            }
            


        }
        private static void Add(ref string[] namee, ref string[] expiriencee)
        {
            Console.WriteLine("Введите ФИО ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Должность ");
            string expirience = Console.ReadLine();


            namee = Array(namee, name); 
            expiriencee = Array(expiriencee, expirience); 
        }

        private static string[] Array(string[] arrayy,string text)
        {
            string[] AArray = new string[arrayy.Length + 1];

            for (int i = 0;i<arrayy.Length;i++ )
            {
                AArray[i] = arrayy[i];
            }
            AArray[AArray.Length - 1] = text;
            arrayy = AArray;
            return arrayy;
        }
        private static void Display(string[] expiriancee, string[] namee)
        {
            int index = 1;

            for (int i = 0; i < expiriancee.Length; i++)
            {
                Console.WriteLine($" Номер [ {index} ] | ФИО : {namee[i]} | должность : {expiriancee[i]}");
                index++;
            }
        }

        private static void Delete(ref string[] namee, ref string[] expiriancee)
        {
            Console.Write("Введите номер досье :");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number <= namee.Length)
            {
                int index = number - 1;
                namee = FArray(namee, index);
                expiriancee = FArray(expiriancee, index);
                Console.WriteLine($"Досье с номером [ {number} ] удалено");
            }
            else
            {
                Console.WriteLine("Досье с таким номером не существует");
            }
        }

        private static string[] FArray(string[] array, int index)
        {
            string[] AArray = new string[array.Length - 1];

            for (int i = 0; i < index; i++)
            {
                AArray[i] = array[i];
            }

            for (int i = index; i < array.Length - 1; i++)
            {
                AArray[i] = array[i + 1];
            }

            array = AArray;
            return array;
        }

        private static void Search(string[] namee, string[] expiriancee)
        {
            Console.WriteLine("Введите фамилию для поиска досье");
            string surname = Console.ReadLine();
            bool Success = false;

            for (int i = 0; i < namee.Length; i++)
            {
                string[] split = namee[i].Split(' ');

                if (split[0].ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"Номер [ {i + 1} ] | ФИО : {namee[i]} | должность : {expiriancee[i]}");
                    Success = true;
                }
            }

            if (Success == false)
            {
                Console.WriteLine($"Досье сотрудников с фамилией '{surname}' не найдено!!!");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
    

