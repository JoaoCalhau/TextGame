using RPG.Consumables;
using RPG.Equipment;
using RPG.Interfaces;
using RPG.LabirinthStructure;
using RPG.Hero;
using RPG.Npcs;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RPG.Main
{
    class MainGame
    {
        static void Main(string[] args) {

            int currentRoom = 0;
            int currentFloor = 0;

            //Floor Generation
            Floor floor1 = new Floor(7);
            //Room Generation
            floor1.AddEdge(0, 0, Constants.D_TYPES.UP);
            floor1.AddEdge(0, 1, Constants.D_TYPES.S);
            floor1.AddEdge(1, 0, Constants.D_TYPES.N);
            floor1.AddEdge(1, 2, Constants.D_TYPES.E);
            floor1.AddEdge(1, 3, Constants.D_TYPES.S);
            floor1.AddEdge(1, 4, Constants.D_TYPES.W);
            floor1.AddEdge(2, 1, Constants.D_TYPES.W);
            floor1.AddEdge(2, 3, Constants.D_TYPES.SW);
            floor1.AddEdge(3, 1, Constants.D_TYPES.N);
            floor1.AddEdge(3, 2, Constants.D_TYPES.NE);
            floor1.AddEdge(4, 1, Constants.D_TYPES.E);
            floor1.AddEdge(4, 5, Constants.D_TYPES.S);
            floor1.AddEdge(5, 4, Constants.D_TYPES.N);
            floor1.AddEdge(5, 6, Constants.D_TYPES.S);
            floor1.AddEdge(6, 5, Constants.D_TYPES.N);
            floor1.AddEdge(6, 6, Constants.D_TYPES.DOWN);
            //Labirinth Generation
            Labirinth lab = new Labirinth(new Dictionary<int, Floor> { { 0, floor1 } });

            //Item Generation
            lab.floors[0].roomList[3].AddItem(new IronHelm());
            lab.floors[0].roomList[2].AddItem(new IronGloves());
            lab.floors[0].roomList[0].AddItem(new IronBreast());
            lab.floors[0].roomList[4].AddItem(new IronLegs());
            lab.floors[0].roomList[6].AddItem(new IronBoots());
            lab.floors[0].roomList[5].AddItem(new Bread());
            lab.floors[0].roomList[1].AddNpc(new Wolf());

            //Monster Generation


            Console.Write("Enter the name of your hero: ");
            MainCharacter mc = new MainCharacter(Console.ReadLine());


            Console.WriteLine("As you are taking your regular walk, you stumble upon a dungeon.");
            Console.WriteLine("You decide to take a look, seeing as you have nothing better to do...");
            Console.WriteLine("As you walk down the first flight of stairs, you find an Iron Dagger and an Iron Shield.");
            Console.WriteLine("'Of course you take them with you. (who wouldnt?)");
            Console.WriteLine();

            mc.Get(new IronDagger());
            mc.Get(new IronShield());

            Console.WriteLine();
            Console.WriteLine("Looks like an adventure is starting...");
            Console.WriteLine("(To see all available commands type help)");

            String line;
            String[] commands;

            while (true) {
                Console.WriteLine("\n*****************************************************************************************************************\n");
                line = Console.ReadLine();
                commands = line.Split(null);
                try {

                    switch (commands[0].ToLower()) {
                        case "help": {
                            Console.WriteLine("Possible Commands:");
                            Console.Write("n  s  e  w  ");
                            Console.Write("ne  nw  se  sw  ");
                            Console.Write("up  down  ");
                            Console.Write("inv  drop  get  ");
                            Console.Write("look  hero  equip  ");
                            Console.Write("unequip  item  monster  ");
                            Console.Write("attack  eat  summon  ");
                            Console.WriteLine("exit");
                            break;
                        }
                        case "n": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.N) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "s": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.S) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "e": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.E) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "w": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.W) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "ne": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.NE) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "nw": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.NW) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "se": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.SE) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "sw": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            int room = currentRoom;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.SW) {
                                    canAdvance = true;
                                    room = d.n;
                                }
                            }

                            if (canAdvance) {
                                Console.WriteLine("You advance to room {0}", room);
                                currentRoom = room;
                            }
                            else {
                                Console.WriteLine("No room in that direction");
                            }
                            break;
                        }
                        case "up": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.UP)
                                    canAdvance = true;
                            }
                            if (canAdvance) {
                                if (currentFloor == 0) {
                                    Console.WriteLine("Seeing as you don't want to die, you leave through the entrance you came.");
                                    Console.WriteLine("Thanks for playing.");
                                    Console.WriteLine("Press any key to leave the game.");
                                    Console.Read();
                                    Environment.Exit(0);
                                }
                                else {
                                    currentRoom = lab.floors[--currentFloor].Size - 1;
                                }
                            }
                            else {
                                Console.WriteLine("No stairs in this room...");
                            }
                            break;
                        }
                        case "down": {
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            bool canAdvance = false;
                            foreach (Direction d in ld) {
                                if (d.d == Constants.D_TYPES.DOWN)
                                    canAdvance = true;
                            }
                            if (canAdvance) {
                                if (currentFloor == lab.Number - 1) {
                                    Console.WriteLine("Congratulations, you reached the last room of the last floor.");
                                    Console.WriteLine("Thanks for playing.");
                                    Console.WriteLine("Press any key to leave the game.");
                                    Console.Read();
                                    Environment.Exit(0);
                                }
                                else {
                                    currentFloor++;
                                    currentRoom = 0;
                                }
                            }
                            else {
                                Console.WriteLine("No stairs in this room...");
                            }
                            break;
                        }
                        case "inv": {
                            mc.PrintInv();
                            break;
                        }
                        case "drop": {
                            if (commands.Length > 1) {
                                String itemName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    itemName += commands[i];
                                    itemName += " ";
                                }

                                itemName = itemName.Substring(0, itemName.Length - 1);

                                if (mc.IsInInv(itemName.ToLower())) {
                                    Item item = mc.GetItem(itemName.ToLower());
                                    mc.Drop(item);
                                    lab.floors[currentFloor].roomList[currentRoom].AddItem(item);
                                }
                                else {
                                    Console.WriteLine("Can't drop what isn't there");
                                }
                            }
                            else {
                                Console.WriteLine("Usage: drop <item name>");
                            }
                            break;
                        }
                        case "get": {
                            if (commands.Length > 1) {
                                String itemName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    itemName += commands[i];
                                    itemName += " ";
                                }

                                itemName = itemName.Substring(0, itemName.Length - 1);

                                Item item = lab.GetItem(currentFloor, currentRoom, itemName.ToLower());

                                if (item != null) {
                                    mc.Get(item);
                                    lab.floors[currentFloor].roomList[currentRoom].RemoveItem(item.name.ToLower());
                                }
                                else
                                    Console.WriteLine("No such item on the current room");
                            }
                            else {
                                Console.WriteLine("Usage: get <item name>");
                            }
                            break;
                        }
                        case "look": {
                            bool stairsUp = false;
                            bool stairsDown = false;
                            Console.WriteLine("You take a look around...\n");
                            Dictionary<String, Item> fi = lab.floors[currentFloor].roomList[currentRoom].itemList;
                            if (fi.Count != 0) {
                                TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                foreach (String s in fi.Keys) {
                                    Console.WriteLine("You spot an {0}", tf.ToTitleCase(s));
                                }
                            }

                            Dictionary<String, Npc> fn = lab.floors[currentFloor].roomList[currentRoom].npcList;
                            if (fn.Count != 0) {
                                TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                foreach (String s in fn.Keys) {
                                    Npc npc = lab.floors[currentFloor].roomList[currentRoom].npcList[s];
                                    if (npc.hp > 0)
                                        Console.WriteLine("You spot a {0} ", tf.ToTitleCase(s));
                                    else
                                        Console.WriteLine("You spot the corpse of a {0} ", tf.ToTitleCase(s));
                                }
                            }

                            Console.WriteLine();
                            List<Direction> ld = lab.floors[currentFloor].GetSuccessors(currentRoom);
                            foreach (Direction d in ld) {
                                switch (d.d) {
                                    case Constants.D_TYPES.UP: {
                                        stairsUp = true;
                                        break;
                                    }
                                    case Constants.D_TYPES.DOWN: {
                                        stairsDown = true;
                                        break;
                                    }
                                    case Constants.D_TYPES.N: {
                                        Console.WriteLine("You spot a door to the North");
                                        break;
                                    }
                                    case Constants.D_TYPES.S: {
                                        Console.WriteLine("You spot a door to the South");
                                        break;
                                    }
                                    case Constants.D_TYPES.E: {
                                        Console.WriteLine("You spot a door to the East");
                                        break;
                                    }
                                    case Constants.D_TYPES.W: {
                                        Console.WriteLine("You spot a door to the West");
                                        break;
                                    }
                                    case Constants.D_TYPES.NE: {
                                        Console.WriteLine("You spot a door to the NorthEast");
                                        break;
                                    }
                                    case Constants.D_TYPES.NW: {
                                        Console.WriteLine("You spot a door to the NorthWest");
                                        break;
                                    }
                                    case Constants.D_TYPES.SE: {
                                        Console.WriteLine("You spot a door to the SouthEast");
                                        break;
                                    }
                                    case Constants.D_TYPES.SW: {
                                        Console.WriteLine("You spot a door to the SouthWest");
                                        break;
                                    }
                                }
                            }

                            if (stairsUp)
                                Console.WriteLine("You spot some stairs Up");
                            if (stairsDown)
                                Console.WriteLine("You spot some stairs Down");
                            break;
                        }
                        case "equip": {
                            if (commands.Length > 1) {
                                String itemName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    itemName += commands[i];
                                    itemName += " ";
                                }

                                itemName = itemName.Substring(0, itemName.Length - 1);

                                if (mc.IsInInv(itemName.ToLower())) {
                                    Item item = mc.GetItem(itemName.ToLower());
                                    mc.Equip(item);
                                }
                                else {
                                    Console.WriteLine("That is not in your inventory");
                                }
                            }
                            else {
                                Console.WriteLine("Usage: equip <item name>");
                            }
                            break;
                        }
                        case "item": {
                            if (commands.Length > 1) {
                                String itemName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    itemName += commands[i];
                                    itemName += " ";
                                }

                                itemName = itemName.Substring(0, itemName.Length - 1);
                                Item item;
                                int status; // 0, 1, 2 - 0 if it is in inv, 1 if it is in equipped and 2 if it is on the ground

                                if (mc.inv.ContainsKey(itemName)) {
                                    item = mc.inv[itemName];
                                    status = 0;
                                }
                                else if (mc.equipment.ContainsKey(itemName)) {
                                    item = mc.equipment[itemName];
                                    status = 1;
                                }
                                else {
                                    item = lab.floors[currentFloor].roomList[currentRoom]?.itemList[itemName.ToLower()];
                                    status = 2;
                                }

                                if (item != null) {
                                    if (item is Weapon) {
                                        Weapon w = (Weapon)item;
                                        TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                        if (status == 0) {
                                            Console.WriteLine("Item Status: Equipped.");
                                        }
                                        else if (status == 1) {
                                            Console.WriteLine("Item Status: In inventory.");
                                        }
                                        else {
                                            Console.WriteLine("Item Status: On the ground.");
                                        }
                                        Console.WriteLine("Attack: {0}", w.attack);
                                        Console.WriteLine("Block: {0}", w.block);
                                        Console.WriteLine("Durability: {0}", w.durability);
                                    }
                                    else if (item is Armor) {
                                        Armor a = (Armor)item;
                                        TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                        if (status == 0) {
                                            Console.WriteLine("Item Status: Equipped.");
                                        }
                                        else if (status == 1) {
                                            Console.WriteLine("Item Status: In inventory.");
                                        }
                                        else {
                                            Console.WriteLine("Item Status: On the ground.");
                                        }
                                        Console.WriteLine("Item {0} information:", tf.ToTitleCase(a.name));
                                        Console.WriteLine("Block: {0}", a.armor);
                                        Console.WriteLine("Durability: {0}", a.durability);
                                    }
                                    else {
                                        // No other items implemented yet
                                    }
                                }
                                else {
                                    Console.WriteLine("No such item equipped, in inventory or on the ground...");
                                }
                            }
                            else {
                                Console.WriteLine("Usage: item <item name>");
                            }
                            break;
                        }
                        case "monster": {
                            if (commands.Length > 1) {
                                String monsterName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    monsterName += commands[i];
                                    monsterName += " ";
                                }

                                monsterName = monsterName.Substring(0, monsterName.Length - 1);

                                Npc monster;
                                if (lab.floors[currentFloor].roomList[currentRoom].npcList.ContainsKey(monsterName.ToLower())) {
                                    monster = lab.floors[currentFloor].roomList[currentRoom].npcList[monsterName.ToLower()];
                                }
                                else {
                                    monster = null;
                                }

                                if (monster != null) {
                                    TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                    if (monster.hp > 0) {
                                        Console.WriteLine("You spot a monster, upon closer inspection you can see it's stats");
                                        Console.WriteLine("The monster is a {0} and has {1} HP, {2} Attack and {3} armor", tf.ToTitleCase(monster.name), monster.hp, monster.attack, monster.armor);
                                    }
                                    else {
                                        Console.WriteLine("The {0} is already dead...", tf.ToTitleCase(monster.name));
                                    }
                                }
                                else {
                                    Console.WriteLine("No such monster in this room...");
                                }
                            }
                            else {
                                Console.WriteLine("Usage: monster <monster name>");
                            }
                            break;
                        }
                        case "hero": {
                            Console.WriteLine("Our Hero {0} currently has {1} HP and {2} Armor", mc.Name, mc.Hp, mc.Armor);
                            mc.PrintEquiped();
                            break;
                        }
                        case "attack": {
                            if (commands.Length > 1) {
                                String monsterName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    monsterName += commands[i];
                                    monsterName += " ";
                                }

                                Npc monster;
                                monsterName = monsterName.Substring(0, monsterName.Length - 1);
                                if (lab.floors[currentFloor].roomList[currentRoom].npcList.ContainsKey(monsterName.ToLower())) {
                                    monster = lab.floors[currentFloor].roomList[currentRoom]?.npcList[monsterName.ToLower()];
                                }
                                else {
                                    monster = null;
                                }

                                if (monster != null) {
                                    if (monster.hp > 0) {
                                        int attack = mc.Attack();
                                        int damage = attack - monster.armor;
                                        int monsterDamage = monster.attack - mc.Armor;
                                        TextInfo tf = new CultureInfo("en-US", false).TextInfo;
                                        if (damage <= 0) {
                                            Console.WriteLine("You attempt to attack the {0} but you deal 0 damage...", tf.ToTitleCase(monster.name));
                                            if (monsterDamage > 0) {
                                                if ((mc.Hp - monsterDamage) <= 0) {
                                                    Console.WriteLine("The {0} deals a fatal blow!", tf.ToTitleCase(monster.name));
                                                    Console.WriteLine("An adventure ends...");
                                                    Console.WriteLine("Thanks for playing.");
                                                    Console.WriteLine("Press any key to leave the game.");
                                                    Console.Read();
                                                    Environment.Exit(0);
                                                }
                                                else {
                                                    mc.Hp -= monsterDamage;
                                                    Console.WriteLine("The {0} attacks you back and deals {1} damage!", tf.ToTitleCase(monster.name), monsterDamage);
                                                }
                                            }
                                            else {
                                                Console.WriteLine("The {0} attempts to attack you back but your armor prevails", tf.ToTitleCase(monster.name));
                                            }
                                        }
                                        else {
                                            Console.WriteLine("You attack the {0} for {1} points of damage!", tf.ToTitleCase(monster.name), damage);
                                            if ((monster.hp - damage) <= 0) {
                                                monster.hp = 0;
                                                Console.WriteLine("You kill the monster and live to fight another day!");
                                                lab.floors[currentFloor].roomList[currentRoom].npcList[monsterName].hp = 0;
                                            }
                                            else {
                                                monster.hp -= damage;
                                                lab.floors[currentFloor].roomList[currentRoom].npcList[monsterName].hp = monster.hp;

                                                if (monsterDamage <= 0) {
                                                    Console.WriteLine("The {0} attacks you back but your armor prevails and he deals 0 damage.", tf.ToTitleCase(monster.name));

                                                }
                                                else {
                                                    if ((mc.Hp - monsterDamage) <= 0) {
                                                        Console.WriteLine("The {0} deals a fatal blow!", tf.ToTitleCase(monster.name));
                                                        Console.WriteLine("An adventure ends...");
                                                        Console.WriteLine("Thanks for playing.");
                                                        Console.WriteLine("Press any key to leave the game.");
                                                        Console.Read();
                                                        Environment.Exit(0);
                                                    }
                                                    else {
                                                        mc.Hp -= monsterDamage;
                                                        Console.WriteLine("The {0} attacks you back and deals {1} damage!", tf.ToTitleCase(monster.name), monsterDamage);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else {
                                        Console.WriteLine("Calm down... He's already dead...");
                                    }
                                }
                                else {
                                    Console.WriteLine("No such monster in this room...");
                                }
                            }
                            else {
                                Console.WriteLine("Usage: attack <monster name>");
                            }
                            break;
                        }
                        case "eat": {
                            if (commands.Length > 1) {
                                String itemName = "";

                                for (int i = 1; i < commands.Length; i++) {
                                    itemName += commands[i];
                                    itemName += " ";
                                }

                                itemName = itemName.Substring(0, itemName.Length - 1);
                                if (mc.Hp == 10) {
                                    Console.WriteLine("Health is full!");
                                }
                                else {
                                    if (mc.IsInInv(itemName)) {
                                        Item item = mc.inv[itemName];
                                        if (item is Consumable) {
                                            Consumable c = (Consumable)item;
                                            if (mc.Hp + c.amount > 10) {
                                                mc.Hp = 10;
                                                Console.WriteLine("You're fully healed!");
                                                mc.inv.Remove(c.name);
                                            }
                                            else {
                                                mc.Hp += c.amount;
                                                Console.WriteLine("You restore {0} points of health", c.amount);
                                                mc.inv.Remove(c.name);
                                            }
                                        }
                                        else {
                                            Console.WriteLine("Can't eat that...");
                                        }
                                    }
                                    else {
                                        Console.WriteLine("No such item in yout inventory");
                                    }
                                }
                            }
                            else {
                                Console.WriteLine("Usage: eat <item name>");
                            }
                            break;
                        }
                        case "summon": {
                            if (commands.Length > 1) {
                                // Not yet implemented
                            }
                            else {
                                Console.WriteLine("Usage: summon <item name>");
                            }
                            break;
                        }
                        case "exit": {
                            Console.WriteLine();
                            Console.WriteLine("An adventure ends...");
                            Console.WriteLine("Thanks for playing.");
                            Console.WriteLine("Press any key to leave the game.");
                            Console.Read();
                            Environment.Exit(0);
                            break;
                        }
                        default: {
                            Console.WriteLine("Command not recognized...");
                            break;
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Something broke... Here's the message: " + ex.Message);
                    Console.WriteLine("Here's the trace: " + ex.StackTrace);
                    Console.Read();
                    Environment.Exit(1);
                }
            }
        }
    }
}
