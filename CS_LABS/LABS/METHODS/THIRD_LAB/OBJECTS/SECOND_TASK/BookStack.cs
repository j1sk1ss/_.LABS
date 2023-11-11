using System;
using System.Collections.Generic;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

public class BookStack {
    public BookStack(List<Book> books) => Books = books;
    
    public List<Book> Books { get; }

    public void PrintBookStack() {
        foreach (var book in Books) 
            Console.WriteLine("Name: {0} | Author: {1} | Publisher: {2}", book.Name, book.Author, book.Publisher);
    }
}