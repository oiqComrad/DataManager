
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.loadDataBase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.drawHist = new System.Windows.Forms.ToolStripMenuItem();
            this.drawFunc = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.построитьГистограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataBase,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Загрузить";
            // 
            // loadDataBase
            // 
            this.loadDataBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadDataBase.Image = ((System.Drawing.Image)(resources.GetObject("loadDataBase.Image")));
            this.loadDataBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadDataBase.Name = "loadDataBase";
            this.loadDataBase.Size = new System.Drawing.Size(29, 29);
            this.loadDataBase.Text = "toolStripButton1";
            this.loadDataBase.ToolTipText = "Загрузить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawHist,
            this.drawFunc});
            this.toolStripDropDownButton1.Image = global::DataManager.Properties.Resources.Histogram;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 29);
            this.toolStripDropDownButton1.Text = "Построить";
            // 
            // drawHist
            // 
            this.drawHist.Name = "drawHist";
            this.drawHist.Size = new System.Drawing.Size(180, 22);
            this.drawHist.Text = "&Гистограмму";
            // 
            // drawFunc
            // 
            this.drawFunc.Name = "drawFunc";
            this.drawFunc.Size = new System.Drawing.Size(180, 22);
            this.drawFunc.Text = "&График ";
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
            this.dataBaseView.Size = new System.Drawing.Size(813, 358);
            this.dataBaseView.TabIndex = 1;
            this.dataBaseView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBaseViewCellMouseEnter);
            this.dataBaseView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataBaseViewColumnHeaderMouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.построитьГистограммуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 26);
            // 
            // построитьГистограммуToolStripMenuItem
            // 
            this.построитьГистограммуToolStripMenuItem.Name = "построитьГистограммуToolStripMenuItem";
            this.построитьГистограммуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.построитьГистограммуToolStripMenuItem.Text = "&Построить гистограмму";
            this.построитьГистограммуToolStripMenuItem.Click += new System.EventHandler(this.DrawHistogram);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(160, 29);
            this.toolStripLabel1.Text = "Среднее значение: ";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel1.Visible = false;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(130, 29);
            this.toolStripLabel2.Text = "Медиана:";
            this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel2.Visible = false;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.AutoSize = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(240, 29);
            this.toolStripLabel3.Text = "Среднеквадратичное отклонение";
            this.toolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel3.Visible = false;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.AutoSize = false;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(130, 29);
            this.toolStripLabel4.Text = "Дисперсия:";
            this.toolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel4.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 390);
            this.Controls.Add(this.dataBaseView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton loadDataBase;
        private System.Windows.Forms.DataGridView dataBaseView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem построитьГистограммуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem drawHist;
        private System.Windows.Forms.ToolStripMenuItem drawFunc;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
    }
}

