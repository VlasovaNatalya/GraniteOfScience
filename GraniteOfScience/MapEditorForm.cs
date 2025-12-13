using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class MapEditorForm : Form
    {
        private const int TileSize = 32;
        private const int GridWidth = 40;  // ширина карты в тайлах
        private const int GridHeight = 20; // высота карты в тайлах

        private Button[,] grid;
        private int currentLevel = 1;//текущий уровень 

        private string LevelsPath;


        public MapEditorForm()
        {
            InitializeComponent();

            string folder = Application.StartupPath;

            // Ищем папку GraniteOfScience вверх по дереву
            while (Path.GetFileName(folder) != "GraniteOfScience")
                folder = Directory.GetParent(folder).FullName;

            LevelsPath = Path.Combine(folder, "Levels");

            comboCellType.SelectedIndex = 1;
            CreateGrid();

            // по умолчанию будем ставить землю
            comboCellType.SelectedIndex = 1; // "Земля"

            CreateGrid();
        }

        // Проверяет, есть ли уже символ на карте
        private bool ContainsSymbol(char symbol)
        {
            foreach (var cell in grid)
                if (cell.Text == symbol.ToString())
                    return true;

            return false;
        }

        // Удаляет остальные такие же символы, кроме выбранного
        private void RemoveOther(char symbol, Button except)
        {
            foreach (var cell in grid)
            {
                if (cell != except && cell.Text == symbol.ToString())
                {
                    cell.Text = " ";
                    cell.BackColor = Color.White;
                }
            }
        }


        private void CreateGrid()
        {
            grid = new Button[GridHeight, GridWidth];

            panelGrid.Width = GridWidth * TileSize;
            panelGrid.Height = GridHeight * TileSize;

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    var cell = new Button();
                    cell.Width = TileSize;
                    cell.Height = TileSize;
                    cell.Left = x * TileSize;
                    cell.Top = y * TileSize;
                    cell.Tag = new Point(x, y);
                    cell.FlatStyle = FlatStyle.Flat;
                    cell.Margin = Padding.Empty;
                    cell.Padding = Padding.Empty;
                    cell.Text = " "; // по умолчанию пусто
                    cell.Font = new Font(FontFamily.GenericSansSerif, 6);

                    cell.Click += OnCellClick;

                    panelGrid.Controls.Add(cell);
                    grid[y, x] = cell;
                }
            }
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string mode = comboCellType.Text;

            switch (mode)
            {
                case "Пусто":
                    btn.Text = " ";
                    btn.BackColor = Color.White;
                    break;

                case "Земля":
                    btn.Text = "T";
                    btn.BackColor = Color.SandyBrown;
                    break;

                case "Стена":
                    btn.Text = "D";
                    btn.BackColor = Color.Gray;
                    break;

                case "Игрок":
                    if (ContainsSymbol('P'))
                    {
                        MessageBox.Show("На карте уже есть игрок!");
                        return;
                    }
                    btn.Text = "P";
                    btn.BackColor = Color.Yellow;
                    RemoveOther('P', btn);
                    break;

                case "Преподаватель":
                    if (ContainsSymbol('R'))
                    {
                        MessageBox.Show("На карте уже есть преподаватель!");
                        return;
                    }
                    btn.Text = "R";
                    btn.BackColor = Color.Red;
                    RemoveOther('R', btn);
                    break;
                case "Энергетик":
                    btn.Text = "E";
                    btn.BackColor = Color.Green;
                    break;
                case "Ноутбук":
                    btn.Text = "L";
                    btn.BackColor = Color.Green;
                    break;
                case "Тетрадь":
                    btn.Text = "N";
                    btn.BackColor = Color.Green;
                    break;
                case "Карта":
                    btn.Text = "C";
                    btn.BackColor = Color.Green;
                    break;
                case "Ответы":
                    btn.Text = "X";
                    btn.BackColor = Color.Green;
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Создаём папку Levels, если она ещё не существует
            Directory.CreateDirectory(LevelsPath);

            string result = "";

            for (int y = 0; y < GridHeight; y++)
            {
                string line = "";
                for (int x = 0; x < GridWidth; x++)
                {
                    var t = grid[y, x].Text;
                    if (string.IsNullOrEmpty(t))
                        line += " ";
                    else
                        line += t[0];
                }
                result += line.TrimEnd() + "\n";
            }
            string selectedLevel = levelNumber.Text;

            // определяем какой уровень выбран
            string fileName;

            if (levelNumber.Text == "Уровень 1")
                fileName = "level1.txt";
            else if (levelNumber.Text == "Уровень 2")
                fileName = "level2.txt";
            else
                fileName = "level1.txt";

            string fullPath = Path.Combine(LevelsPath, fileName);

            // записываем файл
            File.WriteAllText(fullPath, result);

            MessageBox.Show($"Карта сохранена в {fullPath}");
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboCellType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
