using System;

namespace RPG.Interfaces {
    public class Constants {
        public enum W_TYPES { RIGHT, LEFT };
        public enum A_TYPES { HELM, PLATE, LEGS, GLOVES, BOOTS };
        public enum D_TYPES { N, S, E, W, NE, NW, SE, SW, UP, DOWN };
    }

    public interface Npc {
        String name { get; set; }

        int hp { get; set; }

        int attack { get; set; }

        int armor { get; set; }

        bool hostile { get; set; }
    }

    public interface Item {
        String name { get; set; }
    }

    public interface Weapon : Item {
        Constants.W_TYPES type { get; set; }
        int attack { get; set; }
        int block { get; set; }
        int durability { get; set; }
        void ReduceDurability();
    }

    public interface Armor : Item {
        Constants.A_TYPES type { get; set; }
        int armor { get; set; }
        int durability { get; set; }
        void ReduceDurability();
    }

    public interface Consumable : Item {

        int amount { get; set; }

    }
}
