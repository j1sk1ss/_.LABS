using System;
using System.Collections.Generic;

namespace CS_LABS.LABS.NUM_METHODS.FIRST_LAB;

public class First : Quest {
    public First() {
        Quests = new List<Action> {
            FirstTask,
            SecondTask,
            // ThirdTask,
            // FourthTask,
            // FifesTask
        };
    }

    private void FirstTask() => Script.BisectionMethod();

    private void SecondTask() => Script.NewtonMethod();
}