using System;
class Divisibility{
	public static void Main(){
		int Number = int.Parse(Console.ReadLine());
		if(Number%5==0){
		Console.WriteLine(" Is the number "+ Number +" divisible by 5? Yes");
		}
		else{
		Console.WriteLine(" Is the number "+ Number +" divisible by 5? No");
		}
	}
}