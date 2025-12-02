using System.Drawing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public class Game
    {
        private Player player;   // игрок
        public Terrain Terrain { get; } // карта (доступна наружу при необходимости)

        public Game(Terrain terrain)
        {
            Terrain = terrain;

            // создаём игрока по координатам из Terrain
            player = new Player(Terrain.PlayerStartX, Terrain.PlayerStartY);

            // копаем стартовую клетку
            Terrain.Dig(player.TileX, player.TileY);
        }

        // обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            player.Move(key, Terrain);
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
            Terrain.Draw(g);
            player.Draw(g);
        }
    }
}
