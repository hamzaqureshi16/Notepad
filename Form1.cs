namespace Notepad
{
    public partial class Form1 : Form
    {
        private string FileName = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FileName = string.Empty;
            this.Text = "Untitled - Notepad";
            textBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string fileContents = sr.ReadToEnd();
                
                sr.Close();
                
                textBox1.Text = fileContents;
                this.Text = openFileDialog1.SafeFileName;
                this.FileName = openFileDialog1.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName.Equals(String.Empty))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    StreamWriter write = new StreamWriter(saveFileDialog1.FileName);
                    write.Write(textBox1.Text);
                    write.Close();

                }
            }
            else
            {
                StreamWriter write = new StreamWriter(FileName);
                write.Write(textBox1.Text);
                write.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(saveFileDialog1.FileName);
                write.Write(textBox1.Text);
                write.Close();

                this.Text = Path.GetFileName(saveFileDialog1.FileName);
                this.FileName = Path.GetFileName(saveFileDialog1.FileName);
            }
        }

        private void idToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            textBox1.SelectionFont = new Font(textBox1.SelectionFont, textBox1.SelectionFont.Style ^ FontStyle.Bold);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectionFont = new Font(textBox1.SelectionFont, textBox1.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void textColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.SelectionColor = colorDialog1.Color;
                
            }
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }
        }
    }
}