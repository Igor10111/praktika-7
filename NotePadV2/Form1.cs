using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadV2
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Документ " + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();
        }

        private int openDocuments = 0;

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void вертикальнаяПлиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                if (editBox != null)
                {
                    Clipboard.SetDataObject(editBox.SelectedText);
                }
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                if (editBox != null)
                {
                    IDataObject data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(DataFormats.Text))
                    {
                        editBox.SelectedText =
                        data.GetData(DataFormats.Text).ToString();
                    }
                }
            }

        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                if (editBox != null)
                {
                    Clipboard.SetDataObject(editBox.SelectedText);
                    editBox.SelectedText = "";
                }
            }

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                if (editBox != null)
                {
                    editBox.SelectedText = "";
                }
            }
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                if (editBox != null)
                {
                    editBox.SelectAll();
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.Text = openFileDialog1.FileName;
                frm.Show();
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form activeChild = this.ActiveMdiChild;
                if (activeChild != null)
                {
                    RichTextBox editBox = (RichTextBox)activeChild.ActiveControl;
                    editBox.SaveFile(saveFileDialog1.FileName);
                    activeChild.Text = saveFileDialog1.FileName;
                    blank.IsSaved = true;
                }
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
           
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            fontDialog1.ShowColor = true;
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color;
            }
            frm.Show();
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
             blank frm = (blank)this.ActiveMdiChild;
             frm.MdiParent = this;
             colorDialog1.Color = frm.richTextBox1.SelectionColor;
             if (colorDialog1.ShowDialog() == DialogResult.OK)
             {
                 frm.richTextBox1.SelectionColor = colorDialog1.Color;
             }
             frm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
