using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesHomeWork
{
    using System;
    
    // Я красиво для себя оформляю, потому что потом переделываю и повторяю все, легче ориентироваться
    
    public class Weapon
    {
        // ========== ОТКРЫТЫЕ СВОЙСТВА ==========

        // 1. Имя оружия (только для чтения)
        public string Name { get; private set; }

        // 2. Минимальный урон (приватный сеттер)
        public int MinDamage { get; private set; }

        // 3. Максимальный урон (приватный сеттер)
        public int MaxDamage { get; private set; }

        // 4. Прочность (только для чтения, значение 1)
        public float Durability { get; private set; }


        // ========== КОНСТРУКТОРЫ ==========

        // 1.1 Конструктор со строковым аргументом
        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;  // 4.2 Значение задаётся в конструкторе и равно 1
                              // Урон не задан, останется 0 по умолчанию
        }

        // 1.2 Конструктор с именем и двумя числами (minDamage, maxDamage)
        public Weapon(string name, int minDamage, int maxDamage)
            : this(name)  // 1.3 Вызываем конструктор с одним аргументом через this
        {
            // 1.4 Вызываем метод SetDamageParams в теле конструктора
            SetDamageParams(minDamage, maxDamage);
        }


        // ========== МЕТОДЫ ==========

        // 2. Задать параметры урона
        public void SetDamageParams(int minDamage, int maxDamage)
        {
            // 2.3 Проверка: если minDamage больше maxDamage - меняем местами
            if (minDamage > maxDamage)
            {
                Console.WriteLine($"Внимание! Для оружия '{Name}' минимальный урон ({minDamage}) больше максимального ({maxDamage}). Значения автоматически поменяны местами.");

                // Меняем местами
                int temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
            }

            // 2.4 Если minDamage меньше 1, устанавливаем значение 1
            if (minDamage < 1)
            {
                Console.WriteLine($"Внимание! Для оружия '{Name}' минимальный урон ({minDamage}) меньше 1. Принудительно установлено значение 1.");
                minDamage = 1;
            }

            // 2.5 Если maxDamage меньше или равен 1, устанавливаем значение 10
            if (maxDamage <= 1)
            {
                Console.WriteLine($"Внимание! Для оружия '{Name}' максимальный урон ({maxDamage}) меньше или равен 1. Принудительно установлено значение 10.");
                maxDamage = 10;
            }

            // Устанавливаем значения свойств
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        // 3. Вернуть урон (среднее арифметическое)
        public int GetDamage()
        {
            // 3.2 Среднее арифметическое = (MinDamage + MaxDamage) / 2
            // Используем double для точности, затем округляем до int
            double average = (MinDamage + MaxDamage) / 2.0;

            // Округляем до ближайшего целого (стандартное математическое округление)
            return (int)Math.Round(average);
        }


        // ========== ДОПОЛНИТЕЛЬНЫЙ МЕТОД ДЛЯ ПРОВЕРКИ ==========

        // Вывод информации об оружии (полезно для тестирования)
        //public void PrintInfo()
        //{
        //    Console.WriteLine($"=== Оружие: {Name} ===");
        //    Console.WriteLine($"  Урон: {MinDamage} - {MaxDamage}");
        //    Console.WriteLine($"  Средний урон: {GetDamage()}");
        //    Console.WriteLine($"  Прочность: {Durability}");
        //    Console.WriteLine();
        //}
    }
}
