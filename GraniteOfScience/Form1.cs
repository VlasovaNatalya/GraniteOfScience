using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class Form1 : Form
    {
        private Game game;       // объект будет управлять игроком, врагами..
        public static Game CurrentGame { get; private set; }
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

            // загружаем уровень
            var level = new Level();
            var terrain = level.Terrain;

            // окно подстраивается под карту
            this.ClientSize = new Size(
                terrain.Width * 32,
                terrain.Height * 32
            );

            // фиксируем размер окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // создаём игру по карте
            game = new Game();
            CurrentGame = game;

            // загружаем фон
            background = Image.FromFile("Images/Background.png");

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
        }

        // вызывается каждый раз, когда нужно перерисовать окно
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);    // базовая отрисовка

            // фон (полупрозрачный)
            using (var attrs = new System.Drawing.Imaging.ImageAttributes())
            {
                var colorMatrix = new System.Drawing.Imaging.ColorMatrix();
                colorMatrix.Matrix33 = 0.5f; // прозрачность 50%
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
