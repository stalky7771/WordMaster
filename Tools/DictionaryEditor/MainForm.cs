using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WordMaster;

namespace WordMasterEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			Context.DictionaryManager.OnShowDictionary += OnShowDictionary;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
				return;

			string filename = saveFileDialog.FileName;

			var dict = new Dictionary();
			dict.SetDefaultData();

			string json = JsonConvert.SerializeObject(new DictionaryDTO(dict), Formatting.Indented);

			using (StreamWriter outputFile = new StreamWriter(filename))
			{
				outputFile.Write(json);
			}
		}

		private void testToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WordForm newForm = new WordForm();
			newForm.Show();
		}

		private void OnShowDictionary(Dictionary dictionary)
		{
			//statusStrip.Items[0].Text = $"Dictionary contain {dictionary.Words.Count} words";

			int index = 1;
			foreach (var wordItem in dictionary.Words)
			{
				string[] row =
				{
					$"{index++}",
					wordItem.Word,
					wordItem.Translation,
					$"[{wordItem.Transcription}]"
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

			Context.DictionaryManager.LoadDictionary(openFileDialog.FileName);
		}
	}
}
