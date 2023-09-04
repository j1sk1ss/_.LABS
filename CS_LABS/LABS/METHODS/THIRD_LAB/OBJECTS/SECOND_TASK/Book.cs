using System;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

public class Book {
    public Book(string name, string author, string publisher) {
        Name = name;
        Author = author;
        Publisher = publisher;
    }
    
    public string Name { get; }
    public string Author { get; }
    public string Publisher { get; }

    public void Print() =>
        Console.WriteLine($"Name: {Name} | Author: {Author} | Publisher: {Publisher}");
}