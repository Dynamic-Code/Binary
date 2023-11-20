
using System;
using System.IO;
using System.Text.Json;

[Serializable]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Serialization
        var person = new Person { Name = "Abhinav kumar", Age = 30 };
        byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(person);

        using (Stream stream = new FileStream("person.json", FileMode.Create, FileAccess.Write))
        {
            stream.Write(jsonBytes, 0, jsonBytes.Length);
        }

        // Deserialization
        using (Stream stream = new FileStream("person.json", FileMode.Open, FileAccess.Read))
        {
            byte[] readBytes = new byte[stream.Length];
            stream.Read(readBytes, 0, (int)stream.Length);

            var deserializedPerson = JsonSerializer.Deserialize<Person>(readBytes);
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }
    }
}