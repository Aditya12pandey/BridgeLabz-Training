class DoubleOper{
	public static void Main(){
		double a=double.Parse(Console.ReadLine());
		double b=double.Parse(Console.ReadLine());
		double c=double.Parse(Console.ReadLine());
		double r1=a+b*c;
		double r2=a*b+c;
		double r3=c+a/b;
		double r4=a%b+c;
		Console.WriteLine("The results of Double Operations are "+r1+", "+r2+", "+r3+", and "+r4);
	}
}
