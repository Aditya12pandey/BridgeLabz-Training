using System;

class Largest{
	public static void Main(){
		Console.WriteLine("Enter the First number");
		int Num1 = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter the Second number");
		int Num2 = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine("Enter the Third number");
		int Num3 = Convert.ToInt32(Console.ReadLine());
		if( Num1>Num2 && Num1> Num3){
		Console.WriteLine("Is the first number the largest? YES \n Is the second number the largest? NO \n Is the third number the largest? NO");	
		}
		if( Num2>Num1 && Num2> Num3){
		Console.WriteLine("Is the first number the largest? NO\nIs the second number the largest? YES\nIs the third number the largest? NO");
		}
		if( Num3>Num1 && Num3> Num2){
		Console.WriteLine("Is the first number the largest? NO\nIs the second number the largest? NO\nIs the third number the largest? YES");	
		}
	
	}
	

}

