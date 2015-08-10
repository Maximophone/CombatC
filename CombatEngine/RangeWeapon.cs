using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatEngine
{
    class RangeWeapon : Weapon
    {
        public RangeWeapon(string name, Dictionary<string,float> c) : base(c, name)
        {
        }

        public void use(Player p)
        {
            Random r = new Random();
            int numberOfHits = r.Next(hitsMin, hitsMax);
            for (int i = 0; i < numberOfHits; ++i)
            {
                if (p.dead) break;
                int damages = r.Next(damagesMin, damagesMax);
                p.takeDamages(damages);
            }
        }
    }
}
