class Remainder{
	public static void Main(){
		int number1=int.Parse(Console.ReadLine());
		int number2=int.Parse(Console.ReadLine());
		int quotient=number1/number2;
		int remainder=number1%number2;
		Console.WriteLine("The Quotient is "+quotient+" and Remainder is "+remainder+" of two numbers "+number1+" and "+number2);
	}
}
