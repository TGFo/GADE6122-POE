using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swamp_Game
{
    internal class Map
    {
        private Tile[,] tile;
        private Obstacle walls;
        private char[,] map;
        private Hero hero;
        private Enemy[] enemy;
        private Item[] items;
        private Random rand = new Random();
        private int MapHeight;
        private int MapWidth;
        private int enemyNumber = 0;
        private int itemNumber = 0;
        private int enemyType;
        private int weaponType;
        private int NoOfMonster;
        private int drops;
        public int getNoOfMonster()
        {
            return NoOfMonster;
        }
        public void setNoOfMonster(int NoOfMonster)
        {
            this.NoOfMonster = NoOfMonster;
        }
        public int getDrops()
        {
            return drops;
        }
        public void setDrops(int drops)
        {
            this.drops = drops;
        }
        public Map(int minHeight, int minWidth, int maxWidth, int maxHeight, int NoOfMonster, int drops, int weaponDrops)
        {
            this.drops = drops;
            this.NoOfMonster = NoOfMonster;
            MapHeight = rand.Next(minHeight, maxHeight);
            MapWidth = rand.Next(minWidth, maxWidth);
            map = new char[maxHeight, maxWidth];
            tile = new Tile[MapHeight, MapWidth];
            enemy = new Enemy[NoOfMonster];
            items = new Item[drops];
            for(int i = 0; i < MapHeight; i++)
            {
                for(int j = 0; j < MapWidth; j++)
                {
                    if(i == 0 || j == 0 || i == maxHeight - 1 || j == maxWidth - 1)
                    {
                        tile[i, j] = GenerateObstacles(i, j);
                    }
                }
            }
            hero = (Hero)Create(0);
            for(enemyNumber = 0; enemyNumber < enemy.Length; enemyNumber++)
            {
                enemy[enemyNumber] = (Enemy)Create((Tile.TileType)1);
            }
            for(itemNumber = 0; itemNumber < items.Length; itemNumber++)
            {
                if(itemNumber > weaponDrops)
                {
                    items[itemNumber] = (Item)Create((Tile.TileType)2);
                }
                else
                {
                    items[itemNumber] = (Item)Create((Tile.TileType)3);
                }
            }
            UpdateVision();
            GenerateMap();
        }
        public int GetEnemyNumber()
        {
            return enemyNumber;
        }
        public void SetEnemyNumber(int enemyNumber)
        {
            this.enemyNumber = enemyNumber;
        }
        public int GetItemNumber()
        {
            return itemNumber;
        }
        public void SetItemNumber(int itemNumber)
        {
            this.itemNumber = itemNumber;
        }
        public Item[] GetItems()
        {
            return items;
        }
        public void SetItems(Item[] items)
        {
            this.items = items;
        }
        public Obstacle GetWalls()
        {
            return walls;
        }
        public void SetWalls(Obstacle walls)
        {
            this.walls = walls;
        }
        public int GetWidth()
        {
            return MapWidth;
        }
        public void Setwidth(int MapWidth)
        {
            this.MapWidth = MapWidth;
        }
        public int GetHeight()
        {
            return MapHeight;
        }
        public void SetHeight(int MapHeight)
        {
            this.MapHeight = MapHeight;
        }
        public Tile[,] GetTiles()
        {
            return tile;
        }
        public void setTiles(int y, int x, Tile newTile)
        {
            tile[y, x] = newTile;
        }
        public Hero GetHero()
        {
            return hero;
        }
        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }
        public Enemy[] GetEnemies()
        {
            return enemy;
        }
        public void SetEnemy(Enemy[] enemy)
        {
            this.enemy = enemy;
        }
        public void UpdateVision()
        {
            hero.vision[0] = tile[hero.GetY() - 1, hero.GetX()];
            hero.vision[1] = tile[hero.GetY() + 1, hero.GetX()];
            hero.vision[2] = tile[hero.GetY(), hero.GetX() - 1];
            hero.vision[3] = tile[hero.GetY(), hero.GetX() + 1];
            foreach(Enemy enemy in enemy)
            {
                if (enemy != null)
                {
                    enemy.vision[0] = tile[enemy.GetY() - 1, enemy.GetX()];
                    enemy.vision[1] = tile[enemy.GetY() + 1, enemy.GetX()];
                    enemy.vision[2] = tile[enemy.GetY(), enemy.GetX() - 1];
                    enemy.vision[3] = tile[enemy.GetY(), enemy.GetX() + 1];
                }
            }
        }

        public Tile Create(Tile.TileType type)
        {
            int mapY;
            int mapX;
            do
            {
                mapY = rand.Next(0 ,MapHeight - 1);
                mapX = rand.Next(0 ,MapWidth - 1);
            }while (tile[mapY, mapX] != null);
            switch (type)
            {
                case 0:
                    hero = new Hero(mapY, mapX, 50, 50);
                    tile[mapY, mapX] = hero;
                    break;
                case (Tile.TileType)1:
                    enemyType = rand.Next(3);
                    switch(enemyType)
                    {
                        case 0:
                            enemy[enemyNumber] = new SwampCreature(mapY, mapX);
                            break;
                        case 1:
                            enemy[enemyNumber] = new Mage(mapY, mapX);
                            break;
                        case 2:
                            enemy[enemyNumber] = new Leader(mapY, mapX);
                            break;
                    }
                    tile[mapY, mapX] = enemy[enemyNumber];
                    break;
                case (Tile.TileType)2:
                    items[itemNumber] = new Gold(mapY, mapX);
                    tile[mapY, mapX] = items[itemNumber];
                    break;
                case(Tile.TileType)3:
                    weaponType= rand.Next(2);
                    switch (weaponType)
                    {
                        case 0:
                            tile[mapY, mapX] = new MeleeWeapon(mapY, mapX, (MeleeWeapon.Types)rand.Next(2));
                            break;
                        case 1:
                            tile[mapY, mapX] = new RangedWeapon(mapY, mapX, (RangedWeapon.Types)rand.Next(2));
                            break;
                    }
                    break;
                    
            }
            return tile[mapY, mapX];
        }
        public void GenerateMap()
        {
            tile[hero.GetY(), hero.GetX()] = hero;
            for(int a = 0; a < enemy.Length; a++)
            {
                if (enemy[a] != null)
                {
                    tile[enemy[a].GetY(), enemy[a].GetX()] = enemy[a];
                }
            }
            for(int i = 0; i < MapHeight; i++)
            {
                for(int j = 0; j < MapWidth; j++)
                {
                    map[i, j] = '.';
                    if(tile[i, j] != null)
                    {
                        map[i, j] = (tile[i, j].GetType().Name)[0];
                    }
                }
            }
        }
        public Obstacle GenerateObstacles(int y, int x)
        {
            walls = new Obstacle(y, x);
            return walls;
        }
        public Char[,] GetMap()
        {
            return map;
        }
        public void SetMap(Char[,] map)
        {
            this.map = map;
        }
        public Item GetItemAtPosition(int x, int y)
        {
            Item foundItem = null;
            for(int i = 0; i < items.Length; i++)
            {
                if (items[i] != null && (x == items[i].GetX() && y == items[i].GetY()))
                {
                    foundItem = items[i];
                    items[i] = null;
                    break;
                }
            }
            return foundItem;
        }
    }
}
