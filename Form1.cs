namespace Notepad
{
    public partial class Form1 : Form
    {
        private string FileName = String.Empty;//this variable will store the  name of the current file that is opened
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FileName = string.Empty;//new too; item is clicked so we will set the FileName to empty
            this.Text = "Untitled - Notepad"; //sets the title of the form to Untitled - Notepad
            textBox1.Clear();//clears the textbox input
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//shows the openfile dialog and waits for user to click ok
            {
                
                StreamReader sr = new StreamReader(openFileDialog1.FileName);//opens the user selected file in read mode
                string fileContents = sr.ReadToEnd();//reads the whole file
                
                sr.Close();//closes the streamreader obejct
                
                textBox1.Text = fileContents;//displays the file contents to the textbox
                this.Text = openFileDialog1.SafeFileName;//sets the title of the form to the currently opened file
                this.FileName = openFileDialog1.FileName;//stores the name of the currently opened file
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileName.Equals(String.Empty))//if no file is opened right now
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)// shows the savefilediaglog and waits for user input
                {

                    StreamWriter write = new StreamWriter(saveFileDialog1.FileName);//opens streamwriter obj to write to the file 
                    write.Write(textBox1.Text);//writing to file form the textbox
                    write.Close();//closes the streamwriter object

                }
            }
            else//if a file is already opened
            {
                StreamWriter write = new StreamWriter(FileName);//writes to the already opened file's path
                write.Write(textBox1.Text);//writing to file
                write.Close();//closes the streamwriter obj
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//opens the saveas file dialog and wait for user input
            {
                StreamWriter write = new StreamWriter(saveFileDialog1.FileName);//opens a streamwriter obj to write to the file(filename got from user)
                write.Write(textBox1.Text);//writes to file
                write.Close();//closes the streamwriter obj

                this.Text = Path.GetFileName(saveFileDialog1.FileName);//sets title of the form to the currently opened file
                this.FileName = Path.GetFileName(saveFileDialog1.FileName);//stores the file name of the currently opened file
            }
        }

        private void idToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();//closes the form
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            textBox1.Cut();//cuts the selected text
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();//copies the selected text
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();//pasted the previously copied/cut text
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the font style of the selected text to bold
            //user the XNOR operator to toggle the bold style
            textBox1.SelectionFont = new Font(textBox1.SelectionFont, textBox1.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //does nothing
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set the font style of the selected text to italic
            //user the XNOR operator to toggle the italic style
            textBox1.SelectionFont = new Font(textBox1.SelectionFont, textBox1.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void textColor_Click(object sender, EventArgs e)
        {
            
            if(colorDialog1.ShowDialog() == DialogResult.OK)//shows the colordialog and waits for user to click ok
            {
                textBox1.SelectionColor = colorDialog1.Color;//sets the textbox's font color to the selected color
            }
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)//shows the colordialog and waits for user to click ok
            {
                textBox1.BackColor = colorDialog1.Color;//sets the textbox's background color to the selected color
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)//shows the fontdialog and waits for user to click ok
            {
                textBox1.Font = new Font(fontDialog1.Font,textBox1.Font.Style);//sets the textbox's font to the selected font
            }
        }
    }
}