class Chocolates{
	public static void Main(){
		int numberOfChocolates=int.Parse(Console.ReadLine());
		int numberOfChildren=int.Parse(Console.ReadLine());
		int each=numberOfChocolates/numberOfChildren;
		int remaining=numberOfChocolates%numberOfChildren;
		Console.WriteLine("The number of chocolates each child gets is "+each+" and the number of remaining chocolates is "+remaining);
	}
}
