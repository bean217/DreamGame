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
        private int roomNum;
        private RoomWrapper rw;

        public Player player;
        private List<GameObject> gameobjects;
        public bool[,] collisionArray;

        public Room(int roomNum, RoomWrapper rw)
        {
            this.roomNum = roomNum;
            this.rw = rw;
            gameobjects = new List<GameObject>();
            int xSize = (int)(rw.map.size.X / Tile.TILE_SIZE);
            int ySize = (int)(rw.map.size.Y / Tile.TILE_SIZE);
            collisionArray = new bool[xSize,ySize];
            for(int x = 0; x < xSize; x++)
            {
                for(int y = 0; y < ySize; y++)
                {
                    collisionArray[x, y] = false;
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
                    Console.WriteLine(line);
                    if (line.Length == 0 || (line.Length > 0 && line[0] == '#')) continue;
                    string[] info_tmp = line.Split(' ');


                    if (info_tmp[0].Equals(GameObjectType.player.ToString()))
                    {
                        player = new Player(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.player, MoveType.controllable);
                        player.initRect(int.Parse(info_tmp[1]) * Tile.TILE_SIZE + (int)rw.map.offset.X, int.Parse(info_tmp[2]) * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                    }
                    else if (info_tmp[0].Equals(GameObjectType.wall.ToString()))
                    {
                        Wall tmpWall = new Wall(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.wall, MoveType.immovable);
                        gameobjects.Add(tmpWall);
                        int xPos = int.Parse(info_tmp[1]);
                        int yPos = int.Parse(info_tmp[2]);
                        tmpWall.initRect(xPos * Tile.TILE_SIZE + (int)rw.map.offset.X, yPos * Tile.TILE_SIZE + (int)rw.map.offset.Y);
                        collisionArray[xPos, yPos] = true;
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
