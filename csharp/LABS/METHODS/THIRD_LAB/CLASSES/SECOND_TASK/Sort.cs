using System;
using System.Collections.Generic;
using CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.SECOND_TASK;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.CLASSES.SECOND_TASK;

public static class Sort {
    public static BookStack ClassicSort(this BookStack books, Func<Book, int> keySelector) {
        var list = new List<Book>(books.Books);
        
        for (var j = 0; j < list.Count; j++) 
            for (var i = 1; i < list.Count; i++) 
                if (keySelector.Invoke(list[i]) < keySelector.Invoke(list[i - 1])) 
                    (list[i], list[i - 1]) = (list[i - 1], list[i]);
        
        return new BookStack(list);
    }
}