using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

struct Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public float Height { get; set; }
    public string EyeColor { get; set; }
}

class Program
{
    private const string FilePath = "people.json";

    static void Main()
    {
        List<Person> people = new List<Person>();

        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            people = JsonSerializer.Deserialize<List<Person>>(json);
        }

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a person");
            Console.WriteLine("2. Display people");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Person person = new Person();

                    Console.Write("Name: ");
                    person.Name = Console.ReadLine();

                    Console.Write("ID: ");
                    person.Id = int.Parse(Console.ReadLine());

                    Console.Write("Height: ");
                    person.Height = float.Parse(Console.ReadLine());

                    Console.Write("Eye Color: ");
                    person.EyeColor = Console.ReadLine();

                    people.Add(person);

                    string json = JsonSerializer.Serialize(people);
                    File.WriteAllText(FilePath, json);

                    Console.WriteLine("Person added successfully");
                    break;

                case "2":
                    foreach (Person p in people)
                    {
                        Console.WriteLine($"Name: {p.Name}");
                        Console.WriteLine($"ID: {p.Id}");
                        Console.WriteLine($"Height: {p.Height}");
                        Console.WriteLine($"Eye Color: {p.EyeColor}");
                        Console.WriteLine();
                    }
                    break;

                case "3":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
            }
        }
    }
}
