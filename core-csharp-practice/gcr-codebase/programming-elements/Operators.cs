using System;

class Operators
{
    static void Main()
    {
        int a = 10, b = 5;

        //Arithmetic Operators
        Console.WriteLine("Arithmetic Operators:");
        Console.WriteLine("a + b = " + (a + b));
        Console.WriteLine("a - b = " + (a - b));
        Console.WriteLine("a * b = " + (a * b));
        Console.WriteLine("a / b = " + (a / b));
        Console.WriteLine("a % b = " + (a % b));

        //elational (Comparison) Operators
        Console.WriteLine("\nRelational Operators:");
        Console.WriteLine("a == b : " + (a == b));
        Console.WriteLine("a != b : " + (a != b));
        Console.WriteLine("a > b  : " + (a > b));
        Console.WriteLine("a < b  : " + (a < b));
        Console.WriteLine("a >= b : " + (a >= b));
        Console.WriteLine("a <= b : " + (a <= b));

        //Logical Operators
        bool x = true, y = false;
        Console.WriteLine("\nLogical Operators:");
        Console.WriteLine("x && y : " + (x && y));
        Console.WriteLine("x || y : " + (x || y));
        Console.WriteLine("!x     : " + (!x));

        //assignment Operators
        Console.WriteLine("\nAssignment Operators:");
        int c = 10;
        c += 5;
        Console.WriteLine("c += 5 : " + c);
        c -= 3;
        Console.WriteLine("c -= 3 : " + c);
        c *= 2;
        Console.WriteLine("c *= 2 : " + c);
        c /= 4;
        Console.WriteLine("c /= 4 : " + c);

        //Unary Operators
        Console.WriteLine("\nUnary Operators:");
        int d = 8;
        Console.WriteLine("d++ = " + (d++));
        Console.WriteLine("++d = " + (++d));
        Console.WriteLine("d-- = " + (d--));
        Console.WriteLine("--d = " + (--d));

        //Bitwise Operators
        int m = 6, n = 3;
        Console.WriteLine("\nBitwise Operators:");
        Console.WriteLine("m & n = " + (m & n));
        Console.WriteLine("m | n = " + (m | n));
        Console.WriteLine("m ^ n = " + (m ^ n));
        Console.WriteLine("~m    = " + (~m));
        Console.WriteLine("m << 1 = " + (m << 1));
        Console.WriteLine("m >> 1 = " + (m >> 1));

        //Conditional (Ternary) Operator
        Console.WriteLine("\nConditional Operator:");
        string result = (a > b) ? "a is greater" : "b is greater";
        Console.WriteLine(result);

        //Type Casting Operator
        Console.WriteLine("\nType Casting:");
        double num = 9.78;
        int num2 = (int)num;
        Console.WriteLine("Double to Int: " + num2);

    }
}
