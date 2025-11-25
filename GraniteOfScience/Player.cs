using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Player
    {
        public int TileX { get; private set; }
        public int TileY { get; private set; }

        private float realX;
        private float realY;

        private const int TileSize = 32;
        private const float Speed = 4f; // скорость в пикселях за кадр
        private Image sprite;

        // загружает изображение и задаёт стартовую позицию
        public Player(int startX, int startY)
        {
            TileX = startX;
            TileY = startY;
            realX = TileX * TileSize;
            realY = TileY * TileSize;

            try
            {
                sprite = Image.FromFile("Images/Digger.png");
            }
            catch
            {
                MessageBox.Show("Не найден файл: Images/Digger.png");
                // создаём временную заглушку
                sprite = new Bitmap(TileSize, TileSize);
                using (Graphics g = Graphics.FromImage(sprite))
                    g.FillRectangle(Brushes.Red, 0, 0, TileSize, TileSize);
            }
        }

        // Метод движения
        public void Move(Keys key, Terrain terrain)
        {
            int targetX = TileX;
            int targetY = TileY;

            switch (key)
            {
                case Keys.Left: targetX--; break;
                case Keys.Right: targetX++; break;
                case Keys.Up: targetY--; break;
                case Keys.Down: targetY++; break;
            }

            if (terrain.IsInside(targetX, targetY))
            {
                TileX = targetX;
                TileY = targetY;
                terrain.Dig(TileX, TileY);
            }
        }
        public void Update()
        {
            float targetPixelX = TileX * TileSize;
            float targetPixelY = TileY * TileSize;

            realX += (targetPixelX - realX) * 0.3f;
            realY += (targetPixelY - realY) * 0.3f;
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(sprite, realX, realY, TileSize, TileSize);
        }
    }
}
