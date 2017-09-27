using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace demo
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void textBoxX1_ButtonCustomClick(object sender, EventArgs e)
        {
            //MessageBoxEx.Show("Execute custom action here...", "IntegerInput", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void systemfile_ButtonCustomClick(object sender, EventArgs e)
        {
            //MessageBoxEx.Show("Execute custom action here...", "IntegerInput", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Stream myStream = null;
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog2.Filter = "DAT files (*.dat)|*.dat|IMG files (*.img)|*.img";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog2.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            systemfile.Text = openFileDialog2.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


    }
}
