using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите начальный баланс:");
        decimal bal = decimal.Parse(Console.ReadLine());

        while (bal < 0)
        {
            Console.WriteLine("Введите баланс от 0:");      
        }

        List<string> his = new List<string>();
        string cmd = "";

        while (cmd != "0")
        {
            Console.WriteLine("1. Показать баланс");
            Console.WriteLine("2. Пополнить счёт");
            Console.WriteLine("3. Снять деньги");
            Console.WriteLine("4. Показать историю операций");
            Console.WriteLine("0. Выйти");

            cmd = Console.ReadLine();

            if (cmd == "1")
            {
                Show(bal);
            }
            else if (cmd == "2")
            {
                bal = Add(bal, his);
            }
            else if (cmd == "3")
            {
                bal = Sub(bal, his);
            }
            else if (cmd == "4")
            {
                Hist(his);
            }
            else if (cmd != "0")
            {
                Console.WriteLine("Нет такого пункта");
            }
        }
    }

    static decimal Add(decimal bal, List<string> his)
    {
        Console.WriteLine("Введите сумму пополнения:");
        decimal sum = decimal.Parse(Console.ReadLine());

        if (sum > 0)
        {
            bal = bal + sum;
            his.Add($"Пополнение: {sum} ₽");
            Console.WriteLine("Счёт пополнен");
        }
        else
        {
            Console.WriteLine("Сумма должна быть больше нуля");
        }

        return bal;
    }

    static decimal Sub(decimal bal, List<string> his)
    {
        Console.WriteLine("Введите сумму снятия:");
        decimal sum = decimal.Parse(Console.ReadLine());

        if (sum <= 0)
        {
            Console.WriteLine("Сумма должна быть больше нуля");
        }
        else if (sum > bal)
        {
            Console.WriteLine("Недостаточно денег");
        }
        else
        {
            bal = bal - sum;
            his.Add($"Снятие: {sum} ₽");
            Console.WriteLine("Деньги сняты");
        }

        return bal;
    }

    static void Show(decimal bal, string cur = "₽")
    {
        Console.WriteLine($"Баланс: {bal} {cur}");
    }

    static void Hist(List<string> his)
    {
        if (his.Count == 0)
        {
            Console.WriteLine("История пуста");
        }

        for (int i = 0; i < his.Count; i++)
        {
            Console.WriteLine(his[i]);
        }
    }
}
