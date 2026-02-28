class Programm
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number");
        if (!Int32.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Not a number!");
            return;
        }

        Console.WriteLine("Enter second number");
        if (!Int32.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Not a number!");
            return;
        }
        
        Console.WriteLine("Enter operator");
        var s = Console.ReadLine();
        var boolvar = true;
        if (s.Length == 0 || s.Length > 1 && !boolvar)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        switch (s[0])
        { 
            case '+':
                Console.WriteLine("Result of {0} + {1} = {2}", a, b, a + b);
                break;
            case '-':
                Console.WriteLine("Result of {0} - {1} = {2}", a, b, a - b);
                break;
            case '*':
                Console.WriteLine("Result of {0} * {1} = {2}", a, b, a * b);
                break;
            case '/':
                Console.WriteLine("Result of {0} / {1} = {2}", a, b, a / b);
                break;
            case '&':
                Console.WriteLine("Result of {0} & {1} = {2}", a, b, a & b);
                Console.Write("Result in Binary system = "); 
                Console.WriteLine(Convert.ToString(a & b, 2));
                Console.Write("Result in Hex system = ");
                Console.WriteLine(Convert.ToString(a & b, 16));
                break;
            case '|':
                Console.WriteLine("Result of {0} | {1} = {2}", a, b, a | b);
                Console.Write("Result in Binary system = ");
                Console.WriteLine(Convert.ToString(a | b, 2));
                Console.Write("Result in Hex system = ");
                Console.WriteLine(Convert.ToString(a | b, 16));
                break;
            case '^':
                Console.WriteLine("Result of {0} ^ {1} = {2}", a, b, a ^ b);
                Console.Write("Result in Binary system = ");
                Console.WriteLine(Convert.ToString(a ^ b, 2));
                Console.Write("Result in Hex system = ");
                Console.WriteLine(Convert.ToString(a ^ b, 16));
                break;
            default:
                Console.WriteLine("Wrong sign");
                break;
        }
    }
}