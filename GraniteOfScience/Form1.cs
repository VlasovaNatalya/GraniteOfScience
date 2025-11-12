using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class Form1 : Form
    {
        private Game game;       // объект будет управлять игроком, врагами..
        private Timer gameTimer;

        public Form1()
        {
            InitializeComponent();

            // Настройки окна 
            this.DoubleBuffered = true;  // убирает мерцание при отрисовке
            this.Width = 800;
            this.Height = 600;
            this.BackColor = Color.Black;
            this.Text = "Digger (WinForms)";
            this.KeyPreview = true;       // перехватывает клавиши до других контролов

            // Создаём экземпляр игры
            game = new Game();

            // Настройка таймера
            gameTimer = new Timer();
            gameTimer.Interval = 30; // ~33 кадра в секунду
            gameTimer.Tick += (s, e) =>
            {
                game.Update();  // обновляем состояние игры
                Invalidate();   // перерисовываем окно (вызовет OnPaint)
            };
            gameTimer.Start();

            // Подписываемся на событие "нажатие клавиши"
            this.KeyDown += (s, e) => game.OnKeyDown(e.KeyCode);
        }

        // вызывается каждый раз, когда нужно перерисовать окно
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);    // базовая отрисовка
            game.Draw(e.Graphics); // рисуем всё, что есть в игре
        }
    }
}
