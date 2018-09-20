using System;
using System.Collections.Generic;
using RPG.Interfaces;


namespace RPG.LabirinthStructure {

    public class Direction {
        public int n;
        public Constants.D_TYPES d;

        public Direction(int n, Constants.D_TYPES d) {
            this.n = n;
            this.d = d;
        }
    }

    public class Room {
        public Dictionary<String, Item> itemList;
        public Dictionary<String, Npc> npcList;
        int roomNumber;

        public Room(int roomNumber) {
            this.roomNumber = roomNumber;
            itemList = new Dictionary<String, Item>();
            npcList = new Dictionary<string, Npc>();
        }

        public int Number {
            get {
                return roomNumber;
            }
        }

        public void AddItem(Item item) {
            itemList.Add(item.name, item);
        }

        public void AddNpc(Npc npc) {
            npcList.Add(npc.name, npc);
        }

        public Item GetItem(string itemName) {
            return itemList?[itemName];
        }

        public void RemoveItem(String itemName) {
            itemList.Remove(itemName);
        }
    }
    
    public class Floor {
        public Dictionary<int, Room> roomList;
        private List<Direction>[] childNodes;

        public Floor(int size) {
            this.childNodes = new List<Direction>[size];
            this.roomList = new Dictionary<int, Room>();
            for(int i = 0; i < size; i++) {
                this.roomList.Add(i, new Room(i));
                this.childNodes[i] = new List<Direction>();
            }
        }

        public Floor(List<Direction>[] childNodes, Dictionary<int, Room> roomList) {
            this.childNodes = childNodes;
            this.roomList = roomList;
        }

        public int Size {
            get {
                return this.childNodes.Length;
            }
        }

        public void AddEdge(int u,  int v, Constants.D_TYPES d) {
            childNodes[u].Add(new Direction(v, d));
        }

        public void RemoveEdge(int u, int v) {
            foreach(Direction d in childNodes[u]) {
                if (d.n == v)
                    childNodes[u].Remove(d);
            }
        }

        public bool HasEdge(int u, int v, Constants.D_TYPES s) {
            foreach(Direction d in childNodes[u]) {
                if ((d.n == v) && (d.d == s))
                    return true;
            }
            return false;
        }

        public List<Direction> GetSuccessors(int v) {
            return childNodes[v];
        }

        public Room GetRoom(int r) {
            return roomList[r];
        }

        public Item GetItem(int r, String name) {
            return roomList[r].GetItem(name);
        }
    }

    public class Labirinth {
        public Dictionary<int, Floor> floors;

        public Labirinth(Dictionary<int, Floor> floors) {
            this.floors = floors;

        }

        public int Number {
            get {
                return floors.Count;
            }
        }

        public Item GetItem(int f, int r, String name) {
            return floors[f].GetItem(r, name);
        }
    }
}
