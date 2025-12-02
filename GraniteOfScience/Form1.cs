using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class Form1 : Form
    {
        private Game game;       // объект будет управлять игроком, врагами..
        private Timer gameTimer;
        private Image background;

        public Form1()
        {
            InitializeComponent();

            // настройки окна 
            this.DoubleBuffered = true;  // убирает мерцание при отрисовке
            this.BackColor = Color.Black;
            this.Text = "Digger (WinForms)";
            this.KeyPreview = true;       // перехватывает клавиши до других контролов

            // создаём временную игру чтобы узнать размеры уровня
            var tempGame = new Game();
            var terrain = tempGame.Terrain;

            this.ClientSize = new Size(
                terrain.Width * 32,
                terrain.Height * 32
            );

            // фиксируем размер окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // создаём игру по карте
            game = new Game();

            // настройка таймера
            gameTimer = new Timer();
            gameTimer.Interval = 30; // ~33 кадра в секунду
            gameTimer.Tick += (s, e) =>
            {
                game?.Update();  // обновляем состояние игры
                Invalidate();   // перерисовываем окно (вызовет OnPaint)
            };
            gameTimer.Start();

            // подписываемся на событие "нажатие клавиши"
            this.KeyDown += (s, e) => game.OnKeyDown(e.KeyCode);
            background = Image.FromFile("Images/Background.png");
        }

        // вызывается каждый раз, когда нужно перерисовать окно
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);    // базовая отрисовка

            using (var attrs = new System.Drawing.Imaging.ImageAttributes())
            {
                var colorMatrix = new System.Drawing.Imaging.ColorMatrix();
                colorMatrix.Matrix33 = 0.5f; // прозрачность 60%
                attrs.SetColorMatrix(colorMatrix);

                e.Graphics.DrawImage(
                    background,
                    new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                    0, 0, background.Width, background.Height,
                    GraphicsUnit.Pixel,
                    attrs
                );
            }

            game?.Draw(e.Graphics); // рисуем всё, что есть в игре
        }
    }
}
