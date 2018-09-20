using RPG.Interfaces;

namespace RPG.Consumables
{
    public class Bread : Consumable {
        public int amount { get; set; }
        public string name { get; set; }

        public Bread() {
            this.amount = 2;
            this.name = "bread";
        }
    }
}
