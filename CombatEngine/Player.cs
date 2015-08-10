using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombatEngine
{
    class Player
    {
        public Dictionary<string, float> config { get; private set; }
        public Dictionary<string,Item> inventory { get; private set; }
        public Dictionary<string, MeleeWeapon> meleeWeapons { get; private set; }
        public Dictionary<string, RangeWeapon> rangeWeapons { get; private set; }
        public Dictionary<string, Magic> magic { get; private set; }

        public string name { get; private set; }
        public int hp { get; private set; }
        public bool dead { get; private set;}
        
        public Player(string n, Dictionary<string, float> c)
        {
            config = c;
            inventory = new Dictionary<string, Item>();
            meleeWeapons = new Dictionary<string,MeleeWeapon>();
            rangeWeapons = new Dictionary<string,RangeWeapon>();
            magic = new Dictionary<string,Magic>();

            name = n;
            hp = (int)config["hp"];
            dead = false;
        }

        public void useItem(string p)
        {
            Console.WriteLine("Using " + p);
        }

        public void addStuff(Item i)
        {
            inventory.Add(i.name, i);
        }

        public void addStuff(Magic m)
        {
            magic.Add(m.name, m);
        }

        public void addStuff(MeleeWeapon m)
        {
            meleeWeapons.Add(m.name, m);
        }

        public void addStuff(RangeWeapon r)
        {
            rangeWeapons.Add(r.name, r);
        }

        public void takeDamages(int damages)
        {
            Console.WriteLine(name + " taking " + damages + " damages!");
            hp -= damages;
            if(hp<0)
            {
                Console.WriteLine(name + " is dead! RIP");
                hp = 0;
                dead = true;
            }
        }


        internal void useMeleeWeapon(string p)
        {
            throw new NotImplementedException();
        }

        internal void useRangeWeapon(string p)
        {
            throw new NotImplementedException();
        }

        internal void useMagic(string p)
        {
            throw new NotImplementedException();
        }
    }
}
