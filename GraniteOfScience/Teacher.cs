using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Teacher
    {
        public int TileX { get; private set; }
        public int TileY { get; private set; }

        private float realX;
        private float realY;
        private const int TileSize = 32;
        private Image sprite;
        private Player targetPlayer;
        private int moveCounter = 0;
        private const int MoveDelay = 10;

        public Teacher(int startX, int startY, Player player)
        {
            TileX = startX;
            TileY = startY;
            realX = TileX * TileSize;
            realY = TileY * TileSize;
            targetPlayer = player;

            try
            {
                sprite = Image.FromFile("Images/Royak.png");
            }
            catch
            {
                // Создаём временную заглушку
                sprite = new Bitmap(TileSize, TileSize);
                using (Graphics g = Graphics.FromImage(sprite))
                    g.FillRectangle(Brushes.Blue, 0, 0, TileSize, TileSize);
            }
        }

        public void MoveTowardsPlayer(Terrain terrain)
        {
            if (targetPlayer == null) return;

            int dx = targetPlayer.TileX - TileX;
            int dy = targetPlayer.TileY - TileY;

            // Определяем основное направление движения
            int moveX = 0, moveY = 0;

            if (System.Math.Abs(dx) > System.Math.Abs(dy))
            {
                moveX = dx > 0 ? 1 : -1;
            }
            else
            {
                moveY = dy > 0 ? 1 : -1;
            }

            int newX = TileX + moveX;
            int newY = TileY + moveY;

            if (CanMoveTo(newX, newY, terrain))
            {
                TileX = newX;
                TileY = newY;
                return;
            }

            // Если основное направление заблокировано
            if (moveX != 0)
            {
                newX = TileX;
                newY = TileY + (dy > 0 ? 1 : -1);
                if (CanMoveTo(newX, newY, terrain))
                {
                    TileX = newX;
                    TileY = newY;
                    return;
                }
            }
            else if (moveY != 0)
            {
                newX = TileX + (dx > 0 ? 1 : -1);
                newY = TileY;
                if (CanMoveTo(newX, newY, terrain))
                {
                    TileX = newX;
                    TileY = newY;
                    return;
                }
            }

        }

        private bool CanMoveTo(int x, int y, Terrain terrain)
        {
            // Проверяем, что координаты внутри карты и клетка пустая
            return terrain != null && terrain.IsInside(x, y) && terrain.IsEmpty(x, y);
        }

        public void Update()
        {
            moveCounter++;

            // Учитель двигается только каждый MoveDelay-ый кадр
            if (moveCounter >= MoveDelay)
            {
                MoveTowardsPlayer(Form1.CurrentGame?.Terrain);
                moveCounter = 0;
            }

            // Плавное перемещение
            float targetPixelX = TileX * TileSize;
            float targetPixelY = TileY * TileSize;

            realX += (targetPixelX - realX) * 0.3f;
            realY += (targetPixelY - realY) * 0.3f;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(sprite, realX, realY, TileSize, TileSize);
        }

        public bool IsPlayerCaught()
        {
            if (targetPlayer == null)
                return false;

            return TileX == targetPlayer.TileX && TileY == targetPlayer.TileY;
        }

        public float GetDistanceToPlayer()
        {
            if (targetPlayer == null) return float.MaxValue;

            int dx = targetPlayer.TileX - TileX;
            int dy = targetPlayer.TileY - TileY;
            return (float)System.Math.Sqrt(dx * dx + dy * dy);
        }
    }
}