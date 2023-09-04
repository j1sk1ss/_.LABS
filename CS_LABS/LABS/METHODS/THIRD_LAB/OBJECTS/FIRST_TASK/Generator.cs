namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.FIRST_TASK;

public class Generator {
    public delegate void AccountHandler(string message, out int answer);

    public event AccountHandler Event;

    public void Generate() {
        var answer = 0;
        Event?.Invoke("Event generated", out answer);

        for (var i = 0; i < answer; i++) 
            Event?.Invoke($"Event {i} generated", out var empty);
    }
}