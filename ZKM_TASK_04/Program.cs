using System;
using System.Threading;

namespace ZKM_TASK_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int BossHP = rnd.Next(300, 550);
            int Bossdamage;
            int PlayerHP = rnd.Next(150, 450);
            int PlayerMP = rnd.Next(100, 300);
            int Rashamon = 0;
            bool startGame = true;
            string castspell;

            Console.WriteLine("Боcc атакует приготовьтесь к бою\n \nВыберите заклинания для атаки или лечения: \n" +
                "1. Breathe fire - Огненое дыхание наносит 80 урона, отнимает 40 единиц маны.\n" +
                "2. Hand of god - Востанавливает игроку  50 здоровья, отнимает 40 единиц маны.\n" +
                "3. Arcane bolt - Выстрел сгустком энергии наносит 75 урона, отнимает 35 единиц маны.\n" +
                "4. Firestorm - огненный  дождь  наносит 25 урона каждую секунду(длительность 4 сек), отнимает 120 единиц маны.\n"+
                "5. Recoil mana - Восстанавливает игроку 100 маны, отнимает 15 едениц хпю\n"+
                "6. Rashamon – призывает теневого духа для нанесения атаки (Отнимает 50 хп игроку)"+
                "7. Pupa (Может быть выполнен только после призыва теневого духа), наносит 100 ед.урона  ");

            while (startGame)
            {
                Bossdamage = rnd.Next(20, 85);
                Console.WriteLine($"\nСтатистика Босса: \n Здоровье: {BossHP} , Урон: {Bossdamage} \n\nСтатистика игрока: \n Здоровье: {PlayerHP} , Мана: {PlayerMP} \n");
                Console.Write("Введите заклинание: ");
                castspell = Console.ReadLine();
                if (BossHP <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nБосс погиб");
                }
                else if (PlayerHP <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else
                {
                    switch (castspell)
                    {
                        case "Breathe fire":
                            if (PlayerMP >= 40)
                            {
                                BossHP -= 80;
                                Console.WriteLine("\nБосс потерял 80 единиц здоровья");
                                PlayerMP -= 40;
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс атаковал игрок потерял {Bossdamage} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс атаковал игрок потерял {Bossdamage} здоровья\n");
                            }
                            break;
                        case "Hand of god":
                            if (PlayerMP >= 40)
                            {
                                PlayerMP -= 40;
                                PlayerHP += 50;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {PlayerHP}");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else if (PlayerHP >= 349)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            break;
                        case "Arcane bolt":
                            if (PlayerMP >= 35)
                            {
                                Console.WriteLine("\nБосс потерял 80 единиц здоровья");
                                BossHP -= 75;
                                PlayerMP -= 35;
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "Firestorm":
                            if (PlayerMP >= 120)
                            {
                                int firestorm = 0;
                                for (int i = 1; i < 5; i++)
                                {
                                    firestorm += 25;
                                    Thread.Sleep(1000);
                                    BossHP -= 25;
                                    Console.Write($"Атака огненным дождем наносит урон боссу {firestorm}:  \nПродолжительность атаки {i} секунды");
                                    Console.WriteLine();
                                }
                                Console.WriteLine($"\nБосс потерял после атаки {firestorm} единиц здоровья");
                                PlayerMP -= 120;
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            break;
                        case "Recoil mana":
                            if (PlayerHP >= 20)
                            {
                                PlayerHP -= 15;
                                PlayerMP += 100;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {PlayerHP}");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else if (PlayerMP >= 499)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно хп!");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            break;
                        case "Rashamon":
                            if(PlayerHP>=50)
                            {
                                Rashamon = 1;
                                PlayerHP -= 50;
                                Console.WriteLine("\nПризвал духа!");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно хп!");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            break;
                        case "Pupa":
                            if(Rashamon==1)
                            {
                                BossHP -= 100;
                                Console.WriteLine("\nБосс потерял 100 единиц здоровья");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс атаковал игрок потерял {Bossdamage} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nДух не призван");
                                PlayerHP -= Bossdamage;
                                Console.Write($"\nБосс использовал пинок ногой и нанес {Bossdamage} урона\n");
                            }
                            break;
                        default:
                            Console.WriteLine($"\nВам незнакомо {castspell} это заклинание");
                            break;
                    }

                }
            }
        }
    }
}
