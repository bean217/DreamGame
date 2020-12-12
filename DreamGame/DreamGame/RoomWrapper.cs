using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DreamGame
{
    class RoomWrapper
    {
        #region Room data.txt sections
        
        private static readonly string DIM_X = "room_width";
        private static readonly string DIM_Y = "room_height";

        #endregion

        private int levelNum;

        private Map map;

        public Vector2 dimensions
        {
            get; set;
        }

        public RoomWrapper(int levelNum) {
            this.levelNum = levelNum;
            map = new Map(this);
        }

        public void LoadContent() {
            // read room wrapper data file for dimension info
            // dimensions = .... ;
            Dictionary<string, string> data = RWReader($"data{levelNum}");
            dimensions = new Vector2(int.Parse(data[DIM_X]), int.Parse(data[DIM_Y]));
            map.LoadContent();
        }

        public static Dictionary<string, string> RWReader(string filename) {
            Dictionary<string, string> tmp = new Dictionary<string, string>();
            System.IO.StreamReader file = null;
            try {
                file = new System.IO.StreamReader(filename);
                string line;
                
                while ((line = file.ReadLine()) != null) {
                    // '#' represents a comment within a file
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
