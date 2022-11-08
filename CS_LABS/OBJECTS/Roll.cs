using System.Collections.Generic;
using System.Linq;
using CS_LABS.INTERFACES;

namespace CS_LABS.SUP_CLASSES;

public class Roll<T> 
{
    public List<T> Data;
    public int Count { get; set; }
    public Roll<T> Previous { get; set; }
    public Roll<T> Next { get; set; }
    public Roll() {
        Data = new List<T>();
        Count = 0;
    }
    
    public Roll(IEnumerable<T> data) {
        Data = data.ToList();
        Count = Data.Count;
    }
    
    public void Include(T value, int position) {
        Data.Insert(position, value);
        Count++;
    }

    public static Roll<T> operator +(Roll<T> obj1, Roll<T> obj2) {
        var rl =  new Roll<T> {
            Data = obj1.Data.Concat(obj2.Data).ToList(),
            Count = obj1.Count + obj2.Count
        };
        return rl;
    }
    
    public void Delete(int position) {
        Data.RemoveAt(position);
        Count--;
    }
    
    public bool Contains(T value) {
        return Data.Contains(value);
    }

    public string Print() {
        return Data.Aggregate("", (current, t) => current + (t + " "));
    }
}