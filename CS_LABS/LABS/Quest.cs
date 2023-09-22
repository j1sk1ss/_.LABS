using System;
using System.Collections.Generic;

namespace CS_LABS.LABS;

public abstract class Quest {
    public void Initialization() {
        while (true) {
            Console.Write("\r\nSelect task number between 0 and {0}: ", Quests.Count - 1);
            var answer = Console.ReadLine()!.ToLower();

            if (answer == "exit") break;
            
            Quests[int.TryParse(answer, out var position) switch {
                false   => 0,
                _       => position
            }]();   
        }
    }
    
    protected List<Action> Quests { get; init; }
}