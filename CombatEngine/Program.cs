using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, float>> WeaponConfigs = instantiateWeaponConfigs();
            Dictionary<string, Dictionary<string, float>> PlayersConfigs = instantiatePlayersConfigs();

            Player player = new Player("Michael", PlayersConfigs["Michael"]);
            Item harpe = new Item(false, "Harpe");
            MeleeWeapon sword = new MeleeWeapon("Sword", WeaponConfigs["Sword"]);
            MeleeWeapon axe = new MeleeWeapon("Axe", WeaponConfigs["Axe"]);
            RangeWeapon bow = new RangeWeapon("Bow", WeaponConfigs["Bow"]);

            player.addStuff(harpe);
            player.addStuff(sword);
            player.addStuff(axe);
            player.addStuff(bow);

            Dictionary<string, Player> opponents = new Dictionary<string, Player>();
            Player joseph = new Player("Joseph",PlayersConfigs["Joseph"]);
            Item harpe2 = new Item(false, "Harpe");
            joseph.addStuff(harpe2);
            opponents.Add("Joseph", joseph);
            Player connor = new Player("Connor", PlayersConfigs["Connor"]);
            MeleeWeapon sword2 = new MeleeWeapon("Sword", WeaponConfigs["Sword"]);
            connor.addStuff(sword2);
            opponents.Add("Connor", connor);
            Engine e = new Engine(player, opponents);
            e.start();
        }

        private static Dictionary<string, Dictionary<string, float>> instantiatePlayersConfigs()
        {
            Dictionary<string, Dictionary<string, float>> PlayersConfigs = new Dictionary<string, Dictionary<string, float>>();

            Dictionary<string, float> michaelConfig = new Dictionary<string, float>();
            michaelConfig.Add("hp", 100);
            PlayersConfigs.Add("Michael",michaelConfig);

            Dictionary<string, float> josephConfig = new Dictionary<string, float>();
            josephConfig.Add("hp", 100);
            PlayersConfigs.Add("Joseph", josephConfig);

            Dictionary<string, float> connorConfig = new Dictionary<string, float>();
            connorConfig.Add("hp", 100);
            PlayersConfigs.Add("Connor", connorConfig);

            return PlayersConfigs;
        }

        private static Dictionary<string, Dictionary<string, float>> instantiateWeaponConfigs()
        {
            Dictionary<string, Dictionary<string, float>> WeaponConfigs = new Dictionary<string, Dictionary<string, float>>();

            Dictionary<string, float> swordConfig = new Dictionary<string, float>();
            swordConfig.Add("damagesMin", 20);
            swordConfig.Add("damagesMax", 25);
            swordConfig.Add("hitsMin", 2);
            swordConfig.Add("hitsMax", 4);
            WeaponConfigs.Add("Sword", swordConfig);

            Dictionary<string, float> axeConfig = new Dictionary<string, float>();
            axeConfig.Add("damagesMin", 39);
            axeConfig.Add("damagesMax", 55);
            axeConfig.Add("hitsMin", 1);
            axeConfig.Add("hitsMax", 2);
            WeaponConfigs.Add("Axe", axeConfig);

            Dictionary<string, float> bowConfig = new Dictionary<string, float>();
            bowConfig.Add("damagesMin", 25);
            bowConfig.Add("damagesMax", 40);
            bowConfig.Add("hitsMin", 2);
            bowConfig.Add("hitsMax", 2);
            WeaponConfigs.Add("Bow", bowConfig);

            return WeaponConfigs;
        }
    }
}
