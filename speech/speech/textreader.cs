using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace speech
{
    public partial class textreader : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();

        public textreader()
        {
            InitializeComponent();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                this.Text = openFileDialog1.SafeFileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s.SpeakAsync(richTextBox1.Text);
        }
    }
}
