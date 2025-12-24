using System;
class YoungestAndTallest{
	public static void Main(){
		String[] Names ={"aman" ,"rahul" , "saket"};	
		int[] Age = new int[3];
		int[] Height = new int[3];
		// input for age and height 
		for(int i=0;i<3;i++){
			Console.WriteLine("enter age for "+ Names[i]);
			Age[i]= Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("enter height for "+Names[i]);
			Height[i] = Convert.ToInt32(Console.ReadLine());
		}
		int young = 0;
		int tall = 0;
		
		for(int i=1 ;i <(3); i++ ){
			if(Age[i] < Age[young]){
				young = i;
			} 
			if(Height[i] > Height[tall]){
				tall = i;
			} 
		}
		Console.WriteLine("The youngest is " + Names[young]);
		Console.WriteLine("The Tallest is "+ Names[tall]);
		
	}
}