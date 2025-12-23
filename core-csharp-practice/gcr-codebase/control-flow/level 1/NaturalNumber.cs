using System;
class NaturalNumber{
	public static void Main(){
		Console.WriteLine("Enter number");
		int Num = Convert.ToInt32(Console.ReadLine());
		if(Num>0){
			Console.WriteLine("The sum of "+ Num +" natural numbers is " +  Num * (Num+1) / 2 );
		}
		else{
		Console.WriteLine("The number "+ Num +"is not a natural number");
		}
	}

}