using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 


namespace GraniteOfScience
{
    public interface IArtifact
    {
        string GetImageFileName();
        int GetDrawingPriority();
        bool IsCollected { get; }
        void Collect();
        bool CheckCollision(int playerX, int playerY);
        void Draw(Graphics g);
    }

    public abstract class ArtifactBase : IArtifact
    {
        public int TileX { get; protected set; }
        public int TileY { get; protected set; }
        public bool IsCollected { get; protected set; }//собран ли артефакт
        public abstract string GetImageFileName();//имя картинки
        public abstract string ArtifactType { get; }

        private Image sprite;
        private const int TileSize = 32;

        public ArtifactBase(int x, int y)
        {
            TileX = x;
            TileY = y;
            IsCollected = false;
            LoadImage();
        }

        private void LoadImage()
        {
            sprite = Image.FromFile($"Images/{GetImageFileName()}");
        }

        public void Draw(Graphics g)
        {
            if (!IsCollected && sprite != null)
            {
                g.DrawImage(sprite, TileX * TileSize, TileY * TileSize, TileSize, TileSize);
            }
        }

        public virtual int GetDrawingPriority()
        {
            return 4;
        }

        public void Collect()
        {
            if (!IsCollected)
            {
                IsCollected = true;
            }
        }

        public bool CheckCollision(int playerX, int playerY)
        {
            return !IsCollected && TileX == playerX && TileY == playerY;
        }

    }

    public class EnergyArtifact : ArtifactBase
    {
        public override string GetImageFileName() => "Energy.png";
        public override string ArtifactType => "Energy";

        public EnergyArtifact(int x, int y) : base(x, y) { }
    }

    public class LaptopArtifact : ArtifactBase
    {
        public override string GetImageFileName() => "Laptop.png";
        public override string ArtifactType => "Laptop";

        public LaptopArtifact(int x, int y) : base(x, y) { }
    }

    public class NotebookArtifact : ArtifactBase
    {
        public override string GetImageFileName() => "Notebook.png";
        public override string ArtifactType => "Notebook";

        public NotebookArtifact(int x, int y) : base(x, y) { }
    }

    public class CardArtifact : ArtifactBase
    {
        public override string GetImageFileName() => "Card.png";
        public override string ArtifactType => "Card";

        public CardArtifact(int x, int y) : base(x, y) { }
    }

    public class ReportArtifact : ArtifactBase
    {
        public override string GetImageFileName() => "Report.png";
        public override string ArtifactType => "Report";

        public ReportArtifact(int x, int y) : base(x, y) { }
    }

    // Класс управления артефактами и переходами между уровнями
    public static class ArtifactManager
    {
        //харним все объекты
        private static List<IArtifact> collectedArtifacts = new List<IArtifact>();
        private static int currentLevel = 1;

        // Требуемое количество артефактов для каждого уровня
        private const int Level1RequiredArtifacts = 3;
        private const int Level2RequiredArtifacts = 2;

        public static int CurrentLevel => currentLevel;
        public static int CollectedCount => collectedArtifacts.Count;
        public static int RequiredForCurrentLevel =>
            currentLevel == 1 ? Level1RequiredArtifacts : Level2RequiredArtifacts;

        public static event Action OnLevelCompleted;
        public static event Action OnGameWon;

        public static void CollectArtifact(IArtifact artifact)
        {
            if (!artifact.IsCollected)
            {
                artifact.Collect();
                collectedArtifacts.Add(artifact);

                // Проверяем условия прохождения этапа
                CheckLevelCompletion();
            }
        }

        private static void CheckLevelCompletion()
        {
            if (currentLevel == 1 && CollectedCount >= Level1RequiredArtifacts)
            {
                // Переход на уровень 2
                currentLevel = 2;
                collectedArtifacts.Clear(); // Сбрасываем счетчик 

                OnLevelCompleted?.Invoke();
            }
            else if (currentLevel == 2 && CollectedCount >= Level2RequiredArtifacts)
            {
                // Победа в игре
                OnGameWon?.Invoke();
            }
        }

        public static void Reset()
        {
            collectedArtifacts.Clear();
            currentLevel = 1;
        }

        public static string GetLevelStatus()
        {
            return $"Уровень {currentLevel}: {CollectedCount}/{RequiredForCurrentLevel} артефактов";
        }
    }
}
