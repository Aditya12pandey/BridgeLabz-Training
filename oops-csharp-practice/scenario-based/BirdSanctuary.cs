//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace BridgeLabzTraning.ScenarioBased
//{
//    interface IFlyable
//    {
//        void Fly();
//    }
//    interface ISwimable
//    {
//        void Swim();
//    }
//    class Bird
//    {
//        public string Name;
//        public Bird(string name)
//        {
//            this.Name = name;
//        }
//        public void DisplayInformation()
//        {
//            Console.WriteLine("Bird Name : "+ Name);
//        }
//    }
//    class Eagle : Bird, IFlyable
//    { 
//        public Eagle(string name) : base(name)
//        {
//            //calling base class constructor
//        }
//        public void Fly()
//        {
//            Console.WriteLine("Eagle flies very high ");
//        }

//    }
//    class Seagull : Bird, IFlyable, ISwimable
//    {
//        public Seagull(string name ) : base(name)
//        {
//            //calling base class constructor
//        }
//        public void Fly()
//        {
//            Console.WriteLine("Seagull can fly ");
//        }
//        public void Swim()
//        {
//            Console.WriteLine("Seagull are a good Swimmer");
//        }
//    }
//    class Sparrow : Bird, IFlyable
//    {
//        public Sparrow(string name) : base(name)
//        {
//            //calling base class constructor
//        }
//        public void Fly()
//        {
//            Console.WriteLine("Sparrow can fly");
//        }
//    }
//    class Penguin : Bird, ISwimable
//    {
//        public Penguin(string name) : base(name)
//        {
//            //calling base class constructor
//        }
//        public void Swim()
//        {
//            Console.WriteLine("penguin can swim");
//        }
//    }
//    class Duck : Bird, ISwimable
//    {
//        public Duck(string name) : base(name)
//        {
//            //calling base class constructor
//        }
//        public void Swim()
//        {
//            Console.WriteLine("Duck can fly very short also, It can swim");
//        }
//    }



//    internal class BirdSanctuary
//    {
//        public static void Main(string[] args)
//        {
//            Bird[] birds = new Bird[] {

//            new Eagle("Eagle"),
//            new Sparrow("Sparrow"),
//            new Duck("Duck"),
//            new Penguin("Penguin"),
//            new Seagull("Seagull")

//            };
           

//            foreach(Bird bird in birds) 
//            {
//                bird.DisplayInformation();
//                if(bird is IFlyable) 
//                { 
//                    ((IFlyable)bird).Fly();
//                }
//                if (bird is ISwimable)
//                {
//                    ((ISwimable)bird).Swim();
//                }
//            }
//        }
//    }
//}
