using System;
using System.Collections;

class WarningSuppression
{
    static void Main()
    {
#pragma warning disable 0618, 0168, 0219
        // Using non-generic ArrayList (can cause warnings in modern C#)
        ArrayList list = new ArrayList();

        list.Add(10);          // int
        list.Add("Hello");     // string
        list.Add(3.14);        // double
#pragma warning restore 0618, 0168, 0219

        // Accessing values (unchecked operations)
        foreach (object item in list)
        {
            Console.WriteLine(item);
        }
    }
}
