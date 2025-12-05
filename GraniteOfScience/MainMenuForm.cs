using System;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();
            gameForm.ShowDialog();
        }

        private void buttonEditor_Click(object sender, EventArgs e)
        {
            MapEditorForm editor = new MapEditorForm();
            editor.Show();
        }

        private void buttonSpeed_Click(object sender, EventArgs e)
        {
            SpeedSettingsForm speed = new SpeedSettingsForm();
            speed.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
