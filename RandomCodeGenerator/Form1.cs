using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace RandomCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string returnValue;
        int numericValue;

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Focus();
        }

        // Generate Button
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            toolStripStatusLabel1.Text = "文字列の生成中です...";
            numericValue = (int)numericUpDown1.Value;
            textBox1.Text = generateCode(numericValue);
            toolStripStatusLabel1.Text = "文字列を生成しました！";
            button1.Enabled = true;
            button1.Focus();
        }

        // Copy the code Button
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            toolStripStatusLabel1.Text = "文字列をコピー中です...";
            copyClipboard(textBox1);
            toolStripStatusLabel1.Text = "文字列をコピーしました！";
            button2.Enabled = true;
            button1.Focus();
        }

        private string generateCode(int length)
        {
            string codeChar = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder strBuild = new StringBuilder(length);
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int pos = rand.Next(codeChar.Length);
                char code = codeChar[pos];
                strBuild.Append(code);
            }
                return strBuild.ToString();
        }

        private void copyClipboard(TextBox box)
        {
            box.SelectAll();
            box.Copy();
        }

        private void takeConfirm(String message)
        {
            DialogResult result = MessageBox.Show(message + Environment.NewLine + "続行しますか？", "警告", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("続行します。");
                returnValue = "continue";
            }
            else
            {
                MessageBox.Show("中止します。");
                returnValue = "stop";
            }
        }
    }
}
