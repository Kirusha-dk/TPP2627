using System;

class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count;

    public Character(string name, int hp, int power)
    {
        if (!IsValidStats(hp, power))
        {
            throw new ArgumentException(
                "Здоровье и сила удара должны быть больше нуля.");
        }

        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;

        Console.WriteLine(
            $"Создан персонаж: {name} (HP: {hp}, Урон: {power})");
    }

    public bool Attack(Character target)
    {
        target.hp -= power;
        Console.WriteLine($"{name} атакует {target.name} на {power} 
урона.");
        return target.hp <= 0;
    }

    public void GetStatus()
    {
        Console.WriteLine($"{name}: {hp} HP");
    }

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {
    }
}

class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Игрок", 10, 3);
        Enemy enemy = new Enemy("Враг", 8, 2);

        Console.WriteLine($"Всего персонажей: {Character.HowMany()}");
        Console.WriteLine();
        Console.WriteLine("Бой начинается");

        while (true)
        {
            Console.WriteLine();
            bool enemyDefeated = player.Attack(enemy);
            enemy.GetStatus();

            if (enemyDefeated)
            {
                Console.WriteLine("Враг побеждён");
                Console.WriteLine("Игрок одержал победу");
                break;
            }

            Console.WriteLine();
            bool playerDefeated = enemy.Attack(player);
            player.GetStatus();

            if (playerDefeated)
            {
                Console.WriteLine("Игрок побеждён");
                Console.WriteLine("Враг одержал победу");
                break;
            }
        }
    }
}
