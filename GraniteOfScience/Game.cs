using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GraniteOfScience
{
    public class Game
    {
        private Player player;   // игрок
        private Teacher teacher;
        private Level level;
        private List<IArtifact> artifacts = new List<IArtifact>();

        private bool isGameOver = false;
        private bool isLevelCompleted = false;

        private Font uiFont = new Font("Arial", 14, FontStyle.Bold);
        private int currentLevel = 1;
        private const int LEVEL1_REQUIRED = 3;
        private const int LEVEL2_REQUIRED = 2;
        private int collectedArtifacts = 0;

        public Terrain Terrain => level.Terrain;   // доступ к карте

        public Game()
        {
            LoadLevel(1);

        }

        private void LoadLevel(int levelNumber)
        {
            currentLevel = levelNumber;
            level = new Level(levelNumber);
            isLevelCompleted = false;

            // Создаём игрока
            player = new Player(Terrain.PlayerStartX, Terrain.PlayerStartY);

            // Создаём преподавателя
            teacher = new Teacher(Terrain.TeacherStartX, Terrain.TeacherStartY, player);

            Terrain.Dig(player.TileX, player.TileY);
  
            collectedArtifacts = 0;

            LoadArtifactsForLevel(levelNumber);
        }

        //загрузка артефактов для уровня
        private void LoadArtifactsForLevel(int levelNumber)
        {
            artifacts.Clear();

            if (levelNumber == 1)
            {
                FindAndAddArtifactsFromMap('E', (x, y) => new EnergyArtifact(x, y));
                FindAndAddArtifactsFromMap('L', (x, y) => new LaptopArtifact(x, y));
                FindAndAddArtifactsFromMap('N', (x, y) => new NotebookArtifact(x, y));

            }
            else if (levelNumber == 2)
            {
               
                FindAndAddArtifactsFromMap('C', (x, y) => new CardArtifact(x, y));
                FindAndAddArtifactsFromMap('X', (x, y) => new ReportArtifact(x, y));
               
            }
        }

        private void FindAndAddArtifactsFromMap(char symbol, Func<int, int, ArtifactBase> artifactFactory)
        {
            // Ищем все артефакты указанного типа в Terrain
            foreach (var artifactPos in Terrain.ArtifactPositions)
            {
                if (artifactPos.Type == symbol)
                {
                    // Проверяем, подходит ли артефакт для текущего уровня
                    if ((currentLevel == 1 && (symbol == 'E' || symbol == 'L' || symbol == 'N')) ||
                        (currentLevel == 2 && (symbol == 'C' || symbol == 'X')))
                    {
                        artifacts.Add(artifactFactory(artifactPos.X, artifactPos.Y));
                    }
                }
            }
        }

        // обработка нажатий клавиш
        public void OnKeyDown(Keys key)
        {
            if (!isGameOver && !isLevelCompleted)
                player.Move(key, Terrain);
        }

        // Обновление состояния игры
        public void Update()
        {

            if (isGameOver || isLevelCompleted) return;
 
            player.Update();

            //преподаватель движется к игроку 
            teacher.Update();

            CheckArtifactCollection();

            if (teacher.IsPlayerCaught())
            {
                GameOver();
            }
        }

        //проверяем все ли артефакты собраны 
        private void CheckArtifactCollection()
        {
            for (int i = artifacts.Count - 1; i >= 0; i--)
            {
                var artifact = artifacts[i];
                if (!artifact.IsCollected && artifact.CheckCollision(player.TileX, player.TileY))
                {
                    artifact.Collect();
                    collectedArtifacts++;
                    CheckLevelCompletion();
                }
            }
        }

        //проверяем пройден ли уровень
        private void CheckLevelCompletion()
        {
            if (currentLevel == 1 && collectedArtifacts >= LEVEL1_REQUIRED)
            {
                isLevelCompleted = true;

                // Таймер для задержки перед показом сообщения
                Timer timer = new Timer();
                timer.Interval = 500; 
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    timer.Dispose();

                    MessageBox.Show($"Вы собрали все {LEVEL1_REQUIRED} артефакта!\nПерейти на следующий уровень",
                                  " ",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    LoadLevel(2);
                };
                timer.Start();
            }
            else if (currentLevel == 2 && collectedArtifacts >= LEVEL2_REQUIRED)
            {
                isLevelCompleted = true;

                Timer timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    timer.Dispose();
                    GameWin();
                };
                timer.Start();
            }
        }

        //отрисовка сколько артефактов собрано
        private void DrawUI(Graphics g)
        {
            string artifactText = $"Артефакты: {collectedArtifacts}/{(currentLevel == 1 ? LEVEL1_REQUIRED : LEVEL2_REQUIRED)}";
            string levelText = $"Уровень: {currentLevel}";

            int panelWidth = 110;  
            int panelHeight = 30;  
            Font smallFont = new Font("Arial", 9, FontStyle.Bold);

            g.FillRectangle(Brushes.Black, 0, 0, panelWidth, panelHeight);
            g.DrawString(artifactText, smallFont, Brushes.White, 10,6);
            g.DrawString(levelText, smallFont, Brushes.White, 10, 16);
        }

        // отрисовка всех элементов игры
        public void Draw(Graphics g)
        {
            Terrain.Draw(g);

            //артефакты
            foreach (var artifact in artifacts)
            {
                if (artifact is ArtifactBase artifactBase && !artifact.IsCollected)
                {
                    artifactBase.Draw(g);
                }
            }

            // 3. Рисуем игрока
            player.Draw(g);

            // 4. Рисуем преподавателя
            teacher.Draw(g);

            // 5. Рисуем UI
            DrawUI(g);
        }
        

        private void GameOver()
        {
            isGameOver = true;

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

        private void GameWin()
        {
            isGameOver = true;

            MessageBox.Show(
                $"Поздравляем! Вы собрали все артефакты на уровне {currentLevel}!\nИгра пройдена!",
                "Победа!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Application.Exit();
        }
    }
}