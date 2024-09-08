using System;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.FIRST_TASK;

public class Receiver {
    public Receiver(int answerCount) => AnswerCount = answerCount;
    
    private int AnswerCount { get; }
    
    public int Receive(string message) {
        Console.WriteLine(message, AnswerCount);
        return AnswerCount;
    }
}