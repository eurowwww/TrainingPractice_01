using System;

namespace ZKM_TASK_01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool money;
            int crystalprice = 100;
            Console.WriteLine("Количество золота");
            int gold = int.Parse(Console.ReadLine());
            Console.WriteLine("Сколько кристаллов");
            int crystalcount = int.Parse(Console.ReadLine());
            money = gold >= crystalcount * crystalprice;
            crystalcount *= Convert.ToInt32(money);
            gold -= crystalcount * crystalprice;
            Console.WriteLine($"У вас осталось золота {gold} и кристаллов {crystalcount}");
        }
    }
}
