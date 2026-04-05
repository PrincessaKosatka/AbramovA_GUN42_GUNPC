using System;
using System.Collections.Generic;
using System.Text;




public class Unit
{
    // Приватные поля
    private float _health;

    // Открытые свойства
    public string Name { get; private set; } // 1.1, 1.2
    public float Health => _health; // 2.1, 2.2
    public int Damage { get; private set; } // 3.1, 3.2
    public float Armor { get; private set; } // 4.1, 4.2

    // 1.1 Конструктор без аргумента (вызывает конструктор с аргументом через this)
    public Unit() : this("Unknown Unit")
    {
    }

    // 1.2 Конструктор со строковым аргументом
    public Unit(string name)
    {
        Name = name;
        _health = 100f;
        Damage = 5; // 3.2
        Armor = 0.6f; // 4.2
    }

    // 2. Фактическое здоровье
    public float GetRealHealth()
    {
        return Health * (1f + Armor);
    }

    // 3. Получить урон
    public bool SetDamage(float value)
    {
        
        float damageDealt = value * Armor;
        _health -= damageDealt;

        
        return _health <= 0f;
    }

}
