using System.IO;
using System.Drawing;

namespace GraniteOfScience
{
    public class Level
    {
        public Terrain Terrain { get; private set; }
        public Point TeacherStartPosition { get; private set; }

        public Level()
        {
            string mapText = File.ReadAllText("level1.txt");
            Terrain = new Terrain(mapText);
        }
    }
}
