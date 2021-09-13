using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWarsClassLibrary
{
    public static class FighterNecessities
    {
        //weapons list
        public static List<string> weapon = new List<string>(){"Phaser", "Pulse Cannons", "Disruptors","Assault Rifles", "Carbines", "Rocket Launchers",
           "Raikous","Stingers" };
        //  potions list
        public static List<string> potion = new List<string>() { "Kryptonite", "Agent Yellow", "Cynochrin", "Soltoxin" };
        // treasures list
        public static List<string> treasure = new List<string>() { "Silver Star", "Black Star", "Iron Cross" };
        //item list
        public static List<string> items = new List<string>() { "GPS", "N-1 StarFighter", "Rnager CV", "space military suits", "face maks"};
    }
    
}
