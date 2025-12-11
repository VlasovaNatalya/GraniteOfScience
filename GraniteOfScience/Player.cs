using System.Drawing;
using System.Drawing.Printing;
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
        private float Speed => GameSettings.PlayerSpeed;
        private Image sprite;

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
                sprite = new Bitmap(TileSize, TileSize);
                using (Graphics g = Graphics.FromImage(sprite))
                    g.FillRectangle(Brushes.Red, 0, 0, TileSize, TileSize);
            }
        }

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

            if (terrain.IsWalkable(targetX, targetY))
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

            realX += (targetPixelX - realX) * Speed * 0.05f;
            realY += (targetPixelY - realY) * Speed * 0.05f;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(sprite, realX, realY, TileSize, TileSize);
        }
    }
}
