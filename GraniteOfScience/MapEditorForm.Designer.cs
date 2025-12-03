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
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(12, 42);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(226, 108);
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
            "Преподаватель"});
            this.comboCellType.Location = new System.Drawing.Point(12, 12);
            this.comboCellType.Name = "comboCellType";
            this.comboCellType.Size = new System.Drawing.Size(121, 24);
            this.comboCellType.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(150, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 24);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить карту";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MapEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboCellType);
            this.Controls.Add(this.panelGrid);
            this.Name = "MapEditorForm";
            this.Text = "MapEditorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.ComboBox comboCellType;
        private System.Windows.Forms.Button buttonSave;
    }
}