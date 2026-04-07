using System;
class DataType
{
	static void Main()
	{
		int Number = 10;
		double price = 24.22;
		char Char = '@';
		bool Status = true;
		string Name = "Aditya";
		object Obj1 = Name;
			
			
		Console.WriteLine("is 10 is int" + (Number is int));
		Console.WriteLine(price is double);
		Console.WriteLine(Status is bool);
		Console.WriteLine(Char is char);
		Console.WriteLine(Name is string);
		Console.WriteLine(Obj1 is string);
		Console.WriteLine(Obj1 is int);
		
	}
}