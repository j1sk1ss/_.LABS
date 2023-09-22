namespace CS_LABS.LABS.METHODS.THIRD_LAB.OBJECTS.FIRST_TASK;

public class Generator {
    public delegate int AccountHandler(string message);

    public event AccountHandler Event;

    public void Generate() {
        var count = Event?.Invoke("Event generated and return: {0}");
        for (var i = 0; i < count; i++) 
            Event?.Invoke($"Event {i} generated");
    }
}