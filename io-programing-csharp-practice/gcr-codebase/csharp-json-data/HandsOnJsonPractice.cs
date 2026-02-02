using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonPractice
{
    class HandsOnJsonPractice
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1️ read JSON and print keys/values");
            string jsonText = @"{ 'name':'Amit', 'age':30, 'email':'amit@gmail.com' }";
            JObject jsonObj = JObject.Parse(jsonText);

            foreach (var prop in jsonObj.Properties())
            {
                Console.WriteLine($"{prop.Name} : {prop.Value}");
            }

            Console.WriteLine("\n2️List to JSON Array");
            List<User> users = new List<User>
            {
                new User { Id=1, Name="A", Age=20, Email="a@test.com" },
                new User { Id=2, Name="B", Age=28, Email="b@test.com" }
            };

            string usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(usersJson);

            Console.WriteLine("\n3️Users older than 25");
            JArray userArray = JArray.Parse(usersJson);

            var filtered = userArray
                .Where(u => (int)u["Age"] > 25);

            foreach (var u in filtered)
            {
                Console.WriteLine(u);
            }

            Console.WriteLine("\n4️Email Validation using JSON Schema");
            string emailSchemaJson = @"
            {
              'type':'object',
              'properties':{
                'email':{
                  'type':'string',
                  'format':'email'
                }
              },
              'required':['email']
            }";

            JSchema emailSchema = JSchema.Parse(emailSchemaJson);
            JObject emailData = JObject.Parse(@"{ 'email':'test@gmail.com' }");

            bool valid = emailData.IsValid(emailSchema, out IList<string> errors);
            Console.WriteLine(valid ? "Valid Email" : string.Join(", ", errors));

            Console.WriteLine("\n5 Merge JSON Objects");
            JObject json1 = JObject.Parse(@"{ 'name':'Ravi', 'age':26 }");
            JObject json2 = JObject.Parse(@"{ 'email':'ravi@gmail.com', 'city':'Pune' }");

            json1.Merge(json2);
            Console.WriteLine(json1.ToString());

            Console.WriteLine("\n6️JSON to XML");
            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json1.ToString(), "User");
            Console.WriteLine(xmlDoc.OuterXml);

            Console.WriteLine("\n7️CSV to JSON");
            string csv = "Id,Name,Age\n1,Alice,24\n2,Bob,30";
            string[] lines = csv.Split('\n');

            List<Dictionary<string, string>> csvData = new List<Dictionary<string, string>>();
            string[] headers = lines[0].Split(',');

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                var obj = new Dictionary<string, string>();

                for (int j = 0; j < headers.Length; j++)
                {
                    obj[headers[j]] = values[j];
                }
                csvData.Add(obj);
            }

            Console.WriteLine(JsonConvert.SerializeObject(csvData, Formatting.Indented));

            Console.WriteLine("\n8️ JSON Report from Database (Example)");

            /*
             * Example logic (replace connection string & query)
             */
            List<User> dbUsers = new List<User>
            {
                new User { Id=1, Name="DB_User1", Age=35, Email="db1@test.com" },
                new User { Id=2, Name="DB_User2", Age=29, Email="db2@test.com" }
            };

            string dbReportJson = JsonConvert.SerializeObject(dbUsers, Formatting.Indented);
            Console.WriteLine(dbReportJson);
        }
    }

    // Supporting Model
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
