using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Swamp_Game
{
    internal class GameEngine
    {
        private Map map;
        private Shop shop;
        private int noMonsters = 4;
        private int noDrops = 2;
        private int noWeapons;
        public GameEngine()
        {
            map = new Map(10, 10, 10, 10, noMonsters, noDrops, noWeapons);
            shop = new Shop(map.GetHero());
        }
        public Map GetMap()
        {
            return map;
        }
        public bool MovePlayer(Character.Movement direction)
        {
            int oldY = map.GetHero().GetY();
            int oldX = map.GetHero().GetX();
            bool canMove = false;
            if(map.GetHero().ReturnMove(direction) == direction)
            {
                map.GetHero().Move(direction);
                map.setTiles(oldY, oldX, null);
                canMove = true;
                map.GetHero().Pickup(map.GetItemAtPosition(map.GetHero().GetX(), map.GetHero().GetY()));
            }
            return canMove;
        }
        public void moveCreature()
        {
            int oldY;
            int oldX;
            for(int i = 0; i < noMonsters; i++)
            {
                if(map.GetEnemies()[i] != null && map.GetEnemies()[i].GetType().Name != "Mage")
                {
                    oldY = map.GetEnemies()[i].GetY();
                    oldX = map.GetEnemies()[i].GetX();
                    map.GetEnemies()[i].Move(map.GetEnemies()[i].ReturnMove());
                    map.setTiles(oldY, oldX, null);
                    map.GetEnemies()[i].Pickup(map.GetItemAtPosition(map.GetHero().GetX(), map.GetHero().GetY()));
                }
            }
        }
        public int numMonsters()
        {
            return noMonsters;
        }
        public void Kill(Character target)
        {
            map.GetHero().loot(target);
            int deadX;
            int deadY;
            deadX = target.GetX();
            deadY = target.GetY();
            map.setTiles(deadY, deadX, null);
            if (target != map.GetHero())
            {
                Array.Clear(map.GetEnemies(), Array.IndexOf(map.GetEnemies(), target), 1);
            }
        }
        public void EnemyAttacks()
        {
            for(int i = 0; i < noMonsters; i++)
            {
                if (map.GetEnemies()[i] != null && map.GetEnemies()[i].CheckRange(map.GetHero()))
                {
                    map.GetEnemies()[i].Attack(map.GetHero());
                }
                if(map.GetEnemies()[i] != null && map.GetEnemies()[i].GetType().Name == "Mage")
                {
                    for(int j = 0; j < map.GetEnemies().Length; j++)
                    {
                        if (map.GetEnemies()[j] != null && map.GetEnemies()[j].CheckRange(map.GetEnemies()[j]))
                        {
                            map.GetEnemies()[j].Attack(map.GetEnemies()[j]);
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            string mapRepresentation = "";
            for(int i = 0; i < map.GetHeight(); i++)
            {
                for(int j = 0; j < map.GetWidth(); j++)
                {
                    mapRepresentation += map.GetMap()[i, j].ToString() + " ";
                }
                mapRepresentation += "\n"; 
            }
            return mapRepresentation;
        }
        public Shop GetShop()
        {
            return shop;
        }

        public void SaveGame()
        {
            FileStream fs = new FileStream("Map.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(map.getDrops());
            bw.Write(map.getNoOfMonster());
            bw.Write(map.GetWidth());
            bw.Write(map.GetHeight());
            for(int i = 0; i < map.GetHeight(); i++)
            {
                for(int k = 0; k < map.GetWidth(); k++)
                {
                    if(map.GetTiles()[i, k] == null || map.GetTiles()[i, k].GetType() == typeof(Obstacle))
                    {
                        bw.Write(" ");
                    }else if(map.GetTiles()[i, k].GetType() == typeof(Hero))
                    {
                        bw.Write((int)map.GetHero().GetTileType());
                        bw.Write(map.GetHero().GetHP());
                        bw.Write(map.GetHero().GetDamage());
                        bw.Write(map.GetHero().AccessGoldPurse());
                    }else if(map.GetTiles()[i, k].GetType() == typeof(Mage))
                    {
                        bw.Write((int)map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetTileType());
                        bw.Write((string)map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetType().Name);
                        bw.Write(map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetHP());
                        bw.Write(map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetDamage());
                    }else if(map.GetTiles()[i, k].GetType() == typeof(SwampCreature))
                    {
                        bw.Write((int)map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetTileType());
                        bw.Write((string)map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetType().Name);
                        bw.Write(map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetHP());
                        bw.Write(map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, k])].GetDamage());
                    }else if(map.GetTiles()[i, k].GetType() == typeof(Gold))
                    {
                        bw.Write((int)map.GetItems()[Array.IndexOf(map.GetItems(), (Item)map.GetTiles()[i, k])].GetTileType());
                    }
                }
            }
            /*bw.Write(map.GetHero().GetX());
            bw.Write(map.GetHero().GetY());
            bw.Write(map.GetHero().GetMaxHP());
            bw.Write(map.GetHero().GetHP());
            bw.Write(map.GetHero().GetDamage());
            bw.Write(map.GetHero().AccessGoldPurse());
            bw.Write(map.GetEnemies().Length);
            for(int i = 0; i < map.GetEnemies().Length; i++)
            {
                if (map.GetEnemies()[i] != null)
                {
                    bw.Write(map.GetEnemies()[i].GetMaxHP());
                    bw.Write(map.GetEnemies()[i].GetHP());
                    bw.Write(map.GetEnemies()[i].GetDamage());
                    bw.Write(map.GetEnemies()[i].GetY());
                    bw.Write(map.GetEnemies()[i].GetX());
                }
            }
            bw.Write(map.GetItems().Length);
            for(int j = 0; j < map.GetItems().Length; j++)
            {
                if(map.GetItems()[j] != null)
                {
                    bw.Write(map.GetItems()[j].);
                }
            }*/
            bw.Close();
            fs.Close();
        }

        public void LoadGame()
        {
            int noEnemies;
            int drops;
            int height;
            int width;
            Tile.TileType type;
            FileStream fs = new FileStream("Map.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            drops = br.Read();
            noEnemies = br.Read();
            height = br.Read();
            width = br.Read();
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(br.ReadString().ToString() == " ")
                    {
                        map.setTiles(i, j, null);
                    }
                    type = (Tile.TileType)br.ReadInt32();
                    switch(type)
                    {
                        case 0:
                            map.setTiles(i, j, map.Create(0));
                            map.GetHero().SetHP(br.ReadInt32());
                            map.GetHero().SetDamage(br.ReadInt32());
                            map.GetHero().SetGold(br.ReadInt32());
                            break;
                        case (Tile.TileType)1:
                            map.setTiles(i, j, map.Create((Tile.TileType)1));
                            if(br.ReadString().ToString() == "Mage")
                            {
                                map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])] = new Mage(i, j);
                                map.GetTiles()[i, j] = map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])];
                            }else
                            {
                                map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])] = new SwampCreature(i, j);
                                map.GetTiles()[i, j] = map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])];
                            }
                            map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])].SetHP(br.ReadInt32());
                            map.GetEnemies()[Array.IndexOf(map.GetEnemies(), (Enemy)map.GetTiles()[i, j])].SetDamage(br.ReadInt32());
                            break;
                        case ((Tile.TileType)2):
                            map.setTiles(i, j, map.Create((Tile.TileType)2));
                            break;
                    }
                }
            }
            br.Close();
            fs.Close();
        }
    }
}
