using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Viewer
{
    public partial class hexViewer : Form
    {
        hexReadWrite hexView = new hexReadWrite();
        public hexViewer()
        {
            InitializeComponent();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog {InitialDirectory = "C:\\", CheckPathExists = true, CheckFileExists = true, Title = "Select a file to read in hex" })
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Clear();
                    string[] load;
                    load = hexView.Read(open.FileName);
                    textBox1.Lines = load;
                }
            }
        }
    }
}
