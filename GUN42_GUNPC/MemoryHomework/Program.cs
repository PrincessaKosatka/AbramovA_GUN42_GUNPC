using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryHomework
{
    

    // ============================================================
    // СТРУКТУРА INTERVAL
    // ============================================================

    
    /// Структура для определения границ интервала чисел с плавающей точкой
    
    public struct Interval
    {
        // Поле для генерации случайных чисел
        private Random _random;

        // Открытые свойства
        public float Min { get; private set; }
        public float Max { get; private set; }

        
        /// Конструктор с двумя аргументами типа int
        
        public Interval(int minValue, int maxValue)
        {
            _random = new Random();

            // Проверка: если minValue больше maxValue - меняем местами
            if (minValue > maxValue)
            {
                Console.WriteLine($"Внимание! minValue ({minValue}) больше maxValue ({maxValue}). Значения автоматически поменяны местами.");
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }

            // Проверка: оба числа должны быть больше или равны 0
            if (minValue < 0)
            {
                Console.WriteLine($"Внимание! minValue ({minValue}) меньше 0. Значение заменено на 0.");
                minValue = 0;
            }

            if (maxValue < 0)
            {
                Console.WriteLine($"Внимание! maxValue ({maxValue}) меньше 0. Значение заменено на 0.");
                maxValue = 0;
            }

            // Проверка: если оба числа равны
            if (minValue == maxValue)
            {
                Console.WriteLine($"Внимание! minValue ({minValue}) равен maxValue ({maxValue}). Максимальное значение увеличено на 10.");
                maxValue += 10;
            }

            Min = minValue;
            Max = maxValue;
        }

        
        /// Возвращает случайное значение между Min и Max
        
        public float Get()
        {
            double range = Max - Min;
            double randomValue = _random.NextDouble() * range + Min;
            return (float)randomValue;
        }

        
        /// Вывод информации об интервале
        
        public void PrintInfo()
        {
            Console.WriteLine($"Интервал: [{Min:F2} - {Max:F2}]");
        }
    }

    // ============================================================
    // СТРУКТУРА ROOM
    // ============================================================

    
    /// Структура, хранящая информацию о юните и оружии
    
    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }
    }

    // ============================================================
    // КЛАСС WEAPON
    // ============================================================

    
    /// Класс оружия
    
    public class Weapon
    {
        public string Name { get; private set; }
        public Interval DamageRange { get; private set; }
        public float Durability { get; private set; }

        
        /// Конструктор только с именем
        
        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
        }

        
        /// Конструктор с именем и интервалом урона (через два int)
        
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            DamageRange = new Interval(minDamage, maxDamage);
        }

        
        /// Конструктор с именем и готовым интервалом
        
        public Weapon(string name, Interval damageRange) : this(name)
        {
            DamageRange = damageRange;
        }

        
        /// Вернуть урон (среднее арифметическое)
        
        public int GetDamage()
        {
            double average = (DamageRange.Min + DamageRange.Max) / 2.0;
            return (int)Math.Round(average);
        }

        
        /// Вернуть случайный урон
        
        public float GetRandomDamage()
        {
            return DamageRange.Get();
        }

        
        /// Вывод информации об оружии
        
        public void PrintInfo()
        {
            Console.WriteLine($"Оружие: {Name}");
            Console.WriteLine($"  Урон: [{DamageRange.Min:F2} - {DamageRange.Max:F2}]");
            Console.WriteLine($"  Средний урон: {GetDamage()}");
            Console.WriteLine($"  Прочность: {Durability}");
        }
    }

    // ============================================================
    // КЛАСС UNIT
    // ============================================================

    
    /// Класс юнита
    
    public class Unit
    {
        private float _health;
        private Random _random;

        public string Name { get; private set; }
        public float Health => _health;
        public Interval DamageRange { get; private set; }
        public float Armor { get; private set; }

        
        /// Конструктор без аргументов
        
        public Unit() : this("Unknown Unit")
        {
        }

        
        /// Конструктор только с именем
        
        public Unit(string name)
        {
            _random = new Random();
            Name = name;
            _health = 100f;
            DamageRange = new Interval(0, 5);  // Минимальное значение 0
            Armor = 0.6f;
        }

        
        /// Конструктор с именем и интервалом урона (через два int)
        
        public Unit(string name, int minDamage, int maxDamage)
        {
            _random = new Random();
            Name = name;
            _health = 100f;
            DamageRange = new Interval(minDamage, maxDamage);
            Armor = 0.6f;
        }

        
        /// Конструктор с именем и готовым интервалом
        
        public Unit(string name, Interval damageRange)
        {
            _random = new Random();
            Name = name;
            _health = 100f;
            DamageRange = damageRange;
            Armor = 0.6f;
        }

        
        /// Фактическое здоровье
        
        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        
        /// Получить урон
        
        public bool SetDamage(float value)
        {
            float damageDealt = value * Armor;
            _health -= damageDealt;
            return _health <= 0f;
        }

        
        /// Получить случайный урон
        
        public float GetRandomDamage()
        {
            return DamageRange.Get();
        }

        
        /// Вывод информации о юните
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Юнит: {Name}");
            Console.WriteLine($"  Здоровье: {Health:F2}");
            Console.WriteLine($"  Урон: [{DamageRange.Min:F2} - {DamageRange.Max:F2}]");
            Console.WriteLine($"  Броня: {Armor:F2}");
            Console.WriteLine($"  Фактическое здоровье: {GetRealHealth():F2}");
        }
    }

    // ============================================================
    // КЛАСС DUNGEON
    // ============================================================

    
    /// Класс подземелья
    
    public class Dungeon
    {
        private Room[] _rooms;

        
        /// Конструктор по умолчанию
        
        public Dungeon()
        {
            Random random = new Random();
            int roomCount = random.Next(3, 6); // от 3 до 5 комнат
            _rooms = new Room[roomCount];

            InitializeRooms();
        }

        
        /// Инициализация комнат
        
        private void InitializeRooms()
        {
            // Создаем разных юнитов
            Unit[] units = new Unit[]
            {
            new Unit("Рыцарь", 10, 25),
            new Unit("Маг", 15, 30),
            new Unit("Лучник", 8, 20),
            new Unit("Целитель", 5, 15),
            new Unit("Разбойник", 12, 28),
            new Unit("Паладин", 18, 35),
            new Unit("Некромант", 20, 40)
            };

            // Создаем разное оружие
            Weapon[] weapons = new Weapon[]
            {
            new Weapon("Двуручный меч", 15, 35),
            new Weapon("Магический посох", 10, 40),
            new Weapon("Длинный лук", 8, 30),
            new Weapon("Кинжалы", 12, 25),
            new Weapon("Боевой молот", 20, 45),
            new Weapon("Копье", 10, 28),
            new Weapon("Арбалет", 18, 32),
            new Weapon("Огненный жезл", 25, 50)
            };

            // Заполняем массив комнат
            for (int i = 0; i < _rooms.Length; i++)
            {
                // Выбираем юнита по кругу
                Unit selectedUnit = units[i % units.Length];

                // Выбираем случайное оружие
                Random rand = new Random();
                Weapon selectedWeapon = weapons[rand.Next(weapons.Length)];

                // Создаем комнату
                _rooms[i] = new Room(selectedUnit, selectedWeapon);
            }
        }

        
        /// Выводит информацию обо всех комнатах
        
        public void ShowRooms()
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("========== ОБЗОР ПОДЗЕМЕЛЬЯ ==========");
            Console.WriteLine("=========================================\n");

            for (int i = 0; i < _rooms.Length; i++)
            {
                Room room = _rooms[i];

                Console.WriteLine($"=== КОМНАТА {i + 1} ===");
                Console.WriteLine($"Unit of room: {room.Unit.Name}");
                Console.WriteLine($"Weapon of room: {room.Weapon.Name}");
                Console.WriteLine("—");
            }

            Console.WriteLine("=========================================");
            Console.WriteLine($"Всего комнат: {_rooms.Length}");
            Console.WriteLine("=========================================");
        }

        
        /// Получить массив комнат
        
        public Room[] GetRooms()
        {
            return _rooms;
        }
    }

    // ============================================================
    // ГЛАВНАЯ ПРОГРАММА
    // ============================================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ДОБРО ПОЖАЛОВАТЬ В ПОДЗЕМЕЛЬЕ ===\n");

            // Создаем экземпляр Dungeon
            Dungeon dungeon = new Dungeon();

            // Вызываем метод ShowRooms
            dungeon.ShowRooms();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
