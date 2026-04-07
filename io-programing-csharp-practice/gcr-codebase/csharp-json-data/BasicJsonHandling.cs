using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonHandling
{
    class BasicJsonHandling
    {
        static void Main(string[] args)
        {
            var studentObj = new
            {
                name = "Aditya",
                age = 22,
                subjects = new[] { "Math", "Physics", "CS" }
            };

            string studentJson = JsonConvert.SerializeObject(studentObj, Formatting.Indented);
            Console.WriteLine("1️⃣ Student JSON:");
            Console.WriteLine(studentJson);

            Car car = new Car { Brand = "Tesla", Year = 2024 };
            string carJson = JsonConvert.SerializeObject(car, Formatting.Indented);
            Console.WriteLine("\n2️⃣ Car JSON:");
            Console.WriteLine(carJson);

            string userJson = @"{ 'name':'Rahul', 'email':'rahul@gmail.com', 'age':30 }";
            JObject userObj = JObject.Parse(userJson);
            Console.WriteLine("\n3️⃣ Extracted Fields:");
            Console.WriteLine($"{userObj["name"]} - {userObj["email"]}");

            JObject obj1 = JObject.Parse(@"{ 'name':'Amit', 'age':25 }");
            JObject obj2 = JObject.Parse(@"{ 'email':'amit@gmail.com', 'city':'Delhi' }");
            obj1.Merge(obj2);
            Console.WriteLine("\n4️⃣ Merged JSON:");
            Console.WriteLine(obj1.ToString());

            string schemaJson = @"
            {
              'type':'object',
              'properties':{
                'name':{'type':'string'},
                'age':{'type':'integer'}
              },
              'required':['name','age']
            }";

            JSchema schema = JSchema.Parse(schemaJson);
            JObject dataToValidate = JObject.Parse(@"{ 'name':'Riya', 'age':21 }");

            bool isValid = dataToValidate.IsValid(schema, out IList<string> errors);
            Console.WriteLine("\n5️⃣ Schema Validation:");
            Console.WriteLine(isValid ? "Valid JSON" : string.Join(", ", errors));

            List<Student> students = new List<Student>
            {
                new Student { Name = "A", Age = 20 },
                new Student { Name = "B", Age = 28 }
            };

            string studentsJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            Console.WriteLine("\n6️⃣ Students JSON Array:");
            Console.WriteLine(studentsJson);

            JArray studentArray = JArray.Parse(studentsJson);
            var filtered = studentArray
                .Where(x => (int)x["Age"] > 25)
                .ToList();

            Console.WriteLine("\n7️⃣ Filtered (Age > 25):");
            Console.WriteLine(JsonConvert.SerializeObject(filtered, Formatting.Indented));
        }
    }

    // Supporting Classes
    class Car
    {
        public string Brand { get; set; }
        public int Year { get; set; }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
