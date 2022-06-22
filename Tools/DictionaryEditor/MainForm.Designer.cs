namespace WordMasterEditor
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.listViewWords = new System.Windows.Forms.ListView();
			this.chCounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTranslation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTranskription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chExample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbExample = new System.Windows.Forms.TextBox();
			this.tbTranskription = new System.Windows.Forms.TextBox();
			this.tbTranslate = new System.Windows.Forms.TextBox();
			this.tbWord = new System.Windows.Forms.TextBox();
			this.cSVToDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.upToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(887, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cSVToDictToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.toolsToolStripMenuItem.Text = "Add";
			this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
			// 
			// upToolStripMenuItem
			// 
			this.upToolStripMenuItem.Name = "upToolStripMenuItem";
			this.upToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.upToolStripMenuItem.Text = "Update";
			this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip.Location = new System.Drawing.Point(0, 552);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(887, 22);
			this.statusStrip.TabIndex = 3;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "dict";
			this.saveFileDialog.Filter = "Dictionaries|*.dict";
			this.saveFileDialog.Title = "Save dictionary";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// listViewWords
			// 
			this.listViewWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listViewWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCounter,
            this.chWord,
            this.chTranslation,
            this.chTranskription,
            this.chExample});
			this.listViewWords.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewWords.FullRowSelect = true;
			this.listViewWords.GridLines = true;
			this.listViewWords.HideSelection = false;
			this.listViewWords.Location = new System.Drawing.Point(12, 95);
			this.listViewWords.Name = "listViewWords";
			this.listViewWords.Size = new System.Drawing.Size(863, 454);
			this.listViewWords.TabIndex = 5;
			this.listViewWords.UseCompatibleStateImageBehavior = false;
			this.listViewWords.View = System.Windows.Forms.View.Details;
			this.listViewWords.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewWords_ColumnWidthChanging);
			this.listViewWords.SelectedIndexChanged += new System.EventHandler(this.listViewWords_SelectedIndexChanged);
			this.listViewWords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewWords_MouseClick);
			// 
			// chCounter
			// 
			this.chCounter.Text = "#";
			this.chCounter.Width = 51;
			// 
			// chWord
			// 
			this.chWord.Text = "Word";
			this.chWord.Width = 138;
			// 
			// chTranslation
			// 
			this.chTranslation.Text = "Translation";
			this.chTranslation.Width = 129;
			// 
			// chTranskription
			// 
			this.chTranskription.Text = "Transkription";
			this.chTranskription.Width = 118;
			// 
			// chExample
			// 
			this.chExample.Text = "Example";
			this.chExample.Width = 325;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbExample);
			this.panel1.Controls.Add(this.tbTranskription);
			this.panel1.Controls.Add(this.tbTranslate);
			this.panel1.Controls.Add(this.tbWord);
			this.panel1.Location = new System.Drawing.Point(12, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(863, 57);
			this.panel1.TabIndex = 7;
			// 
			// tbExample
			// 
			this.tbExample.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbExample.Location = new System.Drawing.Point(438, 20);
			this.tbExample.Name = "tbExample";
			this.tbExample.Size = new System.Drawing.Size(344, 23);
			this.tbExample.TabIndex = 3;
			this.tbExample.Text = "Example";
			// 
			// tbTranskription
			// 
			this.tbTranskription.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbTranskription.Location = new System.Drawing.Point(306, 20);
			this.tbTranskription.Name = "tbTranskription";
			this.tbTranskription.Size = new System.Drawing.Size(115, 23);
			this.tbTranskription.TabIndex = 2;
			this.tbTranskription.Text = "Transcrition";
			// 
			// tbTranslate
			// 
			this.tbTranslate.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbTranslate.Location = new System.Drawing.Point(156, 20);
			this.tbTranslate.Name = "tbTranslate";
			this.tbTranslate.Size = new System.Drawing.Size(133, 23);
			this.tbTranslate.TabIndex = 1;
			this.tbTranslate.Text = "Translate";
			// 
			// tbWord
			// 
			this.tbWord.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbWord.Location = new System.Drawing.Point(35, 20);
			this.tbWord.Name = "tbWord";
			this.tbWord.Size = new System.Drawing.Size(102, 23);
			this.tbWord.TabIndex = 0;
			this.tbWord.Text = "Word";
			// 
			// cSVToDictToolStripMenuItem
			// 
			this.cSVToDictToolStripMenuItem.Name = "cSVToDictToolStripMenuItem";
			this.cSVToDictToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cSVToDictToolStripMenuItem.Text = "CSV to Dict";
			this.cSVToDictToolStripMenuItem.Click += new System.EventHandler(this.cSVToDictToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 574);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.listViewWords);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dictionary";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ListView listViewWords;
		private System.Windows.Forms.ColumnHeader chWord;
		private System.Windows.Forms.ColumnHeader chTranslation;
		private System.Windows.Forms.ColumnHeader chTranskription;
		private System.Windows.Forms.ColumnHeader chCounter;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbWord;
		private System.Windows.Forms.TextBox tbTranslate;
		private System.Windows.Forms.TextBox tbTranskription;
		private System.Windows.Forms.TextBox tbExample;
		private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader chExample;
		private System.Windows.Forms.ToolStripMenuItem cSVToDictToolStripMenuItem;
	}
}

