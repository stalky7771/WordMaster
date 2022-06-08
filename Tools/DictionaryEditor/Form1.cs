using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordMasterEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private int counter = 0;
		private void buttonTest_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Test");
			//ListViewItem lvi = new ListViewItem();
			//lvi.SubItems.Add("AAA");
			//lvi.SubItems.Add("BBB");
			//lvi.SubItems.Add("CCC");


			string[] row = { counter++.ToString(), "BBB", "CCC" };
			var listViewItem = new ListViewItem(row);
			listViewWords.Items.Add(listViewItem);

			listViewWords.Items[listViewWords.Items.Count - 1].SubItems[0].Text = "12345";

			statusStrip.Items[0].Text = counter.ToString();

			//listView1.Items.Add(lvi);
		}
	}
}
