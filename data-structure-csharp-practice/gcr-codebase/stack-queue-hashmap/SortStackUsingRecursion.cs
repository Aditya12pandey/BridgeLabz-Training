using System;
using System.Collections.Generic;

class SortStackUsingRecursion
{
    // Method to sort the stack
    public static void SortStack(Stack<int> stack)
    {
        if (stack.Count == 0)
            return;

        int top = stack.Pop();
        SortStack(stack);
        InsertInSortedOrder(stack, top);
    }

    // Method to insert element in sorted order
    private static void InsertInSortedOrder(Stack<int> stack, int element)
    {
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
            return;
        }

        int top = stack.Pop();
        InsertInSortedOrder(stack, element);
        stack.Push(top);
    }
}
