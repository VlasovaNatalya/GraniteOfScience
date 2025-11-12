using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Player
    {
        public int X { get; private set; } = 100;
        public int Y { get; private set; } = 100;

        private int speed = 5;
        private Image sprite;

        // загружает изображение и задаёт стартовую позицию
        public Player(string spritePath)
        {
            try
            {
                sprite = Image.FromFile(spritePath);
            }
            catch
            {
                MessageBox.Show($"Не найден файл: {spritePath}");
                sprite = new Bitmap(32, 32);
                using (Graphics g = Graphics.FromImage(sprite))
                    g.FillRectangle(Brushes.Red, 0, 0, 32, 32);
            }
        }

        // Метод движения
        public void Move(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    X -= speed;
                    break;
                case Keys.Right:
                    X += speed;
                    break;
                case Keys.Up:
                    Y -= speed;
                    break;
                case Keys.Down:
                    Y += speed;
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            if (sprite != null)
                g.DrawImage(sprite, X, Y, 32, 32); // рисуем игрока в позиции X, Y размером 32x32
        }
    }
}
