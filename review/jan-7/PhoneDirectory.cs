using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraning.review
{
   internal class PhoneDirectory
   {
       public static void Main(string[] args)
       {
           Console.WriteLine("Welcome to Telephone Directory Enter 5 mobile no. In the Directory");

           string[,] Directory = new string[5, 3];

           for (int i = 0; i < 5; i++)
           {
               Console.WriteLine("Enter the Number ,Name and Gender of person " + (i+1) );
               for(int j=0; j<3; j++)
               {
                   Directory[i, j] = Console.ReadLine();
               }
           }

           Console.WriteLine("Data are added ");
           Console.WriteLine("Press 1 to display all the no.\n Press 2 to partially Search the no.\n Press 3 to delete the data  \n press 4 to exit" );
           int option = Convert.ToInt32(Console.ReadLine());
           while (true)
           {
               switch (option)
               {
                   case 1:
                       DisplayAttribute(Directory);
                       break;
                   case 2:
                       SearchNumber(Directory);
                       break;
                   case 3:
                       break;
                   case 4:
                       Console.WriteLine("thankyou");
                       return;
                   default :
                       Console.WriteLine("Invalid Input");
                       break;
               }
               return;
           }
       }
       static int DisplayAttribute(string[,] Directory)
       {
           for (int i = 0; i < 5; i++)
           {
               for (int j = 0; j < 3; j++)
               {
                   Console.WriteLine(Directory[i,j]);
               }
           }
           return 0;
       }
            
        
       static void SearchNumber(string[,] Directory) 
       {
           Console.WriteLine("Enter tittle to search");
           string search = Console.ReadLine();
           bool found = false;
           for (int i = 0; i< Directory.GetLength(0); i++)
           {
               string number = Directory[i, 0];
               if (number.Contains(search))
               {
                   Console.WriteLine("Number Found :" + Directory[i,0] + "of" + Directory[i,1]);
                   found = true;
               }
               if (!found)
               {
                   Console.WriteLine("Number Not Found");
               }
           }
       }

       static void DeleteNumber(string[,] Directory)
       {
           Console.WriteLine("Enter Number to Delete");
           string search = Console.ReadLine();
           bool found = false;
           for (int i = 0; i < Directory.GetLength(0); i++)
           {
               string number = Directory[i, 0];
               if (number.Contains(search))
               {
                   found = true;
                   for(int j= 0; j< Directory.GetLength(1); j++)
                   {
                       Directory[i, j] = null; 
                   }
               }
               if (!found)
               {
                   Console.WriteLine("Number Not Found");
               }
           }

       }
   }
}
