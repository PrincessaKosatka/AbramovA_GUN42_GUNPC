using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В ПОДЗЕМЕЛЬЕ ===\n");

        // Создаем экземпляр Dungeon
        Dungeon dungeon = new Dungeon();

        Console.WriteLine("\nНажмите любую клавишу для просмотра комнат...");
        Console.ReadKey();
        Console.Clear();

        // Вызываем метод ShowRooms
        dungeon.ShowRooms();

        // Дополнительно: демонстрация работы Interval и случайного урона
        Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ СЛУЧАЙНОГО УРОНА ===");

        Room[] rooms = dungeon.GetRooms();
        if (rooms.Length > 0)
        {
            Room firstRoom = rooms[0];
            Console.WriteLine($"\nТестируем урон юнита {firstRoom.Unit.Name}:");
            for (int i = 0; i < 5; i++)
            {
                float damage = firstRoom.Unit.GetRandomDamage();
                Console.WriteLine($"  Удар {i + 1}: {damage:F2} урона");
            }

            Console.WriteLine($"\nТестируем урон оружия {firstRoom.Weapon.Name}:");
            for (int i = 0; i < 5; i++)
            {
                float damage = firstRoom.Weapon.GetRandomDamage();
                Console.WriteLine($"  Удар {i + 1}: {damage:F2} урона");
            }
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}