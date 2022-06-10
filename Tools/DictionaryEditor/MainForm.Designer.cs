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
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.listViewWords = new System.Windows.Forms.ListView();
			this.chCounter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTranslation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chTranskription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.textBoxTranskription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.textBoxTranslate = new System.Windows.Forms.TextBox();
			this.textBoxWord = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1188, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
			this.testToolStripMenuItem.Text = "Test";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip.Location = new System.Drawing.Point(0, 629);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1188, 22);
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
			this.openFileDialog.Filter = "Dictionaries|*.dict";
			// 
			// listViewWords
			// 
			this.listViewWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.listViewWords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCounter,
            this.chWord,
            this.chTranslation,
            this.chTranskription});
			this.listViewWords.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewWords.FullRowSelect = true;
			this.listViewWords.GridLines = true;
			this.listViewWords.HideSelection = false;
			this.listViewWords.Location = new System.Drawing.Point(12, 27);
			this.listViewWords.Name = "listViewWords";
			this.listViewWords.Size = new System.Drawing.Size(714, 599);
			this.listViewWords.TabIndex = 5;
			this.listViewWords.UseCompatibleStateImageBehavior = false;
			this.listViewWords.View = System.Windows.Forms.View.Details;
			this.listViewWords.SelectedIndexChanged += new System.EventHandler(this.listViewWords_SelectedIndexChanged);
			this.listViewWords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewWords_MouseClick);
			// 
			// chCounter
			// 
			this.chCounter.Text = "#";
			this.chCounter.Width = 42;
			// 
			// chWord
			// 
			this.chWord.Text = "Word";
			this.chWord.Width = 196;
			// 
			// chTranslation
			// 
			this.chTranslation.Text = "Translation";
			this.chTranslation.Width = 318;
			// 
			// chTranskription
			// 
			this.chTranskription.Text = "Transkription";
			this.chTranskription.Width = 153;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.buttonUpdate);
			this.panel1.Controls.Add(this.textBoxTranskription);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.buttonRemove);
			this.panel1.Controls.Add(this.buttonAdd);
			this.panel1.Controls.Add(this.textBoxTranslate);
			this.panel1.Controls.Add(this.textBoxWord);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(735, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(441, 210);
			this.panel1.TabIndex = 7;
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(293, 154);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(115, 32);
			this.buttonUpdate.TabIndex = 16;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// textBoxTranskription
			// 
			this.textBoxTranskription.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTranskription.Location = new System.Drawing.Point(142, 101);
			this.textBoxTranskription.Name = "textBoxTranskription";
			this.textBoxTranskription.Size = new System.Drawing.Size(280, 23);
			this.textBoxTranskription.TabIndex = 15;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(16, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 24);
			this.label3.TabIndex = 14;
			this.label3.Text = "Transcription";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point(167, 154);
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size(115, 32);
			this.buttonRemove.TabIndex = 13;
			this.buttonRemove.Text = "Remove";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(41, 154);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(115, 32);
			this.buttonAdd.TabIndex = 11;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAddWord_Click);
			// 
			// textBoxTranslate
			// 
			this.textBoxTranslate.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTranslate.Location = new System.Drawing.Point(142, 60);
			this.textBoxTranslate.Name = "textBoxTranslate";
			this.textBoxTranslate.Size = new System.Drawing.Size(280, 23);
			this.textBoxTranslate.TabIndex = 10;
			// 
			// textBoxWord
			// 
			this.textBoxWord.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxWord.Location = new System.Drawing.Point(142, 19);
			this.textBoxWord.Name = "textBoxWord";
			this.textBoxWord.Size = new System.Drawing.Size(280, 23);
			this.textBoxWord.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(16, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 24);
			this.label2.TabIndex = 8;
			this.label2.Text = "Translate";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Droid Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(16, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 18);
			this.label1.TabIndex = 7;
			this.label1.Text = "Word";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1188, 651);
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
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ListView listViewWords;
		private System.Windows.Forms.ColumnHeader chWord;
		private System.Windows.Forms.ColumnHeader chTranslation;
		private System.Windows.Forms.ColumnHeader chTranskription;
		private System.Windows.Forms.ColumnHeader chCounter;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBoxWord;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.TextBox textBoxTranslate;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.TextBox textBoxTranskription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonUpdate;
	}
}

