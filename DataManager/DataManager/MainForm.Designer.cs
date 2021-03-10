
namespace DataManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadDataBase = new System.Windows.Forms.ToolStripButton();
            this.dataBaseView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataBase});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // loadDataBase
            // 
            this.loadDataBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadDataBase.Image = ((System.Drawing.Image)(resources.GetObject("loadDataBase.Image")));
            this.loadDataBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadDataBase.Name = "loadDataBase";
            this.loadDataBase.Size = new System.Drawing.Size(29, 29);
            this.loadDataBase.Text = "toolStripButton1";
            // 
            // dataBaseView
            // 
            this.dataBaseView.AllowUserToAddRows = false;
            this.dataBaseView.AllowUserToDeleteRows = false;
            this.dataBaseView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataBaseView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataBaseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBaseView.Location = new System.Drawing.Point(0, 32);
            this.dataBaseView.Name = "dataBaseView";
            this.dataBaseView.ReadOnly = true;
            this.dataBaseView.RowTemplate.Height = 25;
            this.dataBaseView.Size = new System.Drawing.Size(800, 418);
            this.dataBaseView.TabIndex = 1;
            this.dataBaseView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBaseViewCellMouseEnter);
            this.dataBaseView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataBaseViewColumnHeaderMouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataBaseView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadDataBase;
        private System.Windows.Forms.DataGridView dataBaseView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

