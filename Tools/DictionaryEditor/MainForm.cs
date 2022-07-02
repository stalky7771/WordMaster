using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using WordMaster;

namespace WordMasterEditor
{
	public partial class MainForm : Form
	{
		private DictionaryManager DictionaryManager => Context.DictionaryManager;

		[DllImport("user32.dll")]

		static public extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);
		private const uint SB_VERT = 1;

		public MainForm()
		{
			InitializeComponent();

			DictionaryManager.OnShowDictionary += OnShowDictionary;
			DictionaryManager.OnUpdateStatusBar += OnUpdateStatusBar;

			//ShowScrollBar(this.listViewWords.Handle, (int)SB_VERT, true);
		}

		private void OnUpdateStatusBar(string text)
		{
			statusStrip.Items[0].Text = text;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var filePath = DictionaryManager.FileName;

			if (string.IsNullOrEmpty(filePath))
			{
				if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
					return;

				filePath = saveFileDialog.FileName;
			}

			if (DictionaryManager.Dictionary == null)
				return;

            var json = PersistenceHelper.SaveToJson(new DictionaryDto(DictionaryManager.Dictionary));
            PersistenceHelper.WriteToFile(filePath, json);
		}

		private void OnShowDictionary(Dictionary dictionary)
		{
			//statusStrip.Items[0].Text = $"Dictionary contain {dictionary.Words.Count} words";

			listViewWords.Items.Clear();

			int index = 1;
			foreach (var w in dictionary.Words)
			{
				string[] row =
				{
					$"{index++}",
					w.Value,
					w.Translation,
					w.Transcription != string.Empty ? $"[{w.Transcription}]" : string.Empty,
					w.Example
				};
				var listViewItem = new ListViewItem(row);
				listViewWords.Items.Add(listViewItem);
			}
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			DictionaryManager.Load(openFileDialog.FileName);
		}

		private void listViewWords_MouseClick(object sender, MouseEventArgs e)
		{
			listViewWords_SelectedIndexChanged(sender, e);
		}

		private void listViewWords_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewWords.FocusedItem == null)
				return;

			int focusedIndex = listViewWords.FocusedItem.Index;

			DictionaryManager.SetFocusedIndex(focusedIndex);
			var word = DictionaryManager.Dictionary.GetWordItem(focusedIndex);
			ShowWord(word);
		}

		private void ShowWord(Word word)
		{
			if (word == null)
				return;

			tbWord.Text = word.Value;
			tbTranslate.Text = word.Translation;
			tbTranskription.Text = word.Transcription;
			tbExample.Text = word.Example;
		}

		private void ClearEditForm()
		{
			tbWord.Text = string.Empty;
			tbTranslate.Text = string.Empty;
			tbTranskription.Text = string.Empty;
			tbExample.Text = string.Empty;
		}

		private void FocusItem(ListView listView, int index)
		{
			if (listViewWords.Items.Count == 0)
				return;

			if (index > listViewWords.Items.Count - 1)
				index = listViewWords.Items.Count - 1;

			listView.Items[index].Focused = true;
			listView.Items[index].Selected = true;
			listView.Items[index].EnsureVisible();
			listView.Select();
		}

		private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Word word = new Word();
			word.SetData(Word.DataType.Value, tbWord.Text);
			word.SetData(Word.DataType.Translation, tbTranslate.Text);
			word.SetData(Word.DataType.Transcription, tbTranskription.Text);
			word.SetData(Word.DataType.Description, tbExample.Text);

			ClearEditForm();

			DictionaryManager.AddWord(word);
		}

		private void upToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var word = new Word();
			word.SetData(Word.DataType.Value, tbWord.Text);
			word.SetData(Word.DataType.Translation, tbTranslate.Text);
			word.SetData(Word.DataType.Transcription, tbTranskription.Text);
			word.SetData(Word.DataType.Description, tbExample.Text);

			ClearEditForm();

			DictionaryManager.UpdateWord(word);
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listViewWords.FocusedItem == null)
				return;

			int focusedIndex = listViewWords.FocusedItem.Index;

			DictionaryManager.RemoveWord(listViewWords.FocusedItem.Index);
			OnShowDictionary(DictionaryManager.Dictionary);

			FocusItem(listViewWords, focusedIndex);
		}

		private void listViewWords_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
		{
			Console.Write("Column Resizing");
			e.NewWidth = this.listViewWords.Columns[e.ColumnIndex].Width;
			e.Cancel = true;
		}

		private void cSVToDictToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			DictionaryManager.ConvertCSVtoDictionary(openFileDialog.FileName);
		}
	}
}
