class Income{
	public static void Main(){
		int salary=int.Parse(Console.ReadLine());
		int bonus=int.Parse(Console.ReadLine());
		int income=salary+bonus;
		Console.WriteLine("The salary is INR "+salary+" and bonus is INR "+bonus+". Hence Total Income is INR "+income);
	}
}
