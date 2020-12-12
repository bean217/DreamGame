using System;
using System.Collections.Generic;
using System.Text;

namespace DreamGame
{
    class Room
    {

        GameObject[] gameobjects;

        private int roomNum;
        private RoomWrapper rw;

        public Room(int roomNum, RoomWrapper rw)
        {
            this.roomNum = roomNum;
            this.rw = rw;
        }

        public void GOReader()
        {
            string filename = $"{Game1.LOCAL_DIR}Rooms/Room{rw.levelNum}/room{roomNum}";

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

                    if (info_tmp[0].Equals(GameObjectType.player.ToString())){
                        rw.player = new Player(Tile.TILE_SIZE, Tile.TILE_SIZE, rw, GameObjectType.player, MoveType.controllable);
                        rw.player.initRect(int.Parse(info_tmp[1]) * Tile.TILE_SIZE + (int)rw.map.offset.X, int.Parse(info_tmp[2]) * Tile.TILE_SIZE + (int)rw.map.offset.Y);
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
