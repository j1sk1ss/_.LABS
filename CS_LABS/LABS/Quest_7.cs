using System.Collections.Generic;
using CS_LABS.SUP_CLASSES;

namespace CS_LABS.LABS;
public class Quest7
{
    private readonly Labs _labs = new Labs();
    public void Main()
    {

    }

} 
internal class ArrayWorker
{ ArrayWorker(){}
    int GetElement(IReadOnlyList<int> array, int index) {
        return array[index]; }
    void SetElement(int[] array, int index, int value) {
        array[index] = value; }
    int[] Push(int[] array, int value)
    { var ar = new int[array.Length + 1];
        for (var j = 0; j < array.Length; j++) ar[j] = array[j];
        ar[^1] = value;
        return ar; }
}