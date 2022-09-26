using System;
using System.Collections.Generic;

namespace CS_LABS;

public class Labs : ILabs
{
    public readonly Dictionary<int, Action> Works = new Dictionary<int, Action>();
    public void AddVoids(Action[] voids)
    {
        for (var i = 0; i < voids.Length; i++) Works.Add(i + 1,voids[i]);
    }
}