using System;

namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.FIRST_TASK;

public class Receiver {
    public Receiver(int answerCount) {
        AnswerCount = answerCount;
    }
    
    private int AnswerCount { get; set; }
    
    public void Receive(string message, out int answer) {
        Console.WriteLine(message);
        answer = AnswerCount;
    }
}