using System;
using System.Collections.Generic;
using CS_LABS.INTERFACES;

namespace CS_LABS.SUP_CLASSES;

public class Labs : ILabs
{
        public readonly Math Math = new Math();
        public readonly Arrays Arrays = new Arrays();
    public readonly Dictionary<int, Action> Works = new Dictionary<int, Action>();
    public void AddVoids(Action[] voids)
    {
        for (var i = 0; i < voids.Length; i++) Works.Add(i + 1,voids[i]);
    }
}