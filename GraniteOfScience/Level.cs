using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace GraniteOfScience
{
    public class Level
    {
        public Terrain Terrain { get; private set; }
        public int LevelNumber { get; private set; }
        public Point TeacherStartPosition { get; private set; }

        private string LevelsPath =
            Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName,
            "GraniteOfScience", "Levels");

        public Level(int levelNumber = 1)
        {
            LevelNumber = levelNumber;

            string filePath = Path.Combine(LevelsPath, $"level{levelNumber}.txt");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл уровня не найден!", filePath);

            string mapText = File.ReadAllText(filePath);

            Terrain = new Terrain(mapText);
        }
    }
}
