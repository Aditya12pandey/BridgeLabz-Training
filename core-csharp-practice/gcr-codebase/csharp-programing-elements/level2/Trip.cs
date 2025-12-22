class Trip{
	public static void Main(){
	
		string name=Console.ReadLine();
		string fromCity=Console.ReadLine();
		string viaCity=Console.ReadLine();
		string toCity=Console.ReadLine();
		
		double fromToVia=double.Parse(Console.ReadLine());
		double viaToFinalCity=double.Parse(Console.ReadLine());
		double timeTaken=double.Parse(Console.ReadLine());
		double totalDistance=fromToVia+viaToFinalCity;
		
		double speed=totalDistance/timeTaken;
		
		Console.WriteLine("The results of the trip are "+totalDistance+", "+timeTaken+", and "+speed);
	}
}
