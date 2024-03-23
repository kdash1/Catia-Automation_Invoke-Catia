using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INFITF;
using PARTITF;
using MECMOD;


namespace Invoke_Catia
{
    public partial class Form1 : Form
    {
        INFITF.Application catiaApp;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            try
            {
                catiaApp = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");
            }
            catch
            {
                Type catiaType = Type.GetTypeFromProgID("CATIA.Application");
                catiaApp = (INFITF.Application)Activator.CreateInstance(catiaType);
            }
            catiaApp.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            INFITF.Document catiaDoc;
            if (catiaApp != null)
            {
                catiaDoc = catiaApp.Documents.Add("Part");
                MessageBox.Show("New Part Document added", "Catia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
