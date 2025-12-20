using System;

class AccessModifiers
{
    // Public Access Modifier
	public int a = 5;
	
	// Private Access Modifier
	private int n1 = 10;
	
	// Protected Access Modifier
	protected int n2 = 20;								

	// Internal Access Modifier
	internal int n3 = 100;	
	
	// Protected Internal Access Modifier
	protected internal int n4 = 123;						


	static void Main()
	{
		PublicModifier bam = new PublicModifier();
		bam.Hello();
		
		AccessModifiers mam = new AccessModifiers();
		mam.showPrivate();

		DerivedAccessModifiers dam = new DerivedAccessModifiers();
		dam.deriveAccess();

	}

	public void showPrivate()
	{
		Console.WriteLine("Private Value is: " + n1);
	}
	
	

}

class PublicModifier
{
	public void Hello()
	{
		AccessModifiers am = new AccessModifiers();
		Console.WriteLine("Public value is: "+am.a);
		Console.WriteLine("Internal value is: "+am.n3);
		
	}
}

class DerivedAccessModifiers : AccessModifiers
{
	public void deriveAccess()
	{
		
		Console.WriteLine("Public Value In Derived Class" + a);
		Console.WriteLine("Internal Value In Derived Class" + n3);
		Console.WriteLine("ProtectedValue In Derived Class" + n2);
		Console.WriteLine("protected internal Value In Derived Class" + n4);
		Console.WriteLine("private protected Value In Derived Class" + n3);
	}
}