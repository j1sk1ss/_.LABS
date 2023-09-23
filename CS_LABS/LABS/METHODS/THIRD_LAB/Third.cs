using System;
using System.Collections.Generic;
using System.Linq;

using CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.FIRST_TASK;
using CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

namespace CS_LABS.LABS.METHODS.THIRD_LAB;

public class Third : Quest {
    public Third() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask
        };
    }

    /// <summary>
    /// Создать приложение, в котором генератор события после генерации
    /// первого события генерирует только определенное количество событий.
    /// Количество генераций определяется путем уведомления со стороны
    /// приемника. Для уведомления использовать второй параметр обработчика
    /// события.
    /// </summary>
    private void FirstTask() {
        var generator   = new Generator();
        var receiver    = new Receiver(5);

        generator.Event += receiver.Receive;
        generator.Generate();
    }

    /// <summary>
    /// Написать делегат, с помощью которого реализуется сортировка
    /// книг. Книга представляет собой класс с полями Название, Автор,
    /// Издательство и конструктором. Создать класс, являющийся контейнером для
    /// множества книг (массив книг). В этом классе предусмотреть метод
    /// сортировки книг. Критерий сортировки определяется экземпляром делегата,
    /// который передается методу в качестве параметра. Каждый экземпляр
    /// делегата должен сравнивать книги по какому-то одному полю: названию,
    /// автору, издательству.
    /// </summary>
    private void SecondTask() {
        var bookStack = new BookStack(new List<Book> {
            new ("1984",            "Оруэл",        "Cordell"),
            new ("Ну погоди",       "Менхаузен",    "Книга"),
            new ("Вперёд",          "Колчак",       "Сыктывкар"),
            new ("Капитализм",      "Маркс",        "Капитал"),
            new ("Восьмедисятые",   "Билл Гейтс",   "Майкрософт"),
            new ("Оренбуржье",      "Берг",         "Оренбург")
        });
 
        Console.WriteLine("\r\nAuthor sort:\n");
        bookStack.Sort(books => {
            return books.OrderBy(parameter => parameter.Author.Length).ToList();
        }).ForEach(book => book.Print());
        
        Console.WriteLine("\r\nName sort:\n");
        bookStack.Sort(books => {
            return books.OrderBy(parameter => parameter.Name.Length).ToList();
        }).ForEach(book => book.Print());
        
        Console.WriteLine("\r\nPublisher sort:\n");
        bookStack.Sort(books => {
            return books.OrderBy(parameter => parameter.Publisher.Length).ToList();
        }).ForEach(book => book.Print());
    }
    
    // Third in UI
}