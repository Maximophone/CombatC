using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatEngine
{
    class Usable
    {
        public bool selfUsable { get; protected set; }
        public string name { get; protected set; }
        public Usable(bool s, string n)
        {
            selfUsable = s;
            name = n;
        }
    }
}
