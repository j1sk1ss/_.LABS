using System;
using System.Collections.Generic;

namespace CS_LABS.LABS;

public abstract class Quest {
    public void Initialization() {
        Console.Write("Select task number: ");
        
        Quests[int.TryParse(Console.ReadLine()!, out var position) switch {
            false => 0,
            _ => position
        }]();
    }
    
    protected List<Action> Quests { get; set; }
}