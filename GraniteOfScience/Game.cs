using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Game
    {
        private Player player;

        public Game()
        {
            player = new Player("Images/Digger.png");
        }

        // Обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            player.Move(key);
        }

        // Обновление состояния игры
        public void Update()
        {
            // потом появится логика 
        }

        // отрисовка всех элементов игры
        public void Draw(Graphics g)
        {
            player.Draw(g); // рисуем игрока
        }
    }
}
