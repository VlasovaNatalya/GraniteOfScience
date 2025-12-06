using System.IO;
using System.Drawing;

namespace GraniteOfScience
{
    public class Level
    {
        public Terrain Terrain { get; private set; }
        public int LevelNumber { get; private set; }
        public Point TeacherStartPosition { get; private set; }

        public Level(int levelNumber = 1)
        {
            int TeacherSpeedDelay = levelNumber == 1 ? 15 : 8;

            string mapText = File.ReadAllText($"level{levelNumber}.txt");
            Terrain = new Terrain(mapText);
        }
    }
}
