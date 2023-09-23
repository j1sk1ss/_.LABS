using System.Collections.Generic;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

public class BookStack {
    public BookStack(List<Book> books) => Books = books;
    
    private List<Book> Books { get; }
    
    public delegate List<Book> SortType(List<Book> books);
    
    public List<Book> Sort(SortType sortType) => sortType.Invoke(Books);
}