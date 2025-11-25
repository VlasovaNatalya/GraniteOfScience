using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Game
    {
        private Player player;   // игрок
        private Level level;

        public Game()
        {
            level = new Level();

            // создаём игрока по координатам из Terrain
            player = new Player(level.Terrain.PlayerStartX, level.Terrain.PlayerStartY);
            level.Terrain.Dig(player.TileX, player.TileY);
        }

        public Terrain Terrain => level.Terrain;

        // обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            player.Move(key, level.Terrain);
        }

        // Обновление состояния игры
        public void Update()
        {
            // потом появится логика 
            player.Update();
        }

        // отрисовка всех элементов игры
        public void Draw(Graphics g)
        {
            level.Terrain.Draw(g);
            player.Draw(g);
        }
    }
}
