// Задание 1
int a = 0, b = 1;
for (int i = 0; i < 10; i++)

{
    Console.WriteLine(a);
    int c = a + b;
    a = b;
    b = c;

}
Console.WriteLine();

// Задание 2


for (int i = 2; i <= 20; i++)

{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}
Console.WriteLine();

// Задание 3 

for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= 10; j++)
    {
        int f = i * j;
        Console.Write(f + " ");
    }

    Console.WriteLine();

}

Console.WriteLine();

// Задание 4

string password = "qwerty";
string EnteredPassword = "";
do
{
    EnteredPassword = Console.ReadLine();
    Console.WriteLine("Неверный пароль");
}
while (EnteredPassword != password);

Console.WriteLine("Правильный пароль! Вы молодец");
       