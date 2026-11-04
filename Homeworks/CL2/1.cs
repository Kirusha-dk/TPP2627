using System;

class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }
    }

    public Character(string name, int hp, int power)
    {
        if (!IsValidStats(hp, power))
        {
            throw new ArgumentException(
                "Здоровье и сила удара должны быть больше нуля");
        }

        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;

        Console.WriteLine("Создан персонаж: " + name);
    }

    public virtual void Attack(Character target)
    {
        target.TakeDamage(Power);

        Console.WriteLine(Name + " атакует " + target.Name
            + " на " + Power + " урона");
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            hp = hp - damage;
        }
    }

    public bool IsAlive()
    {
        return hp > 0;
    }

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }

    public override string ToString()
    {
        return Name + " (HP: " + Hp + ")";
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (!(obj is Character))
        {
            return false;
        }

        Character a = (Character)obj;
        return Name == a.Name;
    }

    public override int GetHashCode()
    {
        if (Name == null)
        {
            return 0;
        }

        return Name.GetHashCode();
    }
}

class Player : Character
{
    public Player(string name, int hp, int power)
        : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine("Ход игрока:");
        base.Attack(target);
    }
}

class Enemy : Character
{
    public Enemy(string name, int hp, int power)
        : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine("Ход врага:");
        base.Attack(target);
    }
}

class Program
{
    static void Main()
    {
        Character a = new Player("Игрок", 10, 3);
        Character b = new Enemy("Враг", 8, 2);

        Console.WriteLine("Всего персонажей: " + Character.HowMany());
        Console.WriteLine();
        Console.WriteLine("Бой начинается!");

        while (a.IsAlive() && b.IsAlive())
        {
            Console.WriteLine();
            a.Attack(b);
            Console.WriteLine(b);

            if (!b.IsAlive())
            {
                Console.WriteLine("Игрок победил!");
                break;
            }

            Console.WriteLine();
            b.Attack(a);
            Console.WriteLine(a);

            if (!a.IsAlive())
            {
                Console.WriteLine("Враг победил!");
                break;
            }
        }
    }
}
