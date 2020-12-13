using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    public class Room
    {
        public int roomNum;
        private RoomWrapper rw;

        public Player player;
        public List<GameObject> gameobjects;
        public GameObject[,] collisionArray;

        public Room(int roomNum, RoomWrapper rw)
        {
            this.roomNum = roomNum;
            this.rw = rw;
            gameobjects = new List<GameObject>();
            int xSize = (int)(rw.map.size.X / Tile.TILE_SIZE);
            int ySize = (int)(rw.map.size.Y / Tile.TILE_SIZE);
            collisionArray = new GameObject[xSize,ySize];
            for(int x = 0; x < xSize; x++)
            {
                for(int y = 0; y < ySize; y++)
                {
                    collisionArray[x, y] = null;
                }
            }

            GOReader();
        }
        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            player.Draw(gameTime, spriteBatch);
            foreach(GameObject gm in gameobjects)
            {
                gm.Draw(gameTime, spriteBatch);
            }
        }

        private List<Vector2> dreamPushables = new List<Vector2>();

        public void copyGOs(List<GameObject> gameobjects2)
        {
            foreach(GameObject go in gameobjects2)
            {
                if (go.mType != MoveType.immovable && go.mType != MoveType.none)
                {
                    if (!gameobjects.Contains(go))
                    {
                        gameobjects.Add(go);
                    }
                    if (collisionArray[(int)((go.Position.X - rw.map.offset.X) / Tile.TILE_SIZE), (int)((go.Position.Y - rw.map.offset.Y) / Tile.TILE_SIZE)] == null)
                    {
                        int x = (int)((go.Position.X - rw.map.offset.X) / Tile.TILE_SIZE);
                        int y = (int)((go.Position.Y - rw.map.offset.Y) / Tile.TILE_SIZE);
                        collisionArray[x, y] = go;
                        dreamPushables.Add(new Vector2(x, y));
                    }
                }
            }
        }

        public void checkPushableCols()
        {
            foreach (GameObject go in gameobjects)
            {
                if (go.type == GameObjectType.pushable)
                {
                    ((Pushable)go).move(0, 0, false);
                }
            }
            foreach (Vector2 v2 in dreamPushables)
            {
                collisionArray[(int)v2.X, (int)v2.Y] = null;
            }
        }

        public void GOReader()
        {
            string filename = $"{Game1.LOCAL_DIR}Rooms/Room{rw.levelNum}/room{roomNum}.txt";

            System.IO.StreamReader file = null;
            try
            {
                file = new System.IO.StreamReader(filename);
                string line;


                while ((line = file.ReadLine()) != null)
                {
                    // '#' represents a comment within a file
                    if (line.Length == 0 || (line.Length > 0 && line[0] == '#')) continue;
                    string[] info_tmp = line.Split(' ');


                    if (info_tmp[0].Equals(GameObjectType.player.ToString()))
                    {
                        player = new Player(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.player, MoveType.controllable, roomNum);
                        player.initRect(int.Parse(info_tmp[1]) * Tile.TILE_SIZE + (int)rw.map.offset.X, int.Parse(info_tmp[2]) * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                    }
                    else if (info_tmp[0].Equals(GameObjectType.wall.ToString()))
                    {
                        Wall tmpWall = new Wall(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.wall, MoveType.immovable, roomNum);
                        gameobjects.Add(tmpWall);
                        int xPos = int.Parse(info_tmp[1]);
                        int yPos = int.Parse(info_tmp[2]);
                        tmpWall.initRect(xPos * Tile.TILE_SIZE + (int)rw.map.offset.X, yPos * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                        collisionArray[xPos, yPos] = tmpWall;
                    }
                    else if (info_tmp[0].Equals(GameObjectType.pushable.ToString()))
                    {
                        Pushable tmpPushable = new Pushable(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.pushable, MoveType.moveable, roomNum);
                        gameobjects.Add(tmpPushable);
                        int xPos = int.Parse(info_tmp[1]);
                        int yPos = int.Parse(info_tmp[2]);
                        tmpPushable.initRect(xPos * Tile.TILE_SIZE + (int)rw.map.offset.X, yPos * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                        collisionArray[xPos, yPos] = tmpPushable;
                    }
                    else if (info_tmp[0].Equals(GameObjectType.button.ToString()))
                    {
                        Button tmpButton = new Button(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.button, MoveType.none, roomNum);
                        gameobjects.Add(tmpButton);
                        int xPos = int.Parse(info_tmp[1]);
                        int yPos = int.Parse(info_tmp[2]);
                        tmpButton.initRect(xPos * Tile.TILE_SIZE + (int)rw.map.offset.X, yPos * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                        collisionArray[xPos, yPos] = tmpButton;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Encountered exception while opening file '{filename}': {e}");
            }
            finally
            {
                if (file != null) file.Close();
            }
        }
    }
}
