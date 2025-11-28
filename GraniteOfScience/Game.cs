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

        public Game()
        {
            level = new Level();

            // создаём игрока по координатам из Terrain
            player = new Player(level.Terrain.PlayerStartX, level.Terrain.PlayerStartY);
            
            teacher = new Teacher(level.Terrain.TeacherStartX, level.Terrain.TeacherStartY, player);
           
            level.Terrain.Dig(player.TileX, player.TileY);
        }

        public Terrain Terrain => level.Terrain;

        // обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            if (!isGameOver)
                player.Move(key, level.Terrain);
        }

        // Обновление состояния игры
        public void Update()
        {

            if (isGameOver) return;

            // потом появится логика 
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
            level.Terrain.Draw(g);
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
