using System; 
class Voting{
	public static void Main()
	{
		int[] arr = new int[10];
		for(int i=0;i<10;i++){
			arr[i] = Convert.ToInt32(Console.ReadLine());
			if(arr[i] < 0){
				Console.WriteLine(" Invalid Age");
			}
			if(arr[i] >= 18){
				Console.WriteLine(" The student with the age "+ arr[i]+" can vote");
			}
			else{
				Console.WriteLine("The Student cannot vote");
			}
		}
	}
}