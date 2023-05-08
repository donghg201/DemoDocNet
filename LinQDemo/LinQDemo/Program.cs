using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace LinQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = ReadPeopleFromJsonFile();

            //Get the first element
            var firstPerson = people.First();
            Console.WriteLine(firstPerson);
            var lastPerson = people.Last();
            Console.WriteLine(lastPerson);
        }

        static Person[] ReadPeopleFromJsonFile()
        {
            using (var reader = new StreamReader("people.json"))
            {
                string jsonData = reader.ReadToEnd();
                var people = JsonConvert.DeserializeObject<Person[]>(jsonData);
                return people;
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City  { get; set; }
        public decimal Salary  { get; set; }
        public DateTime Birthdate  { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} | {City} | {Birthdate.ToShortDateString()} | ${Salary}";
        }
    }
}
