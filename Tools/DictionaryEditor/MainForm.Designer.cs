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
			this.cSVToDictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.chExampleTranslate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.textType = new System.Windows.Forms.TextBox();
			this.textExampleTranslation = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textExample = new System.Windows.Forms.TextBox();
			this.textTranskription = new System.Windows.Forms.TextBox();
			this.textTranslate = new System.Windows.Forms.TextBox();
			this.textWord = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
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
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.fileToolStripMenuItem.Text = "Файл";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// cSVToDictToolStripMenuItem
			// 
			this.cSVToDictToolStripMenuItem.Name = "cSVToDictToolStripMenuItem";
			this.cSVToDictToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.cSVToDictToolStripMenuItem.Text = "CSV to Dict";
			this.cSVToDictToolStripMenuItem.Click += new System.EventHandler(this.cSVToDictToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip.Location = new System.Drawing.Point(0, 716);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1131, 22);
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
            this.chExample,
            this.chExampleTranslate,
            this.chType});
			this.listViewWords.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listViewWords.FullRowSelect = true;
			this.listViewWords.GridLines = true;
			this.listViewWords.HideSelection = false;
			this.listViewWords.Location = new System.Drawing.Point(12, 285);
			this.listViewWords.Name = "listViewWords";
			this.listViewWords.Size = new System.Drawing.Size(1107, 428);
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
			this.chWord.Text = "Слово";
			this.chWord.Width = 138;
			// 
			// chTranslation
			// 
			this.chTranslation.Text = "Перевод";
			this.chTranslation.Width = 129;
			// 
			// chTranskription
			// 
			this.chTranskription.Text = "Транскрипция";
			this.chTranskription.Width = 118;
			// 
			// chExample
			// 
			this.chExample.Text = "Пример";
			this.chExample.Width = 176;
			// 
			// chExampleTranslate
			// 
			this.chExampleTranslate.Text = "Пример (перевод)";
			this.chExampleTranslate.Width = 150;
			// 
			// chType
			// 
			this.chType.Text = "Тип";
			this.chType.Width = 150;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonDelete);
			this.panel1.Controls.Add(this.buttonUpdate);
			this.panel1.Controls.Add(this.buttonAdd);
			this.panel1.Controls.Add(this.textType);
			this.panel1.Controls.Add(this.textExampleTranslation);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.textExample);
			this.panel1.Controls.Add(this.textTranskription);
			this.panel1.Controls.Add(this.textTranslate);
			this.panel1.Controls.Add(this.textWord);
			this.panel1.Location = new System.Drawing.Point(12, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1107, 252);
			this.panel1.TabIndex = 7;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(543, 89);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(116, 26);
			this.buttonDelete.TabIndex = 14;
			this.buttonDelete.Text = "Удалить";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(543, 52);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(116, 26);
			this.buttonUpdate.TabIndex = 13;
			this.buttonUpdate.Text = "Обновить";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(543, 14);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(116, 26);
			this.buttonAdd.TabIndex = 12;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// textType
			// 
			this.textType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textType.Location = new System.Drawing.Point(161, 199);
			this.textType.Name = "textType";
			this.textType.Size = new System.Drawing.Size(344, 26);
			this.textType.TabIndex = 11;
			// 
			// textExampleTranslation
			// 
			this.textExampleTranslation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textExampleTranslation.Location = new System.Drawing.Point(161, 162);
			this.textExampleTranslation.Name = "textExampleTranslation";
			this.textExampleTranslation.Size = new System.Drawing.Size(344, 26);
			this.textExampleTranslation.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(14, 207);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 20);
			this.label6.TabIndex = 9;
			this.label6.Text = "Тип";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(14, 169);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Пример (перевод)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(14, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 20);
			this.label4.TabIndex = 7;
			this.label4.Text = "Пример";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(14, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Транскрипция";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(14, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Перевод";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(14, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Слово";
			// 
			// textExample
			// 
			this.textExample.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textExample.Location = new System.Drawing.Point(161, 125);
			this.textExample.Name = "textExample";
			this.textExample.Size = new System.Drawing.Size(344, 26);
			this.textExample.TabIndex = 3;
			// 
			// textTranskription
			// 
			this.textTranskription.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textTranskription.Location = new System.Drawing.Point(161, 88);
			this.textTranskription.Name = "textTranskription";
			this.textTranskription.Size = new System.Drawing.Size(344, 26);
			this.textTranskription.TabIndex = 2;
			// 
			// textTranslate
			// 
			this.textTranslate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textTranslate.Location = new System.Drawing.Point(161, 51);
			this.textTranslate.Name = "textTranslate";
			this.textTranslate.Size = new System.Drawing.Size(344, 26);
			this.textTranslate.TabIndex = 1;
			// 
			// textWord
			// 
			this.textWord.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textWord.Location = new System.Drawing.Point(161, 14);
			this.textWord.Name = "textWord";
			this.textWord.Size = new System.Drawing.Size(344, 26);
			this.textWord.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1131, 738);
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
		private System.Windows.Forms.TextBox textWord;
		private System.Windows.Forms.TextBox textTranslate;
		private System.Windows.Forms.TextBox textTranskription;
		private System.Windows.Forms.TextBox textExample;
		private System.Windows.Forms.ColumnHeader chExample;
		private System.Windows.Forms.ToolStripMenuItem cSVToDictToolStripMenuItem;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.TextBox textType;
		private System.Windows.Forms.TextBox textExampleTranslation;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader chExampleTranslate;
		private System.Windows.Forms.ColumnHeader chType;
	}
}

