using System.Linq;

namespace CS_LABS.LABS.NUM_METHODS.SECOND_LAB.OBJECTS;

public class Vector {
    public Vector(int size) {
        Size = size;
        Body = new double[Size];
    }

    public Vector(double[] body) {
        Body = body;
        Size = Body.Length;
    }
    
    public int Size { get; }
    private double[] Body { get; }

    public double this[int index] {
        get => Body[index];
        set => Body[index] = value;
    }

    public string Print() => Body.Aggregate("", (current, t) => current + $"{t}, ");

    public string VerticalPrint() => Body.Aggregate("", (current, t) => current + $"{t}\n");
    
    public void Swipe(int first, int second) => (Body[first], Body[second]) = (Body[second], Body[first]);
}