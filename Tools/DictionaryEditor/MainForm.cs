using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WordMaster;

namespace WordMasterEditor
{
	public partial class MainForm : Form
	{
		private DictionaryManager DictionaryManager => Context.DictionaryManager;

		public MainForm()
		{
			InitializeComponent();

			DictionaryManager.OnShowDictionary += OnShowDictionary;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string filename = saveFileDialog.FileName;

			if (DictionaryManager.Dictionary == null)
				return;

			string json = JsonHelper.Serialize(new DictionaryDTO(Context.DictionaryManager.Dictionary));

			using (StreamWriter outputFile = new StreamWriter(filename))
			{
				outputFile.Write(json);
			}
		}

		private void testToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//WordForm newForm = new WordForm();
			//newForm.Show();
			DictionaryManager.ConvertDictionary();
		}

		private void OnShowDictionary(Dictionary dictionary)
		{
			//statusStrip.Items[0].Text = $"Dictionary contain {dictionary.Words.Count} words";

			listViewWords.Items.Clear();

			int index = 1;
			foreach (var wordItem in dictionary.Words)
			{
				string transcription = wordItem.Transcription != string.Empty
					? $"[{wordItem.Transcription}]"
					: string.Empty;

				string[] row =
				{
					$"{index++}",
					wordItem.Word,
					wordItem.Translation,
					transcription
				};
				var listViewItem = new ListViewItem(row);
				listViewWords.Items.Add(listViewItem);

				//listViewWords.Items[listViewWords.Items.Count - 1].SubItems[0].Text = "12345";
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

		private void ShowWord(WordItem word)
		{
			if (word == null)
				return;

			textBoxWord.Text = word.Word;
			textBoxTranslate.Text = word.Translation;
			textBoxTranskription.Text = word.Transcription;
		}

		private void buttonAddWord_Click(object sender, EventArgs e)
		{
			WordItem newWord = new WordItem(textBoxWord.Text,
				textBoxTranslate.Text,
				textBoxTranskription.Text);

			DictionaryManager.AddWord(newWord);
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			if (listViewWords.FocusedItem == null)
				return;

			int focusedIndex = listViewWords.FocusedItem.Index;

			DictionaryManager.RemoveWord(listViewWords.FocusedItem.Index);
			OnShowDictionary(DictionaryManager.Dictionary);

			FocusItem(listViewWords, focusedIndex);
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

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			WordItem word = new WordItem(textBoxWord.Text,
				textBoxTranslate.Text,
				textBoxTranskription.Text);

			DictionaryManager.UpdateWord(word);
		}
	}
}
