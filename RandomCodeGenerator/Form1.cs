using System;
using System.Windows.Forms;

namespace RandomCodeGenerator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Disable(button1);
            ChangeStatus("文字列の生成中です...");
            ChangeText(Generate((int)numericUpDown1.Value));
            ChangeStatus("文字列を生成しました！");
            Enable(button1);
        }

        private void button2_Click(object sender, EventArgs e) {
            Disable(button2);
            ChangeStatus("文字列をコピー中です...");
            Copy(textBox1);
            ChangeStatus("文字列をコピーしました！");
            Enable(button2);
        }

        private string Generate(int length) {
            var result = "";
            var codeChar = "0123456789abcdefghijklmnopqrstuvwxyz";
            var rand = new Random();
            for (var i = 0; i < length; i++) {
                var pos = rand.Next(codeChar.Length);
                var code = codeChar[pos];
                result += code;
            }
            return result;
        }

        private void Copy(TextBox box) {
            box.SelectAll();
            box.Copy();
        }

        private void ChangeStatus(string text) {
            toolStripStatusLabel1.Text = text;
        }

        private void Disable(Button btn) {
            btn.Enabled = false;
        }

        private void Enable(Button btn) {
            btn.Enabled = true;
        }

        private void ChangeText(string text) {
            textBox1.Text = text;
        }
    }
}
