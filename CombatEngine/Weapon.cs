using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatEngine
{
    class Weapon : Usable
    {
        public Dictionary<string, float> config { get; protected set; }
        public int damagesMin { get; protected set; }
        public int damagesMax { get; protected set; }
        public int hitsMin { get; protected set; }
        public int hitsMax { get; protected set; }

        public Weapon(Dictionary<string,float> c, string name) : base(false, name)
        {
            config = c;
            damagesMin = (int)c["damagesMin"];
            damagesMax = (int)c["damagesMax"];
            hitsMin = (int)c["hitsMin"];
            hitsMax = (int)c["hitsMax"];
        }
    }
}
