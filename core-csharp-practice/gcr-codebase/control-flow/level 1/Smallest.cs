using System;
class Smallest 
{
	public static void Main(){
	Console.WriteLine("Enter the First number");
	int Num1 = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("Enter the Second number");
	int Num2 = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("Enter the Third number");
	int Num3 = Convert.ToInt32(Console.ReadLine());
	
	if(Num1<Num2){
		if(Num1<Num3){
		Console.WriteLine("Is the first number the smallest? YES");
	    }
		else{
		Console.WriteLine("Is the first number the smallest? NO");
		}
	}
	else{
		Console.WriteLine("Is the first number the smallest? NO");
	}
	
	
	
    }
}