namespace GraniteOfScience
{
    partial class MapEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGrid = new System.Windows.Forms.Panel();
            this.comboCellType = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.levelNumber = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(18, 66);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(339, 169);
            this.panelGrid.TabIndex = 0;
            // 
            // comboCellType
            // 
            this.comboCellType.FormattingEnabled = true;
            this.comboCellType.Items.AddRange(new object[] {
            "Пусто",
            "Земля",
            "Стена",
            "Игрок",
            "Преподаватель",
            "Энергетик",
            "Ноутбук",
            "Тетрадь",
            "Карта",
            "Ответы"});
            this.comboCellType.Location = new System.Drawing.Point(18, 19);
            this.comboCellType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboCellType.Name = "comboCellType";
            this.comboCellType.Size = new System.Drawing.Size(180, 33);
            this.comboCellType.TabIndex = 1;
            this.comboCellType.SelectedIndexChanged += new System.EventHandler(this.comboCellType_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(380, 19);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(132, 38);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить карту";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // levelNumber
            // 
            this.levelNumber.FormattingEnabled = true;
            this.levelNumber.Items.AddRange(new object[] {
            "Уровень 1",
            "Уровень 2"});
            this.levelNumber.Location = new System.Drawing.Point(213, 19);
            this.levelNumber.Name = "levelNumber";
            this.levelNumber.Size = new System.Drawing.Size(144, 33);
            this.levelNumber.TabIndex = 4;
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.levelNumber);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboCellType);
            this.Controls.Add(this.panelGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MapEditorForm";
            this.Text = "Ы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.ComboBox comboCellType;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox levelNumber;
    }
}