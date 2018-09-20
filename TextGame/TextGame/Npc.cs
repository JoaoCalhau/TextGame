using RPG.Interfaces;

namespace RPG.Npcs
{
    class Wolf : Npc {
        public string name { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int armor { get; set; }
        public bool hostile { get; set; }

        public Wolf() {
            this.hp = 5;
            this.name = "wolf";
            this.attack = 1;
            this.armor = 0;
            this.hostile = true;
        }
    }
}
