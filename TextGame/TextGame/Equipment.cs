using RPG.Interfaces;

namespace RPG.Equipment {
    public class IronDagger : Weapon {
        public Constants.W_TYPES type { get; set; }
        public int attack { get; set; }
        public int block { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronDagger() {
            this.type = Constants.W_TYPES.RIGHT;
            this.attack = 1;
            this.block = 0;
            this.durability = 100;
            this.name = "iron dagger";
        }
        
        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronShield : Weapon {
        public Constants.W_TYPES type { get; set; }
        public int attack { get; set; }
        public int block { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronShield() {
            this.type = Constants.W_TYPES.LEFT;
            this.attack = 0;
            this.block = 1;
            this.durability = 100;
            this.name = "iron shield";
        }
        

        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronHelm : Armor {
        public Constants.A_TYPES type { get; set; }
        public int armor { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronHelm() {
            this.type = Constants.A_TYPES.HELM;
            this.armor = 1;
            this.durability = 100;
            this.name = "iron helmet";
        }

        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronBreast : Armor {
        public Constants.A_TYPES type { get; set; }
        public int armor { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronBreast() {
            this.type = Constants.A_TYPES.PLATE;
            this.armor = 1;
            this.durability = 100;
            this.name = "iron breastplate";
        }

        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronLegs : Armor {
        public Constants.A_TYPES type { get; set; }
        public int armor { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronLegs() {
            this.type = Constants.A_TYPES.LEGS;
            this.armor = 1;
            this.durability = 100;
            this.name = "iron leggings";
        }

        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronGloves : Armor {
        public Constants.A_TYPES type { get; set; }
        public int armor { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronGloves() {
            this.type = Constants.A_TYPES.GLOVES;
            this.armor = 1;
            this.durability = 100;
            this.name = "iron gloves";
        }

        public void ReduceDurability() {
            this.durability--;
        }
    }

    public class IronBoots : Armor {
        public Constants.A_TYPES type { get; set; }
        public int armor { get; set; }
        public int durability { get; set; }
        public string name { get; set; }

        public IronBoots() {
            this.type = Constants.A_TYPES.BOOTS;
            this.armor = 1;
            this.durability = 100;
            this.name = "iron boots";
        }

        public void ReduceDurability() {
            this.durability--;
        }
    }
}
