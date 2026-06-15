using System.Text;

Console.WriteLine("Hello, World!");

// Задание 1
public static string ConcatenateStrings(string str1, string str2)
{
    return str1 + str2;
}

// Задание 2
public static string GreetUser(string name, int age)
{
    return $"\nHello, {name}! You are {age} years old!";
}

// Задание 3
public static string StringInfo(string input)
{
    if (input == null) input = ""; // Предпочту добавить проверку
    

    int lenght = input.Length;
    string top = input.ToUpper();
    string low = input.ToLower();

    return $"\n Кол-во символов {lenght} \n Строка в верхнем регистре {top}, \n Строка в нижнем регистре {low}";
}

// Задание 4
public static string FirstFiveSymbols(string input)
{
    return input.Substring(0, 5);

}

// Задание 5

public static StringBuilder JoinStringsWithSpaces(string[] words)
{
    if (words == null)
        return new StringBuilder();

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < words.Length; i++)
    {
        sb.Append(words[i]);

        if (i < words.Length - 1)
            sb.Append(' ');
    }

    return sb;
}

// Задание 5

public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
{
    return inputString.Replace(wordToReplace, replacementWord);
}
