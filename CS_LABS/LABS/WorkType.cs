using System;
using System.Collections.Generic;

namespace CS_LABS.LABS;

public class WorkType {
    public WorkType(List<Quest> tasks) {
        Tasks = tasks;
    }

    private List<Quest> Tasks { get; set; }

    public void Initialize() {
        Console.Write("Choose a Lab: ");
        Tasks[int.Parse(Console.ReadLine()!)].Initialization();
    }
}