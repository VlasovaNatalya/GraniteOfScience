using System.Drawing;
using System.Linq;

namespace GraniteOfScience
{
    // класс Terrain отвечает за игровое поле
    public class Terrain
    {
        // размер одной клетки в пикселях
        private const int TileSize = 32;
        // карта уровня: 0 = пустота, 1 = земля
        private int[,] map;
        // текстура земли
        private Image groundImage;

        // размеры карты в тайлах
        public int Width => map.GetLength(1);
        public int Height => map.GetLength(0);

        public int PlayerStartX { get; private set; }
        public int PlayerStartY { get; private set; }

        public Terrain(string mapText)
        {
            // загружаем изображение земли
            groundImage = Image.FromFile("Images/Terrain.png");

            // разбиваем текстовую карту на строки
            var lines = mapText
                .Trim()
                .Split('\n')
                .Select(l => l.TrimEnd('\r')) //Windows-символ конца строки
                .ToArray();

            int height = lines.Length;
            int width = lines.Max(l => l.Length);

            map = new int[height, width];

            // заполняем всю карту землёй (единицами)
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (x >= lines[y].Length)
                    {
                        map[y, x] = 0;
                        continue;
                    }

                    char c = lines[y][x];

                    if (c == 'T')
                        map[y, x] = 1;
                    else
                        map[y, x] = 0;

                    if (c == 'P')
                    {
                        PlayerStartX = x;
                        PlayerStartY = y;
                    }
                }
        }

        // метод копания — превращает землю в пустоту
        public void Dig(int x, int y)
        {
            if (IsInside(x, y))
                map[y, x] = 0;
        }
        public bool IsInside(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        // отрисовка карты
        public void Draw(Graphics g)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (map[y, x] == 1) // если это земля
                    {
                        g.DrawImage(
                            groundImage,
                            x * TileSize,
                            y * TileSize,
                            TileSize,
                            TileSize
                        );
                    }
                }
            }
        }
    }
}
