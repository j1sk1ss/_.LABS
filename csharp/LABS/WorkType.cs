using System;
using System.Collections.Generic;

namespace CS_LABS.LABS;

public class WorkType {
    public WorkType(List<Quest> tasks) => Tasks = tasks;
    
    private List<Quest> Tasks { get; }

    public void Initialize() {
        while (true) {
            Console.Write("\r\nChoose a Lab between 0 and {0}: ", Tasks.Count - 1);
            Tasks[int.TryParse(Console.ReadLine()!, out var position) switch {
                false   => 0,
                _       => position
            }].Initialization();
        }
    }
}