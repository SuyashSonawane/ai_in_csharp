using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace speech
{
    public partial class browser : Form
    {
        public browser()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack(); 
        }

        private void forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)13)
            {
                webBrowser1.Navigate(textBox1.Text);
            }
        }

        private void go_Click(object sender, EventArgs e)
        {          
          
             webBrowser1.Navigate(textBox1.Text);
            
        }
    }
}
