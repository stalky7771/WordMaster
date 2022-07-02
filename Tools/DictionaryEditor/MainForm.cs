using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WordMaster;

namespace WordMasterEditor
{
	public partial class MainForm : Form
	{
		private DictionaryManager DictionaryManager => Context.DictionaryManager;

		[DllImport("user32.dll")]
        public static extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);
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
					w.Example,
					w.ExampleTranslation,
					w.Type
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

			textWord.Text = word.Value;
			textTranslate.Text = word.Translation;
			textTranskription.Text = word.Transcription;
			textExample.Text = word.Example;
            textExampleTranslation.Text = word.ExampleTranslation;
            textType.Text = word.Type;
        }

		private void ClearEditForm()
		{
			textWord.Text = string.Empty;
			textTranslate.Text = string.Empty;
			textTranskription.Text = string.Empty;
			textExample.Text = string.Empty;
			textExampleTranslation.Text = string.Empty;
            textType.Text = string.Empty;
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

        private Word GetWordFromTextBoxex()
        {
            WordBuilder wb = new WordBuilder();
            wb.Add(Word.DataType.Value, textWord.Text);
            wb.Add(Word.DataType.Translation, textTranslate.Text);
            wb.Add(Word.DataType.Transcription, textTranskription.Text);
            wb.Add(Word.DataType.Example, textExample.Text);
            wb.Add(Word.DataType.ExampleTranslation, textExampleTranslation.Text);
            wb.Add(Word.DataType.Type, textType.Text);

            return wb.ToWord;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DictionaryManager.AddWord(GetWordFromTextBoxex());
            ClearEditForm();
        }

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
            var word = GetWordFromTextBoxex();
            ClearEditForm();
            DictionaryManager.UpdateWord(word);
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
            if (listViewWords.FocusedItem == null)
                return;

            int focusedIndex = listViewWords.FocusedItem.Index;

            DictionaryManager.RemoveWord(listViewWords.FocusedItem.Index);
            OnShowDictionary(DictionaryManager.Dictionary);

            FocusItem(listViewWords, focusedIndex);
		}
	}
}
