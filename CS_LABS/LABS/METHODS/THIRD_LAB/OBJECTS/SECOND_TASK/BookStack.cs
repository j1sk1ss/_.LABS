using System.Collections.Generic;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

public delegate List<Book> SortType(List<Book> books, string value);

public class BookStack {
    public BookStack(List<Book> books) {
        Books = books;
    }

    private List<Book> Books { get; }
    
    public List<Book> Sort(SortType sortType, string value) => sortType.Invoke(Books, value);
}