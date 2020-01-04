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
using System.Diagnostics;

namespace файловый_менеджер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // кнопка "перейти"
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach(DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            
            foreach(FileInfo crrFiles in files)
            {
                listBox1.Items.Add(crrFiles);
            }

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()))
                == "")
            {
                textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
                DirectoryInfo[] dirs = dir.GetDirectories();
                foreach (DirectoryInfo crrDir in dirs)
                {
                    listBox1.Items.Add(crrDir);
                }
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo crrFiles in files)
                {
                    listBox1.Items.Add(crrFiles);
                }
            }
            else
            {
                Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
            }
            
        }
        // кнопка "назад"
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length-1] == '\\')
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                while(textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo crrFiles in files)
            {
                listBox1.Items.Add(crrFiles);
            }
 
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Файловый менеджер");
        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition, ToolStripDropDownDirection.Right);    
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   
    }
}
