using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Game
    {
        private Player player;   // игрок
        private Teacher teacher;
        private Level level;

        private bool isGameOver = false;

        public Terrain Terrain => level.Terrain;   // доступ к карте

        public Game()
        {
            level = new Level();

            // создаём игрока по координатам из Terrain
            player = new Player(Terrain.PlayerStartX, Terrain.PlayerStartY);

            // создаём преподавателя
            teacher = new Teacher(Terrain.TeacherStartX, Terrain.TeacherStartY, player);

            // копаем стартовую клетку
            Terrain.Dig(player.TileX, player.TileY);
        }

        // обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            if (!isGameOver)
                player.Move(key, Terrain);
        }

        // Обновление состояния игры
        public void Update()
        {

            if (isGameOver) return;
 
            player.Update();

            //преподаватель движется к игроку 
            teacher.Update();

            if (teacher.IsPlayerCaught())
            {
                GameOver();
            }
        }

        // отрисовка всех элементов игры
        public void Draw(Graphics g)
        {
            Terrain.Draw(g);
            player.Draw(g);
            teacher.Draw(g);
        }

        private void GameOver()
        {
            isGameOver = true;

            // Только одно окно сообщения
            DialogResult result = MessageBox.Show(
                "Вас поймали! Игра окончена.\nХотите начать заново?",
                "Игра окончена",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            );

            if (result == DialogResult.Yes)
            {
                Application.Restart();  
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
