﻿using System;
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

        #endregion

        public State state;

        private int levelNum;

        public Map map;

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
        }

        public void Update(GameTime gameTime) {
            map.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            map.Draw(gameTime, spriteBatch);
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
