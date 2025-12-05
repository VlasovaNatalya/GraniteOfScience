using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GraniteOfScience
{
    public partial class SpeedSettingsForm : Form
    {
        public SpeedSettingsForm()
        {
            InitializeComponent();

            numericUpDownSpeed.DecimalPlaces = 1;
            numericUpDownSpeed.Minimum = (decimal)GameSettings.MinSpeed;
            numericUpDownSpeed.Maximum = (decimal)GameSettings.MaxSpeed;
            numericUpDownSpeed.Value = (decimal)GameSettings.PlayerSpeed;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            GameSettings.PlayerSpeed = (float)numericUpDownSpeed.Value;
            MessageBox.Show("Скорость сохранена!");
            this.Close();
        }
    }
}
