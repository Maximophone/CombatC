using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEngine
{
    class Engine
    {
        public Player player { get; private set; }
        public Dictionary<string, Player> opponents { get; private set; }

        private List<char> indexKeys = new List<char>();


        public Engine(Player p, Dictionary<string, Player> op)
        {
            player = p;
            opponents = op;

            indexKeys.Add('0');
            indexKeys.Add('1');
            indexKeys.Add('2');
            indexKeys.Add('3');
            indexKeys.Add('4');
            indexKeys.Add('5');
            indexKeys.Add('6');
            indexKeys.Add('7');
            indexKeys.Add('8');
            indexKeys.Add('9');
            indexKeys.Add('a');
            indexKeys.Add('b');
            indexKeys.Add('c');
            indexKeys.Add('d');
            indexKeys.Add('e');
            indexKeys.Add('f');
        }

        private bool isOver()
        {
            return false;
        }

        public void start()
        {
            while(!isOver())
            {
                turn();
                foreach(KeyValuePair<string,Player> pair in opponents)
                {
                    AIturn(pair.Value);
                }
            }
        }

        public void turn()
        {
            Console.WriteLine("Your HP: " + player.hp);
            if(player.inventory.Count > 0)
            {
                if(waitYN("Use object?")) // If answer is yes
                {
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    foreach(KeyValuePair<string,Item> pair in player.inventory)
                    {
                        options.Add(pair.Key,pair.Key);
                    }
                    player.useItem(selectOption("Select Object", options));
                }
                Dictionary<string,string> combatStyle = new Dictionary<string,string>();
                combatStyle.Add("Melee Weapon", "Melee Weapon");
                if(player.rangeWeapons.Count>0) combatStyle.Add("Range Weapon", "Range Weapon");
                if (player.magic.Count > 0) combatStyle.Add("Magic", "Magic");
                string usedcombatStyle = selectOption("Which one will you use", combatStyle);
                if(usedcombatStyle == "Melee Weapon")
                {
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, MeleeWeapon> pair in player.meleeWeapons)
                    {
                        options.Add(pair.Key,pair.Key);
                    }
                    MeleeWeapon usedWeapon = player.meleeWeapons[selectOption("Select Weapon", options)];
                    Dictionary<string, string> optionsOpponent = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, Player> pair in opponents)
                    {
                        if (!pair.Value.dead) optionsOpponent.Add(pair.Key + " (" + pair.Value.hp + "hp)",pair.Key);
                    }
                    usedWeapon.use(opponents[selectOption("Choose opponent", optionsOpponent)]);
                }
                if (usedcombatStyle == "Range Weapon")
                {
                    Dictionary<string, string> options = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, RangeWeapon> pair in player.rangeWeapons)
                    {
                        options.Add(pair.Key,pair.Key);
                    }
                    RangeWeapon usedWeapon = player.rangeWeapons[selectOption("Select Weapon", options)];
                    Dictionary<string, string> optionsOpponent = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, Player> pair in opponents)
                    {
                        if (!pair.Value.dead) optionsOpponent.Add(pair.Key + " (" + pair.Value.hp + "hp)", pair.Key);
                    }
                    usedWeapon.use(opponents[selectOption("Choose opponent", optionsOpponent)]);
                }
                if (usedcombatStyle == "Magic")
                {
                    Dictionary<string,string> options = new Dictionary<string,string>();
                    foreach (KeyValuePair<string, Magic> pair in player.magic)
                    {
                        options.Add(pair.Key,pair.Key);
                    }
                    player.useMagic(selectOption("Select Weapon", options));
                }
               
            }

        }

        private void AIturn(Player ai)
        {
            Console.WriteLine(ai.name + " turn.");
            Random rand = new Random();
            if(ai.inventory.Count>0)
            {
                List<string> invList = ai.inventory.Keys.ToList();
                string selectedItem = invList[rand.Next(ai.inventory.Count - 1)];
                Console.WriteLine(ai.name + " using " + ai.inventory[selectedItem].name);
                ai.inventory[selectedItem].use();
            }
            List<string> combatStyle = new List<string>();
            if (ai.meleeWeapons.Count > 0) combatStyle.Add("Melee Weapons");
            if (ai.rangeWeapons.Count > 0) combatStyle.Add("Range Weapons");
            if (ai.magic.Count > 0) combatStyle.Add("Magic");
            if(combatStyle.Count>0)
            {
                string selectedCombatStyle = combatStyle[rand.Next(combatStyle.Count - 1)];
                if(selectedCombatStyle == "Melee Weapons")
                {
                    List<string> weaponsList = ai.meleeWeapons.Keys.ToList();
                    string selectedWeapon = weaponsList[rand.Next(weaponsList.Count - 1)];
                    Console.WriteLine(ai.name + " uses " + ai.meleeWeapons[selectedWeapon].name + " on you.");
                    ai.meleeWeapons[selectedWeapon].use(player);
                }
                if (selectedCombatStyle == "Range Weapons")
                {
                    List<string> weaponsList = ai.rangeWeapons.Keys.ToList();
                    string selectedWeapon = weaponsList[rand.Next(weaponsList.Count - 1)];
                    Console.WriteLine(ai.name + " uses " + ai.rangeWeapons[selectedWeapon].name + " on you.");
                    ai.rangeWeapons[selectedWeapon].use(player);
                }
                if (selectedCombatStyle == "Magic")
                {

                }
            }
        }

        private bool waitYN(string question)
        {
            Console.WriteLine(question + " Y/N");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.KeyChar == 'y') return true;
            if (key.KeyChar == 'n') return false;
            return waitYN(question);
        }

        private string selectOption(string question, Dictionary<string,string> options)
        {
            Console.WriteLine(question + ":");
            int ind = 0;
            Dictionary<char,string> possibleChoices = new Dictionary<char,string>();
            foreach(KeyValuePair<string,string> option in options)
            {
                Console.WriteLine(indexKeys[ind] + " : " + option.Key);
                possibleChoices.Add(indexKeys[ind],option.Value);
                ++ind;
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if(possibleChoices.ContainsKey(key.KeyChar))
            {
                return possibleChoices[key.KeyChar];
            }
            return selectOption(question,options);
        }
    }
}
