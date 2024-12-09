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

namespace NotePadV2
{
    public partial class blank : Form
    {
        public static bool IsSaved = false;
        public blank()
        {
            InitializeComponent();
            В.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            В.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            IsSaved = false;
            sbAmount.Text = " Количество символов: " + richTextBox1.Text.Length.ToString();
        }

        public string DocName = "";

        public void Open(string OpenFileName)
        {
            try
            {
                richTextBox1.LoadFile(OpenFileName,
                   RichTextBoxStreamType.RichText);
            }
            catch (System.ArgumentException ex)
            {
                richTextBox1.LoadFile(OpenFileName,
                   RichTextBoxStreamType.PlainText);
            }
        }

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSaved)
            {
                if (MessageBox.Show("Вы желаете сохранить изменения в документе " + this.Text + "?", "Message", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog1.FileName);
                    }
                }
            }
        }

        private void blank_Load(object sender, EventArgs e)
        {
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
    }
}
