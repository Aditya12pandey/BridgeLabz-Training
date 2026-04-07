using System;

public class FeeDiscount
{
    public static void Main(string[] args)
    {
        double fee;
        double discountPercent;

        // Take user input
        Console.Write("Enter the student fee: ");
        fee = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the discount percentage: ");
        discountPercent = Convert.ToDouble(Console.ReadLine());

        // Calculate discount
        double discount = fee * discountPercent / 100;
        double finalFee = fee - discount;

        Console.WriteLine("The discount amount is INR " + discount +" and final discounted fee is INR " + finalFee);
    }
}
