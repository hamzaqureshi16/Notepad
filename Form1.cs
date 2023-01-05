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
                //read the contents of the file into a stream
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                //read the contents of the file into a string
                string fileContents = sr.ReadToEnd();
                //close the file
                sr.Close();
                //display the file contents in the textbox
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
    }
}