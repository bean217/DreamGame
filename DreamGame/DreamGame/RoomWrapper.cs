using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using DreamGame.States;

namespace DreamGame
{
    public class RoomWrapper
    {
        #region Room data.txt sections
        
        private static readonly string DIM_X = "room_width";
        private static readonly string DIM_Y = "room_height";
        private static readonly string NUM_ROOMS = "room_num";

        #endregion

        public State state;

        public int levelNum;

        public Map map;


        private Room[] rooms;
        public Room currentRoom;

        public Vector2 dimensions
        {
            get; set;
        }

        public RoomWrapper(int levelNum, State state) {
            this.levelNum = levelNum;
            map = new Map(this);
            this.state = state;

        }

        public void LoadContent() {
            // read room wrapper data file for dimension info
            // dimensions = .... ;
            Dictionary<string, string> data = RWReader($"{Game1.LOCAL_DIR}Rooms/Room{levelNum}/data.txt");
            string testing = System.IO.Directory.GetCurrentDirectory();
            dimensions = new Vector2(int.Parse(data[DIM_X]), int.Parse(data[DIM_Y]));
            map.LoadContent();

            rooms = new Room[int.Parse(data[NUM_ROOMS])];
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = new Room(i, this);
            }
            currentRoom = rooms[0];
            currentRoom.LoadContent();
        }

        bool ZKeyState = false;
        bool XKeyState = false;
        public void Update(GameTime gameTime) {
            map.Update(gameTime);
            currentRoom.Update(gameTime);

            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Z) && ZKeyState)
            {
                if (currentRoom.roomNum + 1 < rooms.Length)
                    currentRoom = rooms[currentRoom.roomNum + 1];
            }
            else if (kstate.IsKeyDown(Keys.X) && XKeyState)
            {
                if(currentRoom.roomNum - 1 >= 0)
                    currentRoom = rooms[currentRoom.roomNum - 1];
            }
            ZKeyState = kstate.IsKeyUp(Keys.Z);
            XKeyState = kstate.IsKeyUp(Keys.X);


            //tmp game state change
            if (kstate.IsKeyDown(Keys.Space))
            {
                state.ChangeState(new GameState(state._graphics, state._spriteBatch, state._game, 2), gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            map.Draw(gameTime, spriteBatch);
            currentRoom.Draw(gameTime, spriteBatch);
        }

        public static Dictionary<string, string> RWReader(string filename) {
            Dictionary<string, string> tmp = new Dictionary<string, string>();
            System.IO.StreamReader file = null;
            try {
                file = new System.IO.StreamReader(filename);
                string line;
                
                while ((line = file.ReadLine()) != null) {
                    // '#' represents a comment within a file
                    Console.WriteLine(line);
                    if (line.Length == 0 || (line.Length > 0 && line[0] == '#')) continue;
                    string[] info_tmp = line.Split('=');
                    
                    // checks x dimension
                    if (info_tmp[0].Equals(DIM_X)) {
                        tmp.Add(DIM_X, info_tmp[1]);
                        continue;
                    }
                    if (info_tmp[0].Equals(DIM_Y)) {
                        tmp.Add(DIM_Y, info_tmp[1]);
                        continue;
                    }
                    if (info_tmp[0].Equals(NUM_ROOMS))
                    {
                        tmp.Add(NUM_ROOMS, info_tmp[1]);
                        continue;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine($"Encountered exception while opening file '{filename}': {e}");
            } finally {
                if (file != null) file.Close();
            }
            return tmp;
        }

    }
}
