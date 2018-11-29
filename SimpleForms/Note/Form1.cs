using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note
{
    public partial class Form1 : Form
    {
        private string fileName = "Untitled.txt";
        private string filePath = "";

        public Form1()
        {
            InitializeComponent();

            this.Text = fileName + "- Note";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";
            if (richTextBox1.Text != "")
            {
                message = "Do you want to save changes to the " + filePath + " ?";
                if (MessageBox.Show(message, "Note",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveFileDialog.FileName = "Untitled.txt";
                    filePath = "";
                    richTextBox1.Text = "";

                    this.Text = "Untitled" + "- Note";
                }
                else
                {
                    message = "Are you sure you want to exit?";

                    if (MessageBox.Show(message, "Confirm Exit",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question
                        ) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                string message = "Do you want to save changes to the " + filePath + " ?";
                if (MessageBox.Show(message, "Note",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveFileDialog.FileName = "Untitled.txt";
                    filePath = "";
                    richTextBox1.Text = "";

                    this.Text = "Untitled" + "- Note";
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == "")
                openFileDialog.InitialDirectory = Application.StartupPath;
            else
                openFileDialog.InitialDirectory = filePath;

            openFileDialog.FileName = "";

            DialogResult dr = openFileDialog.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(
                    openFileDialog.FileName, Encoding.GetEncoding("UTF-8"));

                filePath = openFileDialog.FileName;

                fileName = Path.GetFileName(openFileDialog.FileName);
                this.Text = fileName + "- Note";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                saveFileDialog.FileName = filePath;
                File.WriteAllText(
                    saveFileDialog.FileName, richTextBox1.Text,
                    Encoding.GetEncoding("UTF-8"));
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == "")
                saveFileDialog.InitialDirectory = Application.StartupPath;
            else
                saveFileDialog.InitialDirectory = filePath;

            string[] filename = saveFileDialog.FileName.Split('\\');
            saveFileDialog.FileName = filename[filename.Length - 1];

            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(
                    saveFileDialog.FileName, richTextBox1.Text,
                    Encoding.GetEncoding("UTF-8"));

                filePath = saveFileDialog.FileName;
                fileName = Path.GetFileName(filePath);
                this.Text = fileName + "- Note";
            }
        }
    }
}
