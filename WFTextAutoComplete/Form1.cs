using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAnalysis;

namespace WFTextAutoComplete
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();

        public void GetData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var text = File.ReadAllText("WarAndWorld.txt");
            var sentences = SentencesParserTask.ParseSentences(text);
            dict = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);
        }

        public Form1()
        {
            InitializeComponent();
            textBox.TextChanged += textBox_TextChanged;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (dict.ContainsKey(((TextBox)sender).Text))
                listBox.Items.Add(dict[((TextBox)sender).Text]);
        }
    }
}
