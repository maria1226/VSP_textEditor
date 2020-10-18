using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSP_textEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBold_Click(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            //the current font style of the highlighted text is taken
            oldFont = richTextBoxText.SelectionFont;
            //if the font style is bold, the formatting should be removed
            if (oldFont.Bold)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);

            }
            //if the font style is not bold, it is formatted in bold style
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
            }
            //the new font style is assigned to the selected text
            richTextBoxText.SelectionFont = newFont;
            //the focus is transferred to the RichTextBox control
            richTextBoxText.Focus();
        }

        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            //the current font style of the highlighted text is taken
            oldFont = richTextBoxText.SelectionFont;
            //if the font style is Underline, the formatting should be removed
            if (oldFont.Underline)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Underline);
            }
            //if the font style is not Underline, it is formatted in bold style
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Underline);
            }
            //the new font style is assigned to the selected text
            richTextBoxText.SelectionFont = newFont;
            //the focus is transferred to the RichTextBox control
            richTextBoxText.Focus();
        }

        private void buttonItalic_Click(object sender, EventArgs e)
        {
            Font oldFont, newFont;
            //the current font style of the highlighted text is taken
            oldFont = richTextBoxText.SelectionFont;
            //  //if the font style is Italic, the formatting should be removed
            if (oldFont.Italic)
            {
                newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
            }
            //if the font style is not Italic, it is formatted in bold style
            else
            {
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);
            }
            //the new font style is assigned to the selected text
            richTextBoxText.SelectionFont = newFont;
            //the focus is transferred to the RichTextBox control
            richTextBoxText.Focus();
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            if (richTextBoxText.SelectionAlignment == HorizontalAlignment.Center)
            {
                richTextBoxText.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                richTextBoxText.SelectionAlignment = HorizontalAlignment.Center;
                richTextBoxText.Focus();
            }
        }

        private void textBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this is the minimum font size allowed
            const int MinSize = 8;
            //it is not allowed to enter characters that are not Numbers, <Backspace> or <Enter>

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                //the size changes after pressing <Enter>
                TextBox txt = (TextBox)sender;
                if (Convert.ToInt16(txt.Text) < MinSize)
                {
                    txt.Text = Convert.ToString(MinSize);
                }
                ApplyTextSize(txt.Text);
                e.Handled = true;
                richTextBoxText.Focus();
            }
        }
        private void ApplyTextSize(string textSize)
        {
            //the text is converted to float type
            float newSize = Convert.ToSingle(textSize);
            FontFamily currentFontFamily;
            Font newFont;
            //a new font is created from the same family but with a new size

            currentFontFamily = richTextBoxText.SelectionFont.FontFamily;
            newFont = new Font(currentFontFamily, newSize);
            //the marked text is formatted in the new font
            richTextBoxText.SelectionFont = newFont;
        }

        private void richTextBoxText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                //a method that generates an exception is required
                richTextBoxText.LoadFile(MyFile);
                MessageBox.Show("The file" + MyFile + "is loaded successfully.");
            }
            catch (System.IO.FileNotFoundException)
            {
                //if there is an exception in block try, the block catch is executed
                MessageBox.Show("File " + MyFile + "is not found");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //save the text in a file
            try
            {
                richTextBoxText.SaveFile(MyFile);
                MessageBox.Show("The file " + MyFile + "is saved successfully");
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }

       
    
}
