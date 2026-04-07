using System;

class CourseFeeDiscount
{
    public static void Main(string []args)
    {
        int fee = 125000;
        int discountPercent = 10;

        double discount = fee * discountPercent / 100.0;
        double finalFee = fee - discount;

        Console.WriteLine("The discount amount is INR " + discount + and final discounted fee is INR " + finalFee);
    }
}
