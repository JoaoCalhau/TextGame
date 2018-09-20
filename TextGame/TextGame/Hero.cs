using System;
using System.Collections.Generic;
using System.Globalization;
using RPG.Interfaces;

namespace RPG.Hero {
    public class MainCharacter {
        private int hp;
        private String name;
        public Dictionary<String, Item> inv;
        public Dictionary<String, Item> equipment;
        private int armor;

        public MainCharacter(String name) {
            this.inv = new Dictionary<String, Item>();
            this.equipment = new Dictionary<String, Item>();
            this.name = name;
            this.hp = 10;
            this.armor = 0;
        }

        public int Hp {
            get {
                return hp;
            }

            set {
                this.hp = value;
            }
        }

        public String Name {
            get {
                return name;
            }
        }

        public int Armor {
            get {
                return armor;
            }
        }

        public void Equip(Item i) {
            Weapon wToEquip, wEquipped;
            Armor aToEquip, aEquipped;
            if(!(i is Weapon) && !(i is Armor)) {
                Console.WriteLine("Can't equip this.");
            } else {
                foreach(Item item in equipment.Values) {
                    if(item is Weapon && i is Weapon) {
                        wEquipped = (Weapon)item;
                        wToEquip = (Weapon)i;
                        if (wEquipped.type == wToEquip.type) {
                            equipment.Add(i.name, i);
                            TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                            Console.WriteLine("Unequipped {0} and equipped {1}.", tf.ToTitleCase(wEquipped.name), tf.ToTitleCase(wToEquip.name));
                            inv.Add(item.name, item);
                            equipment.Remove(item.name);
                            return;
                        } 
                    } else if(item is Armor && i is Armor) {
                        aEquipped = (Armor)item;
                        aToEquip = (Armor)i;
                        if (aEquipped.type == aToEquip.type) {
                            equipment.Add(i.name, i);
                            TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                            Console.WriteLine("Unequipped {0} and equipped {1}.",tf.ToTitleCase(aEquipped.name), tf.ToTitleCase(aToEquip.name));
                            inv.Add(item.name, item);
                            armor -= aEquipped.armor;
                            armor += aToEquip.armor;
                            equipment.Remove(item.name);
                            return;
                        }
                    }
                }

                if (i is Weapon || i is Armor) {
                    equipment.Add(i.name, i);
                    TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                    Console.WriteLine("Equipped {0}.", tf.ToTitleCase(i.name));
                    if(i is Armor) {
                        Armor a = (Armor)i;
                        armor += a.armor;
                    }
                    inv.Remove(i.name);
                } else {
                    Console.WriteLine("Can't equip this...");
                }
            }
        }

        public void UnEquip(String itemName) {
            if(equipment.ContainsKey(itemName)) {
                Item i = equipment[itemName];
                inv.Add(i.name, i);
                TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                Console.WriteLine("Unequipped {0}.", tf.ToTitleCase(i.name));

                if(i is Armor) {
                    Armor a = (Armor)i;
                    armor -= a.armor;
                }

                equipment.Remove(i.name);
            } else {
                Console.WriteLine("No such item in your inventory...");
            }
        }

        public int Attack() {
            Weapon equipped = null;
            foreach(Item item in equipment.Values) {
                if(item is Weapon) {
                    equipped = (Weapon)item;
                    if(equipped.type == Constants.W_TYPES.RIGHT) {
                        return equipped.attack;
                    }
                }
            }
            return 0;
        }

        public void PrintEquiped() {
            Weapon rightHand = null, leftHand = null;
            Armor helmet = null, breastPlate = null, leggings = null, gloves = null, boots = null;
            Weapon wEquipped;
            Armor aEquipped;
            foreach(Item i in equipment.Values) {
                if(i is Weapon) {
                    wEquipped = (Weapon)i;
                    if (wEquipped.type == Constants.W_TYPES.RIGHT)
                        rightHand = wEquipped;
                    else
                        leftHand = wEquipped;
                } else {
                    aEquipped = (Armor)i;
                    switch(aEquipped.type) {
                        case Constants.A_TYPES.HELM: 
                            {
                                helmet = aEquipped;
                                break;
                            }
                        case Constants.A_TYPES.PLATE: 
                            {
                                breastPlate = aEquipped;
                                break;
                            }
                        case Constants.A_TYPES.LEGS: 
                            {
                                leggings = aEquipped;
                                break;
                            }
                        case Constants.A_TYPES.GLOVES: 
                            {
                                gloves = aEquipped;
                                break;
                            }
                        case Constants.A_TYPES.BOOTS: 
                            {
                                boots = aEquipped;
                                break;
                            }
                    }
                }
            }

            if (rightHand == null && leftHand == null && helmet == null && breastPlate == null && leggings == null && gloves == null && boots == null)
                Console.WriteLine("You have nothing equipped...");
            else {
                TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                
                if (rightHand != null)
                    Console.WriteLine("{0} is equipped on your right hand and has {1} durability", tf.ToTitleCase(rightHand.name), rightHand.durability);
                if(leftHand != null)
                    Console.WriteLine("{0} is equipped on your left hand and has {1} durability", tf.ToTitleCase(leftHand.name), leftHand.durability);
                if(helmet != null)
                    Console.WriteLine("{0} is equipped and has {1} durability", tf.ToTitleCase(helmet.name), helmet.durability);
                if(breastPlate != null)
                    Console.WriteLine("{0} is equipped and has {1} durability", tf.ToTitleCase(breastPlate.name), breastPlate.durability);
                if(leggings != null)
                    Console.WriteLine("{0} is equipped and has {1} durability", tf.ToTitleCase(leggings.name), leggings.durability);
                if(gloves != null)
                    Console.WriteLine("{0} is equipped and has {1} durability", tf.ToTitleCase(gloves.name), gloves.durability);
                if(boots != null)
                    Console.WriteLine("{0} is equipped and has {1} durability", tf.ToTitleCase(boots.name), boots.durability);
            }
        }

        public void PrintInv() {
            if (inv.Keys.Count == 0) {
                Console.WriteLine("Nothing in your inventory");
            } else {
                Console.WriteLine("Items in your inventory:");
                TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                foreach (String item in inv.Keys) {
                    Console.WriteLine("{0}", tf.ToTitleCase(item));
                }
            }
        }

        public void Get(Item item) {
            inv.Add(item.name, item);
            TextInfo tf = new CultureInfo("en-US", false).TextInfo;
            Console.WriteLine("{0} is now in your inventory", tf.ToTitleCase(item.name));
        }

        public void Drop(Item item) {
            inv.Remove(item.name);
            TextInfo tf = new CultureInfo("en-US", false).TextInfo;
            Console.WriteLine("You toss the {0} to the ground", tf.ToTitleCase(item.name));
        }

        public bool IsInInv(String itemName) {
            return inv.ContainsKey(itemName);
        }

        public Item GetItem(String itemName) {
            return inv[itemName];
        }
    }
}
