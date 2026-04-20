using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesHomeWork
{
    
    
    /// Класс, инкапсулирующий логику работы подземелья
    
    public class Dungeon
    {
        // ========== ПОЛЯ ==========
        private Room[] _rooms;

        // ========== КОНСТРУКТОРЫ ==========
        
        /// Конструктор по умолчанию
        
        public Dungeon()
        {
            // Инициализируем массив случайным размером от 3 до 5 элементов
            Random random = new Random();
            int roomCount = random.Next(3, 6); // 3, 4 или 5
            _rooms = new Room[roomCount];

            // Инициализируем комнаты
            InitializeRooms();
        }

        // ========== ПРИВАТНЫЕ МЕТОДЫ ==========

        
        /// Инициализация комнат разными юнитами и оружием
        
        private void InitializeRooms()
        {
            // Создаем разных юнитов
            Unit[] units = new Unit[]
            {
            new Unit("Рыцарь", new Interval(10, 25)),      // Урон 10-25
            new Unit("Маг", new Interval(15, 30)),         // Урон 15-30
            new Unit("Лучник", new Interval(8, 20)),       // Урон 8-20
            new Unit("Целитель", new Interval(5, 15)),     // Урон 5-15
            new Unit("Разбойник", new Interval(12, 28))    // Урон 12-28
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
            new Weapon("Арбалет", 18, 32)
            };

            // Заполняем массив комнат
            for (int i = 0; i < _rooms.Length; i++)
            {
                // Выбираем юнита по кругу (если юнитов меньше, чем комнат)
                Unit selectedUnit = units[i % units.Length];

                // Выбираем случайное оружие
                Random rand = new Random();
                Weapon selectedWeapon = weapons[rand.Next(weapons.Length)];

                // Создаем комнату
                _rooms[i] = new Room(selectedUnit, selectedWeapon);

                // Выводим информацию о создании (для отладки)
                Console.WriteLine($"Создана комната {i + 1}: {selectedUnit.Name} с оружием {selectedWeapon.Name}");
            }

            Console.WriteLine($"\nВсего создано комнат: {_rooms.Length}\n");
        }

        // ========== ПУБЛИЧНЫЕ МЕТОДЫ ==========

        /// <summary>
        /// Выводит информацию обо всех комнатах
        /// </summary>
        public void ShowRooms()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("========== ОБЗОР ПОДЗЕМЕЛЬЯ ==========");
            Console.WriteLine("=========================================\n");

            for (int i = 0; i < _rooms.Length; i++)
            {
                Room room = _rooms[i];

                Console.WriteLine($"=== КОМНАТА {i + 1} ===");
                Console.WriteLine($"Юнит: {room.Unit.Name}");
                Console.WriteLine($"  - Здоровье: {room.Unit.Health:F2}");
                Console.WriteLine($"  - Урон: [{room.Unit.DamageRange.Min:F2} - {room.Unit.DamageRange.Max:F2}]");
                Console.WriteLine($"  - Броня: {room.Unit.Armor:F2}");
                Console.WriteLine();
                Console.WriteLine($"Оружие: {room.Weapon.Name}");
                Console.WriteLine($"  - Урон: [{room.Weapon.DamageRange.Min:F2} - {room.Weapon.DamageRange.Max:F2}]");
                Console.WriteLine($"  - Средний урон: {room.Weapon.GetDamage()}");
                Console.WriteLine($"  - Прочность: {room.Weapon.Durability}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine();
            }

            Console.WriteLine("=========================================");
            Console.WriteLine($"Всего комнат: {_rooms.Length}");
            Console.WriteLine("=========================================");
        }

        /// <summary>
        /// Получить массив комнат (для внешнего использования)
        /// </summary>
        public Room[] GetRooms()
        {
            return _rooms;
        }
    }
}
